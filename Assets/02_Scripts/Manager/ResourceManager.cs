using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    
    //����
    public T Load<T>(string path) where T : Object
    {
        if(typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if(index >= 0)
            {
                name = name.Substring(index + 1);
            }
            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");

        if(original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        if (original.GetComponent<Poolable>() != null)
        {
            return Managers.Pool.Pop(original, parent).gameObject;
        }
        GameObject go = Object.Instantiate(original, parent);
        
        
        int index = go.name.IndexOf("(Clone)"); //"(Clone)"���ڿ��� ã�Ƽ� �ε����� ��ȯ
        
        if (index > 0)
        {
            go.name = go.name.Substring(0, index); //UI_Inven_Item//(Clone)
        }

        return go;
    }

    //�����غ����� �� �����δ� �ʿ����.
    public void Destroy(GameObject go)
    {
        if (go == null)
            return;
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
            //poolable�� dictionary _pool�� ���ִ� �׸���� ��Ȱ��ȭ�Ǿ� 
            //�ٽ� ������Ʈ Ǯ�� ���� poolable�� �پ��ְ� dictionary�� ���� �׸���� �ı���Ų��.
        }
        Object.Destroy(go);
    }

}
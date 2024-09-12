using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    
    //랩핑
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
        
        
        int index = go.name.IndexOf("(Clone)"); //"(Clone)"문자열을 찾아서 인덱스를 반환
        
        if (index > 0)
        {
            go.name = go.name.Substring(0, index); //UI_Inven_Item//(Clone)
        }

        return go;
    }

    //랩핑해본것일 뿐 실제로는 필요없다.
    public void Destroy(GameObject go)
    {
        if (go == null)
            return;
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
            //poolable에 dictionary _pool에 들어가있는 항목들은 비활성화되어 
            //다시 오브젝트 풀에 들어가나 poolable만 붙어있고 dictionary에 없는 항목들은 파괴시킨다.
        }
        Object.Destroy(go);
    }

}
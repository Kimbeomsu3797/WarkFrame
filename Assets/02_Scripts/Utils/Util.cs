using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Util
{
    public static GameObject FindChild(GameObject go, string name, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
        {
            return null;
        }
        return transform.gameObject;
    }

    //(�ֻ��� �θ�, �̸��� ������ �ʰ� �� Ÿ�Կ��� �ش��ϸ� ����(���ͳ�Ʈ�̸�),
    // ��������� ��� �ڽĸ� ã������ �ڽ��� �ڽĵ� ã�� ������
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false)
        where T : UnityEngine.Object
    {
        if (go == null)
            return null;
        if (recursive == false) //���� �ڽĸ�
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else // �ڽ��� �ڽı���
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {   //�̸��� ����ְų� ���� ã������ �̸��� ���ٸ�
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }
        return null;
    }
   //���� ������Ʈ�� �ش� ���۳�Ʈ�� ������ �������ִ� �Լ�
    public static T GetorAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }//GetorAddComponent<T>(GameObject go) // ȣ������
    
    
}

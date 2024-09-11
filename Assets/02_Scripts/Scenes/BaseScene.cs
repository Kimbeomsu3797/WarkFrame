using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void Init()
    {
        //Ÿ������ ������Ʈ ã��
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        //������ ����
        if (obj == null)
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";//������ �������� �����ϱ� �ָ��Ѱ�� @�� �ٿ��� ���ο� �������� �����Ѵ�
    }
    public abstract void Clear();
}


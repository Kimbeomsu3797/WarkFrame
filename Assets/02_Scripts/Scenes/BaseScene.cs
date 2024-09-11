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
        //타입으로 오브젝트 찾기
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        //없으면 생성
        if (obj == null)
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";//기존의 순번에서 시작하기 애매한경우 @을 붙여서 새로운 순번으로 시작한다
    }
    public abstract void Clear();
}


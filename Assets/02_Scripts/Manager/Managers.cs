using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장된다.
    public static Managers instance { get { Init(); return s_instance; } } //유일한 매니저스를 갖고온다.
    //이제 매니저스는 자신이 뭔가를 직접하기 보단 다른 매니저들을 관리 (싱글톤을 사용하게)해주는 치프매니저라고 생각하면 된다.
    //그래서 직접 외부에서 직급 할필요가 없어서 private로 만들었음.

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    public static InputManager input { get { return instance._input; } }
    public static ResourceManager Resource { get { return instance._resource; } }
    public static UIManager UI { get { return instance._ui; } }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate(); //인풋매니저의 onUpdate()실행,OnUpdate()에서 Invoke로 액션 실행
    }
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null) //go가 없으면
            {
                go = new GameObject { name = "@Managers" };//코드로 오브젝트를 만들어줌
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}

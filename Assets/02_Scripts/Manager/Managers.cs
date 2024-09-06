using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // ���ϼ��� ����ȴ�.
    public static Managers instance { get { Init(); return s_instance; } } //������ �Ŵ������� ����´�.
    //���� �Ŵ������� �ڽ��� ������ �����ϱ� ���� �ٸ� �Ŵ������� ���� (�̱����� ����ϰ�)���ִ� ġ���Ŵ������ �����ϸ� �ȴ�.
    //�׷��� ���� �ܺο��� ���� ���ʿ䰡 ��� private�� �������.

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
        _input.OnUpdate(); //��ǲ�Ŵ����� onUpdate()����,OnUpdate()���� Invoke�� �׼� ����
    }
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null) //go�� ������
            {
                go = new GameObject { name = "@Managers" };//�ڵ�� ������Ʈ�� �������
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}

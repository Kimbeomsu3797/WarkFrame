using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    //���۳�Ʈ�� �������� �Լ� ���·� ����(type�� ����ҷ��� using system;)
    public abstract void Init();
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
            //�� ã���ְ� �ִ��� �׽�Ʈ
            if (objects[i] == null)
            {
                Debug.Log($"Failed to bind({names[i]})");
            }
        }
    }
    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false) // ���� ������ �׳� ����
            return null;
        return objects[idx] as T; // ������Ʈ���ٰ� �ε�����ȣ�� ������ ������ T�� ĳ���� ����
    }
    //protected Text GetText(int idx) { return Get<Text>(idx); }
    protected GameObject GetObject(int idx) { return Get<GameObject>(idx); }
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    protected Image GetImage(int idx) { return Get<Image>(idx); }
    protected TextMeshProUGUI GetTextMeshProUGUI(int idx) { return Get<TextMeshProUGUI>(idx); }
    protected GameObject GetGameObject(int idx) { return Get<GameObject>(idx); }

    //go�� action�� ���Ե� ��ũ��Ʈ�� �ִ� ���ӿ�����Ʈ // action�� ������ ��ų �׼� // mode(����)
    /*public static void BindUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click) //, OnDragHandler
    {
        //������ ���۳�Ʈ�� ������ ���������� ���°�쵵 �ִ�. �̶� �ڵ����� ������ �� �ְ� ����
        UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        evt.OnDragHandler += ((PointerEventData data) => { go.transform.position = data.position; });
    }*/
    public static void BindUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click) //, OnDragHandler
    {
        //������ ���۳�Ʈ�� ������ ���������� ���°�쵵 �ִ�. �̶� �ڵ����� ������ �� �ְ� ����
        UI_EventHandler evt = Util.GetorAddComponent<UI_EventHandler>(go);
        //evt.OnDragHandler += ((PointerEventData data) => { go.transform.position = data.position; });
        
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
        }
    }
}

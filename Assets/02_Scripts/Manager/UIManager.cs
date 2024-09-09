using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10; //Ȥ�� �𸣴ϱ� ������ �ΰ� ���� �����Ұ� �ִٸ� 10���� ���� ���� �˾��� �� �ְ� ��.
    //���� �������� ��� �˾��� ���� ���� ��������ϱ� ������
    UI_Scene _sceneUI = null;
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    Stack<UI_Inven> _invenStack = new Stack<UI_Inven>();
    //������ �������� ���� ����
    //Q�� �������� ����
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
        //T�� �ƹ�T�� �޴°� �ƴ϶� ������ UI �˾��� ��ӹ޴� �ַ� ������
    {
        if (string.IsNullOrEmpty(name))//�̸��� �ȹ޾�����
            name = typeof(T).Name;//T�� �̸�����

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");//�˾�����
        T popup = Util.GetorAddComponent<T>(go); // ���۳�Ʈ�� �پ����� �ʴٸ� �߰�
        _popupStack.Push(popup);
        /*GameObject root = GameObject.Find("@UI_Root");
        if(root == null)
        {
            root = new GameObject { name = "@UI_Root" };
        }*/

        go.transform.SetParent(Root.transform);
        return popup;
    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
        //T�� �ƹ�T�� �޴°� �ƴ϶� ������ UI �˾��� ��ӹ޴� �ַ� ������
    {
        if (string.IsNullOrEmpty(name))//�̸��� �ȹ޾�����
            name = typeof(T).Name;//T�� �̸�����

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");//�˾�����
        T sceneUI = Util.GetorAddComponent<T>(go); // ���۳�Ʈ�� �پ����� �ʴٸ� �߰�
        _sceneUI = sceneUI;
       
        /*GameObject root = GameObject.Find("@UI_Root");
        if (root == null)
        {
            root = new GameObject { name = "@UI_Root" };
        }*/

        go.transform.SetParent(Root.transform);
        return sceneUI;
    }
    public T MakeSubItem<T>(Transform parent = null, string name = null)where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");
        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetorAddComponent<T>(go);
    }
    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }
    public void SetCanvas(GameObject go,bool sort = true)
    {
        //ĵ���� ����
        Canvas canvas = Util.GetorAddComponent<Canvas>(go);
        //�������� ������ ScreenSpaceOverlay(�̰�쿡�� ���õǱ� ������)
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //ĵ���� �ȿ� ĵ������ ��ø�ؼ� ���� �� �� �θ� � ���� ������ �ڽ��� ������ �� ���� ������ ��������
        //overrideSorting�� ���� Ȥ�ö� ��øĵ������ �ڽ� ĵ������ �ִ��� �θ� ĵ������ � ���� ������
        //���� �� �������� ������ �Ҷ� true
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else //�˾��̶� ������� �Ϲ� UI
        {
            canvas.sortingOrder = 0;
        }
    }
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }

    public void ClosePopupUI(UI_Popup popup) // �����Ұ��� ������ �� ������ �� �� �����ϰ� ������ �� �ִ�.
    {
        if (_popupStack.Count == 0)
            return;
        // Peek() : Stack <T>�� �� ������ ��ü�� �������� �ʰ� ��ȯ�մϴ�. (������ �ʰ� �����ٰ� ����)
        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }
        ClosePopupUI();
    }
    
    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
    public void CloseSceneUI()
    {
        if (_invenStack.Count == 0)
            return;

        UI_Inven inven = _invenStack.Pop();
        Managers.Resource.Destroy(inven.gameObject);
        inven = null;
        _order--;
    }
    public void CloseSceneUI(UI_Inven Inven) // �����Ұ��� ������ �� ������ �� �� �����ϰ� ������ �� �ִ�.
    {
        if (_invenStack.Count == 0)
            return;
        // Peek() : Stack <T>�� �� ������ ��ü�� �������� �ʰ� ��ȯ�մϴ�. (������ �ʰ� �����ٰ� ����)
        if (_invenStack.Peek() != Inven)
        {
            Debug.Log("Close Inven Failed!");
            return;
        }
        CloseSceneUI();
    }
    public void CloseAllSceneUI()
    {
        while (_invenStack.Count > 0)
            CloseSceneUI();
    }

}

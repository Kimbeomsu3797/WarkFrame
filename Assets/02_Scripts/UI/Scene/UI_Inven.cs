using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    
    
    enum GameObjects
    {
        GridPanel
    }
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);
        for (int i = 0; i < 9; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Item>(gridPanel.transform).gameObject;
            //GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Item");
            //item.transform.SetParent(gridPanel.transform);

            UI_Item invenitem = item.GetOrAddComponent<UI_Item>();
            invenitem.setinfo($"�׽�Ʈ {i+1}��");
        }
    }
    public void MakeSubItem()
    {

    }
   
}

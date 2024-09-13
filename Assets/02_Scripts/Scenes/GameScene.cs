using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        //Managers.UI.ShowSceneUI<UI_Inven>();

        //for (int i = 0; i < 2; i++)
            //Managers.Resource.Instantiate("unitychan");
        Dictionary<int, Data.Stat> Dict = Managers.Data.StatDict;
    }
    public override void Clear()
    {
        throw new System.NotImplementedException();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

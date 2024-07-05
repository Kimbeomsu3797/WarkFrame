using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.ComponentModel;
using UnityEngine.UI;

using UnityEngine.EventSystems;
//using TMPro;

public class UI_Button : UI_Base
{
    /*[SerializeField]
    TextMeshProUGUI _text;

    int _score = 0;*/
    enum Buttons
    {
        PointButton
    }
    enum Texts
    {
        PointText,
        ScoreText,
    }
    enum GameObjects
    {
        TestObject,
    }
    enum Images
    {
        image
    }
    // Start is called before the first frame update
    void Start()
    {
       Bind<Button>(typeof(Buttons));
       Bind<Text>(typeof(Texts));
       Bind<TextMeshProUGUI>(typeof(Texts));
       Bind<GameObject>(typeof(GameObjects));
       Bind<Image>(typeof(Images));
       //test
       //Get<Text>((int)Texts.ScoreText).text = "Test";
       GetTextMeshProUGUI((int)Texts.ScoreText).text = "Test";
       //GetText((int)Texts.ScoreText).text = "Test";
       GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);
        GameObject go = GetImage((int)Images.image).gameObject;
        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnBeginDragHandler += ((PointerEventData data) => { go.transform.position = data.position; });
        AddUIEvent(go,(PointerEventData data) => { go.transform.position = data.position; },Define.UIEvent.Drag);
    }
    //���۳�Ʈ�� �������� �Լ� ����
   
    
    // Update is called once per frame
    void Update()
    {
        
    }
    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        //_score++;
        //_text.text = $"���� : { _score}";
        _score++;
        GetTextMeshProUGUI((int)Texts.ScoreText).text = $"���� : {_score}";
    }
  
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ILoader<key, value>
{
    Dictionary<key, value> MakeDict();
}


public class DataManager
{
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
   
    public void Init()
    {
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        
    }
    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value> //Loader�� T(���׸�)�� �Ȱ��� ���Ǿ���.
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}

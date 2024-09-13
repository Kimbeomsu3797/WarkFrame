using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define // 상태라거나 필요한 변수같은걸 여기에 모아둠
{
    public enum UIEvent
    {
        Click,
        Drag,
    }
    public enum MouseEvent
    {
        Press,
        Click,
    }
    public enum CameraMode
    {
        Quaterview, testview //
    }
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum Layer
    {
        Monster = 8,
        Ground = 9, // 근데이거 몬스터만 8로만 해줘도 자동으로 9 10되는거 아닌가?
        Block = 10,
    }
}

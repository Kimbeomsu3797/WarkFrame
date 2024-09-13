using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define // ���¶�ų� �ʿ��� ���������� ���⿡ ��Ƶ�
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
        Ground = 9, // �ٵ��̰� ���͸� 8�θ� ���൵ �ڵ����� 9 10�Ǵ°� �ƴѰ�?
        Block = 10,
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�Ŵ������� �־ ���� ������Ʈ�� ���� �ʿ䰡 �����ϱ� �Ϲ����� C#���Ϸ� ����
public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;

    //��ǥ�� �Է��� üũ�� ������ ������ �Է��� ������ �װ��� �̺�Ʈ�� ���ĸ� ���ִ� �������� ����(������ ����)
    //�̷����ϸ� �÷��̾���Ʈ�ѷ��� 100�̵Ǵ� 1000���� �Ǵ� �� �������� �ѹ����� üũ�ذ����� �� �̺�Ʈ�� �����ϴ� ������� ���� �� ����
    //�̷��� �����ϸ� �� ���� ���� ��� Ű���� �Է��� �޾Ҵ��� ã�Ⱑ ����� ������ �ؼҵȴ�.
    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if(Input.anyKey && KeyAction != null)
         KeyAction.Invoke();
        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0)) //�������ϰ��
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else // Ŭ���� ���(���࿡ �ѹ��̶� �������� ������ click�̶�� �̺�Ʈ �߻�)
            {
                if(_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);

                _pressed = false;
            }
        }

        //�ϳ��� Form�� �ٸ� thread���� �����ϰ� �� ��쿡 ������ Form�� �浹�� �� �� �ִ�.
        //�� �� invoke�� ����Ͽ� �����Ϸ��� �ϴ� �޼ҵ��� �븮��(delegate)�� �����Ű�� �ȴ�.
    }

}
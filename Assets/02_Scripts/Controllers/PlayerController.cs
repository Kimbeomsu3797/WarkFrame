using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;  // _ �� ����ϸ� ���������� ����Ѵٴ� ��

    bool _moveToDest = false;
    Vector3 _destPos;
    //float wait_run_ratio = 0;
    
    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }
    PlayerState _state = PlayerState.Idle;
    void Start()
    {
        Managers.input.KeyAction -= Onkeyboard;
        Managers.input.KeyAction += Onkeyboard;
        Managers.input.MouseAction -= OnMouseClicked;
        Managers.input.MouseAction += OnMouseClicked;
        //Managers.Resource.Instantiate("UI/UI_Button"); // ������������ UI������ ���� �� ���� // ������������ ���̽���°� ���
        //Managers.UI.ShowPopupUI<UI_Button>("UI_Button");
        //Debug.Log(5656);
        //uiPopup = Managers.UI.ShowPopupUI<UI_Button>(); // Managers.UI.ShowPopupUI<UI_Button>("�˾�UI��");
        for (int i =0; i<1; i++)
        {
            uiPopup = Managers.UI.ShowPopupUI<UI_Button>();//���� �ڵ�(�����ӿ�ũ�ƴ�)
        }
        Managers.UI.ShowSceneUI<UI_Inven>();//���� �ڵ�(�����ӿ�ũ�ƴ�)
    }
    UI_Button uiPopup;//���� �ڵ�(�����ӿ�ũ�ƴ�)

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case
                PlayerState.Idle:
                UpdateIdle();
                break;
                
        }
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
        {
            //Managers.UI.ClosePopupUI();
            
            
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiPopup != null)
            {
                Managers.UI.ClosePopupUI(uiPopup);
            }
        }
       
        
        /*if (_moveToDest)
        {
            Vector3 dir = _destPos - transform.position;//����
            if (dir.magnitude < 0.0001f)//�Ÿ�
            {
                _moveToDest = false;
            }
            else
            {
                
                 float moveDist = _speed * Time.deltaTime
                if (moveDist >= dir.magnitude)
                    moveDist = dir.magnitude;
                
                //���� �ڵ带 �̷������� ǥ�� ����
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); // dir.magnitude�� ������ ������ �ִ�Ÿ� // �� �̻��� �̵����� ���ϰ�

                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
            }
        }*/
        /*if(_moveToDest)
        {
            Animator anim = GetComponent<Animator>();
            anim.Play("RUN");
        }
        else
        {
            Animator anim = GetComponent<Animator>();
            anim.Play("WAIT");
        }*/
        /*if (_moveToDest)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", 1);
            anim.Play("RUN");
        }
        else
        {
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", 0);
            anim.Play("WAIT");
        }*/
        /*if (_moveToDest)
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio,1,10.0f*Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
            anim.Play("RUN");
        }
        else
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
            anim.Play("WAIT");
        }*/
    }
    void UpdateDie()
    {

    }
    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if(dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed*Time.deltaTime,0, dir.magnitude);
            transform.position += dir.normalized* moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir), 20*Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("speed",_speed);
        }
    }
    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }
    void Onkeyboard()
    {
        
        
        
        // ��, �� ��, �� �̵�
        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            // ȸ�� ����
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);   // ���� ��ǥ�� �ٶ󺸴� �������� ���� ��
            transform.position += Vector3.forward * Time.deltaTime * _speed;    // ���� ��ǥ�� �� �̵����� ������ ������� ��
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            //transform.Translate(Vector3.back * Time.deltaTime * _speed);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            //transform.Translate(Vector3.left * Time.deltaTime * _speed);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            //transform.Translate(Vector3.right * Time.deltaTime * _speed);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        _moveToDest = false; //Ŭ��������� �̵� �Ұ�
    }
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;
        //Press�ϰ��� �۵� �ȵǰ� (�ӽ÷� ó���� �� �ְ�)
        //������ ����� ����ϰ� �ʹٸ� ����, �ּ�ó��
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,100.0f, LayerMask.GetMask("Ground"))) // LayerMask.GetMask�� ���� Ŭ���ɼ��ְ� ���ִ� �ڵ�
        {
            _destPos = hit.point;
            //_moveToDest = true;
            _state = PlayerState.Moving;
        }
    }
}

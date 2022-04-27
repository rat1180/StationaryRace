using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�L�[���\����
public struct KEYS
{
    //�A�N�Z���L�[ true:�I�� false:�I�t
    public bool AcceleKey;
    //�u���[�L�L�[ true:�I�� false:�I�t
    public bool BrakeKey;
    //�A�C�e���L�[ true:�I�� false:�I�t
    public bool ItemKey;
    //�n���h�����̓L�[ 0:�Ȃ� 1:�E 2:��
    public int HandleKey;

}

public class UserOperation : MonoBehaviour
{
    /******************
     �e�L�[�̓��͔���p�ϐ�
    *******************/

    private KEYS Key;



    /****************
     �q�N���X�̎擾�p�I�u�W�F�N�g
    *****************/

    //�����̋@��
    private GameObject Mashin;
    //UI
    private GameObject UI;

    /****************
     ���̑��̕ϐ�
    *****************/
    
    //�G���[����
    private int Erflg;

    //����
    private int Rank = 3;

    //�A�C�e��
    private int ItemNm;

    //CP�ʉ߃^�C��
    private double CPTime;

    // Start is called before the first frame update
    void Start()
    {
        //�L�[�̏�����
        InitKey();

        InitSet();

        //�G���[�`�F�b�N���s��
        Erflg = InitErCheck();
        if(Erflg != 0)
        {
            Debug.Log(Erflg);
        }

        RankSend();

    }

    // Update is called once per frame
    void Update()
    {
        KeyListener();
        KeySend();
    }

    //�L�[�̏�����
    public void InitKey()
    {
        
        Key.AcceleKey = false;
        Key.BrakeKey = false;
        Key.ItemKey = false;
        Key.HandleKey = 0;
        

    }

    //�@�́AUI�̎擾
    private void InitSet()
    {
        //�@��
        Mashin = transform.Find("test_M").gameObject;

        //UI
        //UI = transform.Find("UI").gameObject;

    }

    private void KeyListener()
    {
        //�e�L�[�̓��͏���
        if (Input.GetKey(KeyCode.A))
        {
            Key.AcceleKey = true;
        }
        else
        {
            Key.AcceleKey = false;
        }

        if (Input.GetKey(KeyCode.B))
        {
            Key.BrakeKey = true;
        }
        else
        {
            Key.BrakeKey = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Key.ItemKey = true;
        }
        else
        {
            Key.ItemKey = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Key.HandleKey = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Key.HandleKey = 2;
        }
        else
        {
            Key.HandleKey = 0;
        }
    }

    private void KeySend()
    {
        //�@�̂ɑ���
        if(Key.AcceleKey == true)
        {
            Debug.Log("�A�N�Z��on");
        }
        if(Key.BrakeKey == true)
        {
            Debug.Log("�u���[�Lon");
        }
        if(Key.ItemKey == true)
        {
            Debug.Log("�A�C�e��on");
        }
        if(Key.HandleKey == 1)
        {
            Debug.Log("�E");
        }else if(Key.HandleKey == 2)
        {
            Debug.Log("��");
        }
    }

    //UI�ɏ��ʂ𑗂�
    public void RankSend()
    {
        //UI.GetComponent<UI>().RankingChange(Rank);
    }

    /******************
     �@�@�G���[�n
    *******************/

    //�G���[�`�F�b�N(0:�ُ�Ȃ� 1:�@�̃G���[ 2:UI�G���[)
    public int InitErCheck()
    {
        if(Mashin == null)
        {
            return 1;
        }
        if (UI == null)
        {
            return 2;
        }
        return 0;
    }

    private void ErDown()
    {
        //�G���[�R�[�h
        //3��:�@�́EUI�̏�� 0>�ُ�Ȃ� 1>UI�Ɉُ�
        int ErCode;

        Erflg = Erflg * 100;
        ErCode = Erflg;

        //ErCode���V�X�e���ɑ��M

    }

}
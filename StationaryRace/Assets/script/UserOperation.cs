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
     ���N���X�̎擾�p�I�u�W�F�N�g
    *****************/

    //�����̋@��
    private GameObject Mashin;

    //UI
    private GameObject UI;

    //�V�X�e��
    private GameObject GMSystem;

    //�A�C�e��
    public GameObject ItemManager;

    /****************
     ���̑��̕ϐ�
    *****************/

    //�G���[����
    private int Erflg;

    //����
    private int Rank;

    //�A�C�e��
    private int ItemNm;

    //CP�ʉ߃^�C��
    private double CPTime;

    //CP�̒ʉߐ�
    private int CPcnt;

    //���[�U�[�ԍ�
    private int UserNm;

    /***************
     ��`�p�ϐ�
    ****************/

    //�n���h������
    private int NULL = 0;
    private int RIGHT = 1;
    private int LEFT = 2;

    //�A�C�e���ϐ�(�Ȃ���-1)
    private int NON = -1;

    void Awake()
    {
        InitSet();
    }

    // Start is called before the first frame update
    void Start()
    {
        //�L�[�̏�����
        InitKey();

        //�G���[�`�F�b�N���s��
        Erflg = InitErCheck();
        if(Erflg != 0)
        {
            Debug.Log(Erflg);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ItemSend();
        KeyListener();
        //KeySend();
    }

    /************
     �N��������(�G���[�͉�)
    *************/

    //�L�[�̏�����
    public void InitKey()
    {
        
        Key.AcceleKey = false;
        Key.BrakeKey = false;
        Key.ItemKey = false;
        Key.HandleKey = NULL;
        

    }

    //�@�́AUI�̎擾��e�l�̏����l�Z�b�g
    private void InitSet()
    {
        //�V�X�e��
        //GMSystem = transform.parent.gameObject;

        //�@��
        //Mashin = transform.Find("Player").gameObject;

        //UI
        UI = transform.Find("UI").gameObject;

        //�A�C�e��
        //ItemManager = gameObject.Find("ITEMManager").gameObject;

        ItemNm = NON;

    }

    /***********
     Update����
    ************/

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
            Key.HandleKey = RIGHT;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Key.HandleKey = LEFT;
        }
        else
        {
            Key.HandleKey = NULL;
        }
    }

    /**************
     �@�̂Ƃ̒ʐM
    ***************/

    public KEYS KeySend()
    {
        //�e�X�g���O
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
        if(Key.HandleKey == RIGHT)
        {
            Debug.Log("�E");
        }else if(Key.HandleKey == LEFT)
        {
            Debug.Log("��");
        }

        return Key;

    }

    //CP�ʉߎ��̏���


    /**************
     UI�Ƃ̒ʐM
    ***************/

    //UI�ɏ��ʂ𑗂�(�N������-1�ŕ\������)
    public void RankSend()
    {
        //UI.GetComponent<UI>().RankingChange(Rank);
    }

    //UI�ɃA�C�e���𑗂�
    public void ItemSend()
    {
        //�A�C�e���擾�i�f�o�b�O�j
        ItemNm = ItemManager.GetComponent<ItemManager>().RETURN_INUM(1);

        //�A�C�e��������Ȃ炻�̔ԍ��A�Ȃ��Ȃ�-1�𑗂�
        UI.GetComponent<UI>().ITEM_CHANGE(ItemNm);
    }

    /***************
     �V�X�e���Ƃ̒ʐM
    ****************/

    //�������Ɋ���U���Ă��炤(�֐��Ăяo���̓V�X�e����)
    public int InitUser(int nm)
    {
        if(nm != null)
        {
            //�l�G���[
            return 1;
        }

        UserNm = nm;
        return 0;

    }

    //�Q�[�����n�܂�������CP�ʉߎ��ɃV�X�e��������炤
    public void RankSet()
    {
        int NewRank = GMSystem.GetComponent<GMSystem>().RankGet(UserNm);

        //�����N�̕ϓ����Ȃ���΍s��Ȃ�
        if (Rank == NewRank)
        {
            return;
        }

        Rank = NewRank;

        RankSend();
    }

    /******************
     �@�@�G���[�n
    *******************/

    //�G���[�`�F�b�N(0:�ُ�Ȃ� 1:�@�̃G���[ 2:UI�G���[ 3:�V�X�e���G���[)
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
        if (GMSystem == null)
        {
            return 3;
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
        //GMSystem.GetComponent<GMSystem>().ErGet(ErCode);

    }

}
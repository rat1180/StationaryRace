using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //�A�C�e���̒萔�l���g�����߂ɋL��.

public class ItemManager : MonoBehaviour
{
    private int USER_NUMBER; //���[�U�ԍ������锠
    private int USER_ALL = 8;//���[�U�̑��������锠
    private Vector3 Rocket; //�v���C���[�̈ʒu���擾
    private Vector3 RocketA;//�v���C���[�̌���̈ʒu���擾
    private Vector3 RocketB;//�v���C���[�̑O���̈ʒu���擾
    private Quaternion RocketBQ;
    private Quaternion RocketAQ;
    GameObject R; //�v���C���[�̈ʒu���擾
    GameObject RA;
    GameObject RB;
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;
    GameObject ItemUI;
    GameObject INDIA_INK;
    INDIA_INK InkSc;

    //�A�C�e���̃Q�[���I�u�W�F�N�g�錾
    public GameObject ERASER_RESIDDUE;
    public GameObject BLACKBOARD_ERASER;
    public GameObject KESHIKASU_BOM;
    public GameObject MECHANICAL_PEN_LEAD;
    public GameObject STICKY_NOTE;
    public GameObject TAPE_BALL;
    public GameObject SCOTCH_TAPE;
    public GameObject MAGIC_PEN;
    public GameObject CARDBOARD;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Car");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.

        ItemUI = transform.GetChild(0).gameObject;
        INDIA_INK = ItemUI.GetComponent<Transform>().transform.GetChild(0).gameObject;

        InkSc= INDIA_INK.GetComponent<INDIA_INK>();
        R = GameObject.Find("Car");//�v���C���[�̍��W���擾
        RA = GameObject.Find("ItemRocketA");//�A�C�e�����P�b�g�̍��W���擾(A��After)
        RB = GameObject.Find("ItemRocketB");//�A�C�e�����P�b�g�̍��W���擾(B��Before)
    }

    // Update is called once per frame
    void Update()
    {
        Rocket = R.transform.position;
        RocketA = RA.transform.position;
        RocketB = RB.transform.position;
        RocketAQ = RA.transform.rotation;
        RocketBQ = RB.transform.rotation;
    }

    //itemblock���j�󂳂ꂽ�ۂɂ�����Ă�.
    public void Item()
    {
        int ItemNum = Random.Range(ITEMConst.ITEM.ItemMin, ITEMConst.ITEM.ItemMax);//�����_���Ȑ����l���Ԃ�(int�^���ƌ��͏��O�����).
        //�A�C�e�����Ƃ̏���.
        switch (ItemNum)
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://�����J�X.
                Debug.Log("ERASER_RESIDDUE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.ERASER_RESIDDUE;
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://�P�V�J�X���e.
                Debug.Log("KESHIKASU_BOM!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.KESHIKASU_BOM;
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://������.
                Debug.Log("BLACKBOARD_ERASER!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.BLACKBOARD_ERASER;
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://�V���[�c.
                Debug.Log("MECHANICAL_PEN_LEAD!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.MECHANICAL_PEN_LEAD;
                break;
            case ITEMConst.ITEM.STICKY_NOTE://�t�.
                Debug.Log("STICKY_NOTE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.STICKY_NOTE;
                break;
            case ITEMConst.ITEM.TAPE_BALL://�ۂ߂��e�[�v.
                Debug.Log("TAPE_BALL!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.TAPE_BALL;
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://�Z���n���e�[�v.
                Debug.Log("SCOTCH_TAPE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.SCOTCH_TAPE;
                break;
            case ITEMConst.ITEM.MAGIC_PEN://�}�W�b�N�y��.
                Debug.Log("MAGIC_PEN!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.MAGIC_PEN;
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://�߂̐܂莆.
                Debug.Log("ORIGAMI_CRANE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.ORIGAMI_CRANE;
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://�r���r���y��.
                Debug.Log("BIRIBIRI_PEN!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.BIRIBIRI_PEN;
                break;
            case ITEMConst.ITEM.INDIA_INK://�n�`.
                Debug.Log("INDIA_INK!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.INDIA_INK;
                break;
            case ITEMConst.ITEM.CARDBOARD://�i�{�[��.
                Debug.Log("CARDBOARD!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.CARDBOARD;
                break;
            default:
                break;
        }
    }

    public void Item_Use(int USER_ITEM)//Player���A�C�e�����g�p�����ۂɂ�����Ă�.
    {
        //�A�C�e�����Ƃ̏���.
        switch (USER_ITEM)
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://�����J�X.
                Debug.Log("USE:ERASER_RESIDDUE!");
                Instantiate(ERASER_RESIDDUE, RocketA, Quaternion.Euler(90, 0, 0));
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://�P�V�J�X���e.
                Debug.Log("USE:KESHIKASU_BOM!");
                Instantiate(KESHIKASU_BOM, RocketB, RocketBQ);//�P�V�J�X�̃v���t�@�u���g���܂킷
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://������.
                Debug.Log("USE:BLACKBOARD_ERASER!");
                RocketA.y += 5;
                Instantiate(BLACKBOARD_ERASER, RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://�V���[�c.
                RocketB.y += 5;
                Instantiate(MECHANICAL_PEN_LEAD, RocketB, RocketBQ);
                Debug.Log("USE:MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://�t�.
                Debug.Log("USE:STICKY_NOTE!");
                //Rocket.y += 10;
                Instantiate(STICKY_NOTE, RocketB, RocketBQ);
                break;
            case ITEMConst.ITEM.TAPE_BALL://�ۂ߂��e�[�v.
                Debug.Log("USE:TAPE_BALL!");
                Instantiate(TAPE_BALL, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://�Z���n���e�[�v.
                Debug.Log("USE:SCOTCH_TAPE!");
                Instantiate(SCOTCH_TAPE, RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MAGIC_PEN://�}�W�b�N�y��.
                Debug.Log("USE:MAGIC_PEN!");
                //Instantiate(MAGIC_PEN, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://�߂̐܂莆.
                Debug.Log("USE:ORIGAMI_CRANE!");
                CarSc.ORIGAMI_CHANGE();
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://�r���r���y��.
                Debug.Log("USE:BIRIBIRI_PEN!");
                //CarSc.Pos.y += 10f;
                CarSc.BIRIBIRI_PEN();
                break;
            case ITEMConst.ITEM.INDIA_INK://�n�`.
                Debug.Log("USE:INDIA_INK!");
                InkSc.Animation();
                break;
            case ITEMConst.ITEM.CARDBOARD://�i�{�[��.
                Debug.Log("USE:CARDBOARD!");
                RocketA.y += 5;
                Instantiate(CARDBOARD, RocketA, Quaternion.identity);
                break;
            default:
                break;
        }
        CarSc.ITEM_NUM = ITEMConst.ITEM.ItemNull;//�A�C�e�����g�p�i��ɂ���j
    }


    #region ���[�U�[�ԍ��n
    //�N�����Ƀ��[�U�[�̐����擾����֐��@�Q�[���}�l�[�W���[����擾
    public void USER_TOTAL(int num)
    {
        USER_ALL = num;
    }

    //���[�U�[�ԍ����擾����֐�
    public void USER_NUM(int num)
    {
        USER_NUMBER = num;
    }
    //���[�U�[�ԍ��������ɃA�C�e���i���o�[��Ԃ��֐�
    //public int RETURN_INUM(int USER_NUM)
    //{
    //    return USER_HAVE[USER_NUMBER, 1];
    //}

    //���[�U�[�ԍ��������ɃA�C�e���i���o�[��Ԃ��֐�

    public int RETURN_INUM(int USER_NUM)
    {
        return CarSc.ITEM_NUM;
    }
    #endregion

}

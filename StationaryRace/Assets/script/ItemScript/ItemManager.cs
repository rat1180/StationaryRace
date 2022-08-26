using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //�A�C�e���̒萔�l���g�����߂ɋL��.

public class ItemManager : MonoBehaviour
{
    private int USER_NUMBER; //���[�U�ԍ������锠
    private int USER_ALL = 8;//���[�U�̑��������锠

    #region �A�C�e�����˂̈ʒu�E��]�擾
    //start��find�擾���邽�߂̐錾
    GameObject RA;//�v���C���[�̌���ʒu�擾
    GameObject RB;//�v���C���[�̑O���ʒu�擾
    GameObject RR;//�v���C���[�̉E���ʒu�擾
    //update�ŏ�ɏ���������
    private Vector3 Rocket;      //�v���C���[�̈ʒu���擾
    private Vector3 RocketA;     //�v���C���[�̌���̈ʒu���擾
    private Vector3 RocketB;     //�v���C���[�̑O���̈ʒu���擾
    private Quaternion RocketBQ; //�v���C���[�̑O���̉�]���擾
    private Quaternion RocketAQ; //�v���C���[�̑O���̉�]���擾
    private Vector3 RocketR;     //�v���C���[�̉E���̈ʒu���擾
    private Quaternion RocketRQ; //�v���C���[�E�̉�]���擾
    #endregion

    #region �X�N���v�g�Q�Ƃ̏���
    GameObject Player;   //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;           //Car�̃X�N���v�g���擾���鏀��.
    GameObject ItemUI;   //ItemUI�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    GameObject INDIA_INK;//INDIA_INK�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    INDIA_INK InkSc;     //INDIA_INK�̃X�N���v�g���擾���鏀��.
    #endregion

    public GameObject InkConlore;

    //�A�C�e���̃Q�[���I�u�W�F�N�g�錾
    //public GameObject ERASER_RESIDDUE;
    //public GameObject BLACKBOARD_ERASER;
    //public GameObject KESHIKASU_BOM;
    //public GameObject MECHANICAL_PEN_LEAD;
    //public GameObject STICKY_NOTE;
    //public GameObject TAPE_BALL;
    //public GameObject SCOTCH_TAPE;
    //public GameObject MAGIC_PEN;
    //public GameObject CARDBOARD;
    //public GameObject CARDBOARD_WALL;

    /// <summary>
    /// �A�C�e���̃v���t�@�u���i�[���Ă���z��
    /// 0�������J�X�@1�������� 2���P�V�J�X���e 3���V���[�c�@4���ӂ���@5���e�[�v�{�[��
    /// 6���Z���n�� 7���}�W�b�N�y�� 8�� �i�{�[�� 9���i�{�[���̕�
    /// </summary>
    public GameObject[] ItemPrefabs = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Car");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.

        ItemUI = transform.GetChild(0).gameObject;
        INDIA_INK = ItemUI.GetComponent<Transform>().transform.GetChild(0).gameObject;

        InkSc= INDIA_INK.GetComponent<INDIA_INK>();
        RA = GameObject.Find("ItemRocketA");//�A�C�e�����P�b�g�̍��W���擾(A��After)
        RB = GameObject.Find("ItemRocketB");//�A�C�e�����P�b�g�̍��W���擾(B��Before)
        RR = GameObject.Find("ItemRocketR");//�A�C�e�����P�b�g�̍��W���擾(R��Right)
    }

    // Update is called once per frame
    void Update()
    {
        #region �v���C���[�̔��ˈʒu�E��]�̎擾
        RocketA = RA.transform.position;//�v���C���[�̌�����ʒu���擾.
        RocketB = RB.transform.position;//�v���C���[�̑O���ʒu���擾.
        RocketAQ = RA.transform.rotation;//�v���C���[�̌����]���擾.
        RocketBQ = RB.transform.rotation;//�v���C���[�̑O����]���擾.
        RocketR = RR.transform.position;//�v���C���[�̉E���ʒu���擾.
        RocketRQ = RR.transform.rotation;//�v���C���[�̉E����]���擾.
        #endregion
    }
    /// <summary>
    /// itemblock���j�󂳂ꂽ�ۂɂ�����Ă�
    /// CarSc�Œ�`���Ă���ITEM_NUM�ɃA�C�e���ԍ��������鏈�����s��
    /// </summary>
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
            case ITEMConst.ITEM.CARDBOARD_WALL://�i�{�[���̕�.
                Debug.Log("CARDBOARD_WALL!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.CARDBOARD_WALL;
                break;
            default:
                print("ha?");
                break;
        }
    }
    /// <summary>
    /// Player���A�C�e�����g�p�����ۂɂ�����Ă�
    /// CarSc��������ŃA�C�e���ԍ��������Ă���̂ŁA���̔ԍ��ɂ���ď����𕪊򂳂���
    /// </summary>
    /// <param name="USER_ITEM"></param>
    public void Item_Use(int USER_ITEM)
    {
        //�A�C�e�����Ƃ̏���.
        switch (USER_ITEM)
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://�����J�X.
                Debug.Log("USE:ERASER_RESIDDUE!");
                Instantiate(ItemPrefabs[0], RocketA, Quaternion.Euler(90, 0, 0));
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://�P�V�J�X���e.
                Debug.Log("USE:KESHIKASU_BOM!");
                Instantiate(ItemPrefabs[2], RocketB, RocketBQ);//�P�V�J�X�̃v���t�@�u���g���܂킷
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://������.
                Debug.Log("USE:BLACKBOARD_ERASER!");
                RocketA.y += 5;
                Instantiate(ItemPrefabs[1], RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://�V���[�c.
                Instantiate(ItemPrefabs[3], RocketR, RocketRQ);
                Debug.Log("USE:MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://�t�.
                Debug.Log("USE:STICKY_NOTE!");
                //Rocket.y += 10;
                Instantiate(ItemPrefabs[4], RocketB, RocketBQ);
                break;
            case ITEMConst.ITEM.TAPE_BALL://�ۂ߂��e�[�v.
                Debug.Log("USE:TAPE_BALL!");
                Instantiate(ItemPrefabs[5], RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://�Z���n���e�[�v.
                Debug.Log("USE:SCOTCH_TAPE!");
                Instantiate(ItemPrefabs[6], RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MAGIC_PEN://�}�W�b�N�y��.
                Debug.Log("USE:MAGIC_PEN!");
                Instantiate(ItemPrefabs[7], RocketR, RocketRQ);
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://�߂̐܂莆.
                Debug.Log("USE:ORIGAMI_CRANE!");
                CarSc.ORIGAMI_CHANGE();
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://�r���r���y��.
                Debug.Log("USE:BIRIBIRI_PEN!");
                CarSc.BIRIBIRI_PEN();
                break;
            case ITEMConst.ITEM.INDIA_INK://�n�`.
                Debug.Log("USE:INDIA_INK!");
                INK();
                break;
            case ITEMConst.ITEM.CARDBOARD://�i�{�[��.
                Debug.Log("USE:CARDBOARD!");
                Instantiate(ItemPrefabs[8], RocketA, Quaternion.identity);
                break;
            case ITEMConst.ITEM.CARDBOARD_WALL://�i�{�[���̕�.
                Debug.Log("USE:CARDBOARD_WALL!");
                RocketA.y += 3;
                Instantiate(ItemPrefabs[9], RocketA, RocketAQ);
                break;
            default:
                break;
        }
        CarSc.ITEM_NUM = ITEMConst.ITEM.ItemNull;//�A�C�e�����g�p�i��ɂ���j
    }

    public void INK()
    {
        //InkSc.Animation();
        Instantiate(InkConlore, RocketA, RocketAQ);
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

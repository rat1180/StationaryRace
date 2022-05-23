using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //�A�C�e���̒萔�l���g�����߂ɋL��.

public class ItemManager : MonoBehaviour
{
    public int USER_NUMBER; //���[�U�ԍ������锠
    private int USER_ALL = 8;//���[�U�̑��������锠
    private int[,] USER_HAVE = new int[10, 2];//���[�U�ԍ��Ǝ����Ă���A�C�e��������
    public Vector3 Player; //�v���C���[�̈ʒu���擾

    //�A�C�e���̃Q�[���I�u�W�F�N�g�錾
    public GameObject ENPITU;
    public GameObject ERASER_RESIDDUE;
    public GameObject BLACKBOARD_ERASER;
    public GameObject MECHANICAL_PEN_LEAD;
    public GameObject STICKY_NOTE;
    public GameObject TAPE_BALL;
    public GameObject SCOTCH_TAPE;
    public GameObject MAGIC_PEN;
    public GameObject ORIGAMI_CRANE;
    public GameObject BIRIBIRI_PEN;
    public GameObject INDIA_INK;
    public GameObject CARDBOARD;

    // Start is called before the first frame update
    void Start()
    {
        //�A�C�e���̏�������z��̏�����
        for(int i = 1; i < USER_ALL + 1; i++)
        {
            USER_HAVE[i,0] = i;
            USER_HAVE[i, 1] = ITEMConst.ITEM.ItemNull;//�S�Ẵ��[�U�̃A�C�e�����k��(-1)�Ŗ��߂�
        }
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Car").transform.position;//�v���C���[�̍��W���擾
    }

    public void Item(int USER_NUM,int ITEMNUM)//itemblock���j�󂳂ꂽ�ۂɂ�����Ă�.
    {
        //�A�C�e�����Ƃ̏���.
        switch (ITEMNUM)
        {
            case ITEMConst.ITEM.ENPITU://����҂�.
                Debug.Log("ENPITU!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.ENPITU;
                break;
            case ITEMConst.ITEM.ERASER_RESIDDUE://�����J�X.
                Debug.Log("ERASER_RESIDDUE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.ERASER_RESIDDUE;
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://�P�V�J�X���e.
                Debug.Log("KESHIKASU_BOM!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.KESHIKASU_BOM;
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://������.
                Debug.Log("BLACKBOARD_ERASER!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.BLACKBOARD_ERASER;
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://�V���[�c.
                Debug.Log("MECHANICAL_PEN_LEAD!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.MECHANICAL_PEN_LEAD;
                break;
            case ITEMConst.ITEM.STICKY_NOTE://�t�.
                Debug.Log("STICKY_NOTE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.STICKY_NOTE;
                break;
            case ITEMConst.ITEM.TAPE_BALL://�ۂ߂��e�[�v.
                Debug.Log("TAPE_BALL!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.TAPE_BALL;
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://�Z���n���e�[�v.
                Debug.Log("SCOTCH_TAPE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.SCOTCH_TAPE;
                break;
            case ITEMConst.ITEM.MAGIC_PEN://�}�W�b�N�y��.
                Debug.Log("MAGIC_PEN!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.MAGIC_PEN;
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://�߂̐܂莆.
                Debug.Log("ORIGAMI_CRANE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.ORIGAMI_CRANE;
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://�r���r���y��.
                Debug.Log("BIRIBIRI_PEN!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.BIRIBIRI_PEN;
                break;
            case ITEMConst.ITEM.INDIA_INK://�n�`.
                Debug.Log("INDIA_INK!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.INDIA_INK;
                break;
            case ITEMConst.ITEM.CARDBOARD://�i�{�[��.
                Debug.Log("CARDBOARD!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.CARDBOARD;
                break;
            default:
                break;
        }
        //Debug.Log(USER_HAVE[USER_NUM, 1]);
    }

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
        return USER_HAVE[USER_NUMBER, 1];
    }

    public void Item_Use(int User_NUM)//Player���A�C�e�����g�p�����ۂɂ�����Ă�.
    {
        //Debug.Log(USER_HAVE[User_NUM, 1]);
        //�A�C�e�����Ƃ̏���.
        switch (USER_HAVE[User_NUM, 1])
        {
            case ITEMConst.ITEM.ENPITU://����҂�.
                Debug.Log("USE:ENPITU!");
                break;
            case ITEMConst.ITEM.ERASER_RESIDDUE://�����J�X.
                Debug.Log("USE:ERASER_RESIDDUE!");
                Player.z -= 1;
                Instantiate(ERASER_RESIDDUE, Player, Quaternion.identity);
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://�P�V�J�X���e.
                Debug.Log("USE:KESHIKASU_BOM!");
                for(int i=0; i < 500; i++)
                {
                    Player.x += Random.Range(-5, 5);
                    Player.y += Random.Range(1, 10);
                    Player.z += Random.Range(-5, 5);
                  Instantiate(ERASER_RESIDDUE, Player, Quaternion.identity);//�P�V�J�X�̃v���t�@�u���g���܂킷
                }
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://������.
                Debug.Log("USE:BLACKBOARD_ERASER!");
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://�V���[�c.
                Player.z = Player.z + 3;
                Instantiate(MECHANICAL_PEN_LEAD, Player, Quaternion.identity);
                Debug.Log("USE:MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://�t�.
                Debug.Log("USE:STICKY_NOTE!");
                Player.z += 5;
                Player.y += 3;
                Instantiate(STICKY_NOTE, Player, Quaternion.identity);
                break;
            case ITEMConst.ITEM.TAPE_BALL://�ۂ߂��e�[�v.
                Debug.Log("USE:TAPE_BALL!");
                Player.z += 3;
                Instantiate(TAPE_BALL, Player, Quaternion.identity);
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://�Z���n���e�[�v.
                Debug.Log("USE:SCOTCH_TAPE!");
                break;
            case ITEMConst.ITEM.MAGIC_PEN://�}�W�b�N�y��.
                Debug.Log("USE:MAGIC_PEN!");
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://�߂̐܂莆.
                Debug.Log("USE:ORIGAMI_CRANE!");
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://�r���r���y��.
                Debug.Log("USE:BIRIBIRI_PEN!");
                break;
            case ITEMConst.ITEM.INDIA_INK://�n�`.
                Debug.Log("USE:INDIA_INK!");
                break;
            case ITEMConst.ITEM.CARDBOARD://�i�{�[��.
                Debug.Log("USE:CARDBOARD!");
                Player.z = Player.z - 3;
                //Debug.Log("Player:" + Player);
                Instantiate(CARDBOARD, Player, Quaternion.identity);
                break;
            default:
                break;
        }
        USER_HAVE[USER_NUMBER, 1] = ITEMConst.ITEM.ItemNull;//�A�C�e�����g�p�i��ɂ���j
        //Debug.Log(USER_HAVE[USER_NUMBER, 1]);
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //�A�C�e���̒萔�l���g�����߂ɋL��

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Item(int ITEMNUM)//itemblock���j�󂳂ꂽ�ۂɂ�����Ă�
    {
        //�A�C�e�����Ƃ̏���
        switch (ITEMNUM)
        {
            case ITEMConst.ITEM.ENPITU://����҂�
                Debug.Log("ENPITU!");
                break;
            case ITEMConst.ITEM.ERASER_RESIDDUE://�����J�X
                Debug.Log("ERASER_RESIDDUE!");
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://������
                Debug.Log("ITEM.BLACKBOARD_ERASER!");
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://�V���[�c
                Debug.Log("MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://�t�
                Debug.Log("STICKY_NOTE!");
                break;
            case ITEMConst.ITEM.TAPE_BALL://�ۂ߂��e�[�v
                Debug.Log("TAPE_BALL!");
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://�Z���n���e�[�v
                Debug.Log("SCOTCH_TAPE!");
                break;
            case ITEMConst.ITEM.MAGIC_PEN://�}�W�b�N�y��
                Debug.Log("MAGIC_PEN!");
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://�߂̐܂莆
                Debug.Log("ORIGAMI_CRANE!");
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://�r���r���y��
                Debug.Log("BIRIBIRI_PEN!");
                break;
            case ITEMConst.ITEM.INDIA_INK://�n�`
                Debug.Log("INDIA_INK!");
                break;
            default:
                break;
        }
    }
}

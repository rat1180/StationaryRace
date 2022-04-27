using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数値を使うために記入

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
    public void Item(int ITEMNUM)//itemblockが破壊された際にこれを呼ぶ
    {
        //アイテムごとの処理
        switch (ITEMNUM)
        {
            case ITEMConst.ITEM.ENPITU://えんぴつ
                Debug.Log("ENPITU!");
                break;
            case ITEMConst.ITEM.ERASER_RESIDDUE://消しカス
                Debug.Log("ERASER_RESIDDUE!");
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://黒板けし
                Debug.Log("ITEM.BLACKBOARD_ERASER!");
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://シャー芯
                Debug.Log("MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://付箋
                Debug.Log("STICKY_NOTE!");
                break;
            case ITEMConst.ITEM.TAPE_BALL://丸めたテープ
                Debug.Log("TAPE_BALL!");
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://セロハンテープ
                Debug.Log("SCOTCH_TAPE!");
                break;
            case ITEMConst.ITEM.MAGIC_PEN://マジックペン
                Debug.Log("MAGIC_PEN!");
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://鶴の折り紙
                Debug.Log("ORIGAMI_CRANE!");
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://ビリビリペン
                Debug.Log("BIRIBIRI_PEN!");
                break;
            case ITEMConst.ITEM.INDIA_INK://墨汁
                Debug.Log("INDIA_INK!");
                break;
            default:
                break;
        }
    }
}

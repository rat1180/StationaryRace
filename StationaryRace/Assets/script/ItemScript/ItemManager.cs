using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数値を使うために記入.

public class ItemManager : MonoBehaviour
{
    private int USER_NUMBER; //ユーザ番号を入れる箱
    private int USER_ALL = 8;//ユーザの総数を入れる箱
    private Vector3 Rocket; //プレイヤーの位置を取得
    private Vector3 RocketA;//プレイヤーの後方の位置を取得
    private Vector3 RocketB;//プレイヤーの前方の位置を取得
    private Quaternion RocketBQ;
    private Quaternion RocketAQ;
    GameObject R; //プレイヤーの位置を取得
    GameObject RA;
    GameObject RB;
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;
    GameObject ItemUI;
    GameObject INDIA_INK;
    INDIA_INK InkSc;

    //アイテムのゲームオブジェクト宣言
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
        Player = GameObject.Find("Car");         //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.

        ItemUI = transform.GetChild(0).gameObject;
        INDIA_INK = ItemUI.GetComponent<Transform>().transform.GetChild(0).gameObject;

        InkSc= INDIA_INK.GetComponent<INDIA_INK>();
        R = GameObject.Find("Car");//プレイヤーの座標を取得
        RA = GameObject.Find("ItemRocketA");//アイテムロケットの座標を取得(AはAfter)
        RB = GameObject.Find("ItemRocketB");//アイテムロケットの座標を取得(BはBefore)
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

    //itemblockが破壊された際にこれを呼ぶ.
    public void Item()
    {
        int ItemNum = Random.Range(ITEMConst.ITEM.ItemMin, ITEMConst.ITEM.ItemMax);//ランダムな整数値が返る(int型だと後ろは除外される).
        //アイテムごとの処理.
        switch (ItemNum)
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://消しカス.
                Debug.Log("ERASER_RESIDDUE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.ERASER_RESIDDUE;
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://ケシカス爆弾.
                Debug.Log("KESHIKASU_BOM!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.KESHIKASU_BOM;
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://黒板けし.
                Debug.Log("BLACKBOARD_ERASER!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.BLACKBOARD_ERASER;
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://シャー芯.
                Debug.Log("MECHANICAL_PEN_LEAD!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.MECHANICAL_PEN_LEAD;
                break;
            case ITEMConst.ITEM.STICKY_NOTE://付箋.
                Debug.Log("STICKY_NOTE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.STICKY_NOTE;
                break;
            case ITEMConst.ITEM.TAPE_BALL://丸めたテープ.
                Debug.Log("TAPE_BALL!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.TAPE_BALL;
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://セロハンテープ.
                Debug.Log("SCOTCH_TAPE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.SCOTCH_TAPE;
                break;
            case ITEMConst.ITEM.MAGIC_PEN://マジックペン.
                Debug.Log("MAGIC_PEN!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.MAGIC_PEN;
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://鶴の折り紙.
                Debug.Log("ORIGAMI_CRANE!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.ORIGAMI_CRANE;
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://ビリビリペン.
                Debug.Log("BIRIBIRI_PEN!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.BIRIBIRI_PEN;
                break;
            case ITEMConst.ITEM.INDIA_INK://墨汁.
                Debug.Log("INDIA_INK!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.INDIA_INK;
                break;
            case ITEMConst.ITEM.CARDBOARD://段ボール.
                Debug.Log("CARDBOARD!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.CARDBOARD;
                break;
            default:
                break;
        }
    }

    public void Item_Use(int USER_ITEM)//Playerがアイテムを使用した際にこれを呼ぶ.
    {
        //アイテムごとの処理.
        switch (USER_ITEM)
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://消しカス.
                Debug.Log("USE:ERASER_RESIDDUE!");
                Instantiate(ERASER_RESIDDUE, RocketA, Quaternion.Euler(90, 0, 0));
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://ケシカス爆弾.
                Debug.Log("USE:KESHIKASU_BOM!");
                Instantiate(KESHIKASU_BOM, RocketB, RocketBQ);//ケシカスのプレファブを使いまわす
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://黒板けし.
                Debug.Log("USE:BLACKBOARD_ERASER!");
                RocketA.y += 5;
                Instantiate(BLACKBOARD_ERASER, RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://シャー芯.
                RocketB.y += 5;
                Instantiate(MECHANICAL_PEN_LEAD, RocketB, RocketBQ);
                Debug.Log("USE:MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://付箋.
                Debug.Log("USE:STICKY_NOTE!");
                //Rocket.y += 10;
                Instantiate(STICKY_NOTE, RocketB, RocketBQ);
                break;
            case ITEMConst.ITEM.TAPE_BALL://丸めたテープ.
                Debug.Log("USE:TAPE_BALL!");
                Instantiate(TAPE_BALL, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://セロハンテープ.
                Debug.Log("USE:SCOTCH_TAPE!");
                Instantiate(SCOTCH_TAPE, RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MAGIC_PEN://マジックペン.
                Debug.Log("USE:MAGIC_PEN!");
                //Instantiate(MAGIC_PEN, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://鶴の折り紙.
                Debug.Log("USE:ORIGAMI_CRANE!");
                CarSc.ORIGAMI_CHANGE();
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://ビリビリペン.
                Debug.Log("USE:BIRIBIRI_PEN!");
                //CarSc.Pos.y += 10f;
                CarSc.BIRIBIRI_PEN();
                break;
            case ITEMConst.ITEM.INDIA_INK://墨汁.
                Debug.Log("USE:INDIA_INK!");
                InkSc.Animation();
                break;
            case ITEMConst.ITEM.CARDBOARD://段ボール.
                Debug.Log("USE:CARDBOARD!");
                RocketA.y += 5;
                Instantiate(CARDBOARD, RocketA, Quaternion.identity);
                break;
            default:
                break;
        }
        CarSc.ITEM_NUM = ITEMConst.ITEM.ItemNull;//アイテムを使用（空にする）
    }


    #region ユーザー番号系
    //起動時にユーザーの数を取得する関数　ゲームマネージャーから取得
    public void USER_TOTAL(int num)
    {
        USER_ALL = num;
    }

    //ユーザー番号を取得する関数
    public void USER_NUM(int num)
    {
        USER_NUMBER = num;
    }
    //ユーザー番号を引数にアイテムナンバーを返す関数
    //public int RETURN_INUM(int USER_NUM)
    //{
    //    return USER_HAVE[USER_NUMBER, 1];
    //}

    //ユーザー番号を引数にアイテムナンバーを返す関数

    public int RETURN_INUM(int USER_NUM)
    {
        return CarSc.ITEM_NUM;
    }
    #endregion

}

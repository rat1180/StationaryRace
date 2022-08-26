using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数値を使うために記入.

public class ItemManager : MonoBehaviour
{
    private int USER_NUMBER; //ユーザ番号を入れる箱
    private int USER_ALL = 8;//ユーザの総数を入れる箱

    #region アイテム発射の位置・回転取得
    //startでfind取得するための宣言
    GameObject RA;//プレイヤーの後方位置取得
    GameObject RB;//プレイヤーの前方位置取得
    GameObject RR;//プレイヤーの右方位置取得
    //updateで常に書き換える
    private Vector3 Rocket;      //プレイヤーの位置を取得
    private Vector3 RocketA;     //プレイヤーの後方の位置を取得
    private Vector3 RocketB;     //プレイヤーの前方の位置を取得
    private Quaternion RocketBQ; //プレイヤーの前方の回転を取得
    private Quaternion RocketAQ; //プレイヤーの前方の回転を取得
    private Vector3 RocketR;     //プレイヤーの右方の位置を取得
    private Quaternion RocketRQ; //プレイヤー右の回転を取得
    #endregion

    #region スクリプト参照の準備
    GameObject Player;   //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;           //Carのスクリプトを取得する準備.
    GameObject ItemUI;   //ItemUIのゲームオブジェクトを取得する準備.
    GameObject INDIA_INK;//INDIA_INKのゲームオブジェクトを取得する準備.
    INDIA_INK InkSc;     //INDIA_INKのスクリプトを取得する準備.
    #endregion

    public GameObject InkConlore;

    //アイテムのゲームオブジェクト宣言
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
    /// アイテムのプレファブを格納している配列
    /// 0→消しカス　1→黒板けし 2→ケシカス爆弾 3→シャー芯　4→ふせん　5→テープボール
    /// 6→セロハン 7→マジックペン 8→ 段ボール 9→段ボールの壁
    /// </summary>
    public GameObject[] ItemPrefabs = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Car");         //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.

        ItemUI = transform.GetChild(0).gameObject;
        INDIA_INK = ItemUI.GetComponent<Transform>().transform.GetChild(0).gameObject;

        InkSc= INDIA_INK.GetComponent<INDIA_INK>();
        RA = GameObject.Find("ItemRocketA");//アイテムロケットの座標を取得(AはAfter)
        RB = GameObject.Find("ItemRocketB");//アイテムロケットの座標を取得(BはBefore)
        RR = GameObject.Find("ItemRocketR");//アイテムロケットの座標を取得(RはRight)
    }

    // Update is called once per frame
    void Update()
    {
        #region プレイヤーの発射位置・回転の取得
        RocketA = RA.transform.position;//プレイヤーの後方方位置を取得.
        RocketB = RB.transform.position;//プレイヤーの前方位置を取得.
        RocketAQ = RA.transform.rotation;//プレイヤーの後方回転を取得.
        RocketBQ = RB.transform.rotation;//プレイヤーの前方回転を取得.
        RocketR = RR.transform.position;//プレイヤーの右方位置を取得.
        RocketRQ = RR.transform.rotation;//プレイヤーの右方回転を取得.
        #endregion
    }
    /// <summary>
    /// itemblockが破壊された際にこれを呼ぶ
    /// CarScで定義しているITEM_NUMにアイテム番号を代入する処理を行う
    /// </summary>
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
            case ITEMConst.ITEM.CARDBOARD_WALL://段ボールの壁.
                Debug.Log("CARDBOARD_WALL!");
                CarSc.ITEM_NUM = ITEMConst.ITEM.CARDBOARD_WALL;
                break;
            default:
                print("ha?");
                break;
        }
    }
    /// <summary>
    /// Playerがアイテムを使用した際にこれを呼ぶ
    /// CarScから引数でアイテム番号が送られてくるので、その番号によって処理を分岐させる
    /// </summary>
    /// <param name="USER_ITEM"></param>
    public void Item_Use(int USER_ITEM)
    {
        //アイテムごとの処理.
        switch (USER_ITEM)
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://消しカス.
                Debug.Log("USE:ERASER_RESIDDUE!");
                Instantiate(ItemPrefabs[0], RocketA, Quaternion.Euler(90, 0, 0));
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://ケシカス爆弾.
                Debug.Log("USE:KESHIKASU_BOM!");
                Instantiate(ItemPrefabs[2], RocketB, RocketBQ);//ケシカスのプレファブを使いまわす
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://黒板けし.
                Debug.Log("USE:BLACKBOARD_ERASER!");
                RocketA.y += 5;
                Instantiate(ItemPrefabs[1], RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://シャー芯.
                Instantiate(ItemPrefabs[3], RocketR, RocketRQ);
                Debug.Log("USE:MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://付箋.
                Debug.Log("USE:STICKY_NOTE!");
                //Rocket.y += 10;
                Instantiate(ItemPrefabs[4], RocketB, RocketBQ);
                break;
            case ITEMConst.ITEM.TAPE_BALL://丸めたテープ.
                Debug.Log("USE:TAPE_BALL!");
                Instantiate(ItemPrefabs[5], RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://セロハンテープ.
                Debug.Log("USE:SCOTCH_TAPE!");
                Instantiate(ItemPrefabs[6], RocketA, RocketAQ);
                break;
            case ITEMConst.ITEM.MAGIC_PEN://マジックペン.
                Debug.Log("USE:MAGIC_PEN!");
                Instantiate(ItemPrefabs[7], RocketR, RocketRQ);
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://鶴の折り紙.
                Debug.Log("USE:ORIGAMI_CRANE!");
                CarSc.ORIGAMI_CHANGE();
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://ビリビリペン.
                Debug.Log("USE:BIRIBIRI_PEN!");
                CarSc.BIRIBIRI_PEN();
                break;
            case ITEMConst.ITEM.INDIA_INK://墨汁.
                Debug.Log("USE:INDIA_INK!");
                INK();
                break;
            case ITEMConst.ITEM.CARDBOARD://段ボール.
                Debug.Log("USE:CARDBOARD!");
                Instantiate(ItemPrefabs[8], RocketA, Quaternion.identity);
                break;
            case ITEMConst.ITEM.CARDBOARD_WALL://段ボールの壁.
                Debug.Log("USE:CARDBOARD_WALL!");
                RocketA.y += 3;
                Instantiate(ItemPrefabs[9], RocketA, RocketAQ);
                break;
            default:
                break;
        }
        CarSc.ITEM_NUM = ITEMConst.ITEM.ItemNull;//アイテムを使用（空にする）
    }

    public void INK()
    {
        //InkSc.Animation();
        Instantiate(InkConlore, RocketA, RocketAQ);
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

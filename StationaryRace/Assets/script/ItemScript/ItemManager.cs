using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数値を使うために記入.

public class ItemManager : MonoBehaviour
{
    private int USER_NUMBER; //ユーザ番号を入れる箱
    private int USER_ALL = 8;//ユーザの総数を入れる箱
    private int[,] USER_HAVE = new int[10, 2];//ユーザ番号と持っているアイテムを入れる
    private Vector3 Rocket; //プレイヤーの位置を取得
    private Vector3 RocketA;
    private Vector3 RocketB;
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;


    //アイテムのゲームオブジェクト宣言
    public GameObject ERASER_RESIDDUE;
    public GameObject BLACKBOARD_ERASER;
    public GameObject KESHIKASU_BOM;
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
        Player = GameObject.Find("Car");         //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.
        //アイテムの情報を入れる配列の初期化
        for (int i = 1; i < USER_ALL + 1; i++)
        {
            USER_HAVE[i,0] = i;
            USER_HAVE[i, 1] = ITEMConst.ITEM.ItemNull;//全てのユーザのアイテムをヌル(-1)で埋める
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rocket = GameObject.Find("Car").transform.position;//プレイヤーの座標を取得
        RocketA = GameObject.Find("ItemRocketA").transform.position;//アイテムロケットの座標を取得(AはAfter)
        RocketB = GameObject.Find("ItemRocketB").transform.position;//アイテムロケットの座標を取得(BはBefore)
        //Player = GameObject.Find("Car").transform.forward;
    }

    //itemblockが破壊された際にこれを呼ぶ.
    public void Item(int USER_NUM)
    {
        //int ItemNum = Random.Range(105, 106);
        int ItemNum = Random.Range(ITEMConst.ITEM.ItemMin, ITEMConst.ITEM.ItemMax);//ランダムな整数値が返る(int型だと後ろは除外される).
        //アイテムごとの処理.
        switch (ItemNum)
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://消しカス.
                Debug.Log("ERASER_RESIDDUE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.ERASER_RESIDDUE;
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://ケシカス爆弾.
                Debug.Log("KESHIKASU_BOM!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.KESHIKASU_BOM;
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://黒板けし.
                Debug.Log("BLACKBOARD_ERASER!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.BLACKBOARD_ERASER;
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://シャー芯.
                Debug.Log("MECHANICAL_PEN_LEAD!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.MECHANICAL_PEN_LEAD;
                break;
            case ITEMConst.ITEM.STICKY_NOTE://付箋.
                Debug.Log("STICKY_NOTE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.STICKY_NOTE;
                break;
            case ITEMConst.ITEM.TAPE_BALL://丸めたテープ.
                Debug.Log("TAPE_BALL!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.TAPE_BALL;
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://セロハンテープ.
                Debug.Log("SCOTCH_TAPE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.SCOTCH_TAPE;
                break;
            case ITEMConst.ITEM.MAGIC_PEN://マジックペン.
                Debug.Log("MAGIC_PEN!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.MAGIC_PEN;
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://鶴の折り紙.
                Debug.Log("ORIGAMI_CRANE!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.ORIGAMI_CRANE;
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://ビリビリペン.
                Debug.Log("BIRIBIRI_PEN!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.BIRIBIRI_PEN;
                break;
            case ITEMConst.ITEM.INDIA_INK://墨汁.
                Debug.Log("INDIA_INK!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.INDIA_INK;
                break;
            case ITEMConst.ITEM.CARDBOARD://段ボール.
                Debug.Log("CARDBOARD!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.CARDBOARD;
                break;
            default:
                break;
        }
        //Debug.Log(USER_HAVE[USER_NUM, 1]);
    }

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
        return USER_HAVE[USER_NUMBER, 1];
    }

    public void Item_Use(int User_NUM,int Front)//Playerがアイテムを使用した際にこれを呼ぶ.
    {
        //前後の変更
        //if (Front == 1)//1は前
        //{
        //    Rocket = RocketB;
        //}
        //else if (Front == 2)//2は後
        //{
        //    Rocket = RocketA;
        //}

        //アイテムごとの処理.
        switch (USER_HAVE[User_NUM, 1])
        {
            case ITEMConst.ITEM.ERASER_RESIDDUE://消しカス.
                Debug.Log("USE:ERASER_RESIDDUE!");
                Instantiate(ERASER_RESIDDUE, RocketA, Quaternion.Euler(90, 0, 0));
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://ケシカス爆弾.
                Debug.Log("USE:KESHIKASU_BOM!");
                Instantiate(KESHIKASU_BOM, RocketB, Quaternion.identity);//ケシカスのプレファブを使いまわす
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://黒板けし.
                Debug.Log("USE:BLACKBOARD_ERASER!");
                RocketB.y += 5;
                Instantiate(BLACKBOARD_ERASER, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://シャー芯.
                Instantiate(MECHANICAL_PEN_LEAD, RocketB, Quaternion.Euler(90, 0, 0));
                Debug.Log("USE:MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://付箋.
                Debug.Log("USE:STICKY_NOTE!");
                Rocket.y += 10;
                Instantiate(STICKY_NOTE, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.TAPE_BALL://丸めたテープ.
                Debug.Log("USE:TAPE_BALL!");
                Instantiate(TAPE_BALL, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://セロハンテープ.
                Debug.Log("USE:SCOTCH_TAPE!");
                Instantiate(SCOTCH_TAPE, RocketA, Quaternion.identity);
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
                //Instantiate(BIRIBIRI_PEN, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.INDIA_INK://墨汁.
                Debug.Log("USE:INDIA_INK!");
                //Instantiate(INDIA_INK, RocketB, Quaternion.identity);
                break;
            case ITEMConst.ITEM.CARDBOARD://段ボール.
                Debug.Log("USE:CARDBOARD!");
                Instantiate(CARDBOARD, RocketA, Quaternion.identity);
                break;
            default:
                break;
        }
        USER_HAVE[USER_NUMBER, 1] = ITEMConst.ITEM.ItemNull;//アイテムを使用（空にする）
        //Debug.Log(USER_HAVE[USER_NUMBER, 1]);
    }    
}

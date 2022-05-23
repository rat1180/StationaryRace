using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数値を使うために記入.

public class ItemManager : MonoBehaviour
{
    public int USER_NUMBER; //ユーザ番号を入れる箱
    private int USER_ALL = 8;//ユーザの総数を入れる箱
    private int[,] USER_HAVE = new int[10, 2];//ユーザ番号と持っているアイテムを入れる
    public Vector3 Player; //プレイヤーの位置を取得

    //アイテムのゲームオブジェクト宣言
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
        //アイテムの情報を入れる配列の初期化
        for(int i = 1; i < USER_ALL + 1; i++)
        {
            USER_HAVE[i,0] = i;
            USER_HAVE[i, 1] = ITEMConst.ITEM.ItemNull;//全てのユーザのアイテムをヌル(-1)で埋める
        }
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Car").transform.position;//プレイヤーの座標を取得
    }

    public void Item(int USER_NUM,int ITEMNUM)//itemblockが破壊された際にこれを呼ぶ.
    {
        //アイテムごとの処理.
        switch (ITEMNUM)
        {
            case ITEMConst.ITEM.ENPITU://えんぴつ.
                Debug.Log("ENPITU!");
                USER_HAVE[USER_NUM, 1] = ITEMConst.ITEM.ENPITU;
                break;
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

    public void Item_Use(int User_NUM)//Playerがアイテムを使用した際にこれを呼ぶ.
    {
        //Debug.Log(USER_HAVE[User_NUM, 1]);
        //アイテムごとの処理.
        switch (USER_HAVE[User_NUM, 1])
        {
            case ITEMConst.ITEM.ENPITU://えんぴつ.
                Debug.Log("USE:ENPITU!");
                break;
            case ITEMConst.ITEM.ERASER_RESIDDUE://消しカス.
                Debug.Log("USE:ERASER_RESIDDUE!");
                Player.z -= 1;
                Instantiate(ERASER_RESIDDUE, Player, Quaternion.identity);
                break;
            case ITEMConst.ITEM.KESHIKASU_BOM://ケシカス爆弾.
                Debug.Log("USE:KESHIKASU_BOM!");
                for(int i=0; i < 500; i++)
                {
                    Player.x += Random.Range(-5, 5);
                    Player.y += Random.Range(1, 10);
                    Player.z += Random.Range(-5, 5);
                  Instantiate(ERASER_RESIDDUE, Player, Quaternion.identity);//ケシカスのプレファブを使いまわす
                }
                break;
            case ITEMConst.ITEM.BLACKBOARD_ERASER://黒板けし.
                Debug.Log("USE:BLACKBOARD_ERASER!");
                break;
            case ITEMConst.ITEM.MECHANICAL_PEN_LEAD://シャー芯.
                Player.z = Player.z + 3;
                Instantiate(MECHANICAL_PEN_LEAD, Player, Quaternion.identity);
                Debug.Log("USE:MECHANICAL_PEN_LEAD!");
                break;
            case ITEMConst.ITEM.STICKY_NOTE://付箋.
                Debug.Log("USE:STICKY_NOTE!");
                Player.z += 5;
                Player.y += 3;
                Instantiate(STICKY_NOTE, Player, Quaternion.identity);
                break;
            case ITEMConst.ITEM.TAPE_BALL://丸めたテープ.
                Debug.Log("USE:TAPE_BALL!");
                Player.z += 3;
                Instantiate(TAPE_BALL, Player, Quaternion.identity);
                break;
            case ITEMConst.ITEM.SCOTCH_TAPE://セロハンテープ.
                Debug.Log("USE:SCOTCH_TAPE!");
                break;
            case ITEMConst.ITEM.MAGIC_PEN://マジックペン.
                Debug.Log("USE:MAGIC_PEN!");
                break;
            case ITEMConst.ITEM.ORIGAMI_CRANE://鶴の折り紙.
                Debug.Log("USE:ORIGAMI_CRANE!");
                break;
            case ITEMConst.ITEM.BIRIBIRI_PEN://ビリビリペン.
                Debug.Log("USE:BIRIBIRI_PEN!");
                break;
            case ITEMConst.ITEM.INDIA_INK://墨汁.
                Debug.Log("USE:INDIA_INK!");
                break;
            case ITEMConst.ITEM.CARDBOARD://段ボール.
                Debug.Log("USE:CARDBOARD!");
                Player.z = Player.z - 3;
                //Debug.Log("Player:" + Player);
                Instantiate(CARDBOARD, Player, Quaternion.identity);
                break;
            default:
                break;
        }
        USER_HAVE[USER_NUMBER, 1] = ITEMConst.ITEM.ItemNull;//アイテムを使用（空にする）
        //Debug.Log(USER_HAVE[USER_NUMBER, 1]);
    }    
}

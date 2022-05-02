using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キー情報構造体
public struct KEYS
{
    //アクセルキー true:オン false:オフ
    public bool AcceleKey;
    //ブレーキキー true:オン false:オフ
    public bool BrakeKey;
    //アイテムキー true:オン false:オフ
    public bool ItemKey;
    //ハンドル入力キー 0:なし 1:右 2:左
    public int HandleKey;

}

public class UserOperation : MonoBehaviour
{
    /******************
     各キーの入力判定用変数
    *******************/

    private KEYS Key;



    /****************
     子クラスの取得用オブジェクト
    *****************/

    //自分の機体
    private GameObject Mashin;

    //UI
    private GameObject UI;

    //システム
    private GameObject GMSystem;

    /****************
     その他の変数
    *****************/

    //エラー判定
    private int Erflg;

    //順位
    private int Rank = 3;

    //アイテム
    private int ItemNm;

    //CP通過タイム
    private double CPTime;

    //ユーザー番号
    private int UserNm;

    /***************
     定義用変数
    ****************/

    //ハンドル操作
    private int NULL = 0;
    private int RIGHT = 1;
    private int LEFT = 2;

    //アイテム変数(なしは-1)
    private int NON = -1;

    // Start is called before the first frame update
    void Start()
    {
        //キーの初期化
        InitKey();

        InitSet();

        //エラーチェックを行う
        Erflg = InitErCheck();
        if(Erflg != 0)
        {
            Debug.Log(Erflg);
        }

        //RankSend();

    }

    // Update is called once per frame
    void Update()
    {
        KeyListener();
        //KeySend();
    }

    /************
     起動時処理(エラーは下)
    *************/

    //キーの初期化
    public void InitKey()
    {
        
        Key.AcceleKey = false;
        Key.BrakeKey = false;
        Key.ItemKey = false;
        Key.HandleKey = NULL;
        

    }

    //機体、UIの取得や各値の初期値セット
    private void InitSet()
    {
        //システム
        GMSystem = transform.parent.gameObject;

        //機体
        Mashin = transform.Find("test_M").gameObject;

        //UI
        UI = transform.Find("UI").gameObject;

        ItemNm = NON;

        //起動時は表示しない
        Rank = -1;

    }

    /***********
     Update処理
    ************/

    private void KeyListener()
    {
        //各キーの入力処理
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
     機体との通信
    ***************/

    public KEYS KeySend()
    {
        //テストログ
        if(Key.AcceleKey == true)
        {
            Debug.Log("アクセルon");
        }
        if(Key.BrakeKey == true)
        {
            Debug.Log("ブレーキon");
        }
        if(Key.ItemKey == true)
        {
            Debug.Log("アイテムon");
        }
        if(Key.HandleKey == RIGHT)
        {
            Debug.Log("右");
        }else if(Key.HandleKey == LEFT)
        {
            Debug.Log("左");
        }

        return Key;

    }

    /**************
     UIとの通信
    ***************/

    //UIに順位を送る(起動時は-1で表示せず)
    public void RankSend()
    {
        UI.GetComponent<UI>().RankingChange(Rank);
    }

    //UIにアイテムを送る
    public void ItemSend()
    {
        //アイテムがあるならその番号、ないなら-1を送る
        //UI.GetComponent<UI>().ITEM_CHANGE(ItemNm);
    }

    /***************
     システムとの通信
    ****************/

    //生成時に割り振ってもらう(関数呼び出しはシステムで)
    public int InitUser(int nm)
    {
        if(nm != null)
        {
            //値エラー
            return 1;
        }

        UserNm = nm;
        return 0;

    }

    //ゲームが始まった時とCP通過時にシステムからもらう
    public void RankSet()
    {
        int NewRank = 3;//GMSystem.GetComponent<GMSystem>().RankGet(UserNm);戻り値付き

        //ランクの変動がなければ行わない
        if (Rank == NewRank)
        {
            return;
        }

        Rank = NewRank;

        RankSend();
    }

    /******************
     　　エラー系
    *******************/

    //エラーチェック(0:異常なし 1:機体エラー 2:UIエラー 3:システムエラー)
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
        //エラーコード
        //3桁:機体・UIの状態 0>異常なし 1>UIに異常
        int ErCode;

        Erflg = Erflg * 100;
        ErCode = Erflg;

        //ErCodeをシステムに送信
        //GMSystem.GetComponent<GMSystem>().ErGet(ErCode);

    }

}
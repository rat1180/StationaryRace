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

    /****************
     その他の変数
    *****************/
    int Erflg;

    // Start is called before the first frame update
    void Start()
    {
        Erflg = InitErCheck();
        if(Erflg == 1 || Erflg == 2)
        {
            Debug.Log(Erflg);
        }

        InitKey();
    }

    // Update is called once per frame
    void Update()
    {
        KeyListener();
        KeySend();
    }

    //キーの初期化
    public void InitKey()
    {
        
        Key.AcceleKey = false;
        Key.BrakeKey = false;
        Key.ItemKey = false;
        Key.HandleKey = 0;
        

    }

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
            Key.HandleKey = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Key.HandleKey = 2;
        }
        else
        {
            Key.HandleKey = 0;
        }
    }

    private void KeySend()
    {
        //機体に送る
    }

    //エラーチェック(0:異常なし 1:機体エラー 2:UIエラー)
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

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct KEYS
{
    //アクセルキー true:オン false:オフ
    bool AcceleKey;
    //ブレーキキー true:オン false:オフ
    bool BrakeKey;
    //アイテムキー true:オン false:オフ
    bool ItemKey;
    //ハンドル入力キー 0:なし 1:右 2:左
    int HandleKey;

}

public class UserOperation : MonoBehaviour
{
    /******************
     各キーの入力判定用変数
    *******************/

    public KEYS key;

    

    /****************
     子クラスの取得用オブジェクト
    *****************/

    //自分の機体
    //private gameobject 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //キーの初期化
    private void InitKey()
    {
        key.AcceleKey = false;
        key.BrakeKey = false;
        key.ItemKey = false;
        key.HandleKey = 0;

    }

}
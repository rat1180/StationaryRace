using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ITEMConst;

public class GMSystem : MonoBehaviour
{
    /**************
     ゲーム進行変数
    ***************/

    //0:停止状態 1:スタート前 2:レース中 3:レース後 
    private int GameFlg;

    //ランク配列(今は一つ)
    private int[] Rank;

    //コース番号
    private int CoseNm;

    /**************
     ユーザー系変数
    ***************/

    //1ユーザーに割り当てる情報
    public struct USERINF
    {
        public GameObject USER;
        public int USERNm;
        public double CPTime;
        public int CPcnt;
        public int Rap;
    }

    //ユーザー配列（通信形態によっては変更）
    //USERINF[] Users;
    private USERINF User;

    //ユーザー人数（通信形態によっては変更）
    private int Players;

    /***************
     アイテム系変数
    ****************/

    //アイテムマネージャー
    private GameObject ItemManager;

    // Start is called before the first frame update
    void Start()
    {
        InitSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**************
     起動時処理
    ***************/

    //ユーザーなどのセット
    public void InitSet()
    {
        //レース前のシーンからもらう
        Players = 1;
        CoseNm = 0;

        //スタート前準備
        GameFlg = 1;
        CoseCheck();

        //ランク用変数の生成
        Rank = new int[Players];
        for(int i = 0; i < Players; i++)
        {
            Rank[i] = i;
        }

        //ユーザー(人数分繰り返す)
        User.USER = transform.Find("User").gameObject;
        User.USERNm = 0;
        User.CPcnt = 0;
        User.CPTime = 0;
        User.Rap = 1;
        NmSend();
        User.USER.GetComponent<UserOperation>().RankSet();



        //アイテム
        //ItemManager = transform.Find("ItemManager").gameObject;
    }

    //レーススタート


    /// <summary>
    /// コースの確認、読み込み
    /// </summary>
    void CoseCheck()
    {
        switch (CoseNm)
        {
            case 0:
                CPSet(4);
                //ここでコースをオン
                break;
        }
        
    }

    /// <summary>
    /// チェックポイント割り振り
    /// </summary>
    void CPSet(int CPNm)
    {
        GameObject CPtmp;
        for (int i = 0; i < CPNm; i++)
        {
            CPtmp = this.transform.Find("CPList").GetComponent<Transform>().transform.GetChild(i).gameObject;
            CPtmp.GetComponent<CheckPoint>().CPset(i);
        }
    }

    /***********
     ユーザー系
    ************/

    /// <summary>
    /// ユーザー番号を渡す
    /// </summary>
    private void NmSend()
    {
        int Er = User.USER.GetComponent<UserOperation>().InitUser(User.USERNm);
        if(Er != 0)
        {
            GameFlg = 0;
        }
    }

    //ユーザー番号に応じた順位を返す
    public int RankGet(int Nm)
    {
        for (int i = 0; i < Players; i++)
        {
            if (Rank[i] == Nm)
            {
                return i + 1;
            }
        }

        //エラー
        return -1;
    }

    //順位判定


}

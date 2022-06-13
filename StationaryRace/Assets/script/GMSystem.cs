using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ITEMConst;

public class GMSystem : MonoBehaviour
{
    #region 変数宣言
    /*************
     定義用
    ***************/
    const int TRUE = 1;
    const int FALSE = 0;

    /**************
     ゲーム進行変数
    ***************/

    //0:停止状態 1:スタート前 2:レース中 3:レース後 
    private int GameFlg;

    //ランク配列(今は一つ)
    private int[] Rank;

    //コース番号
    private int CoseNm;

    private int CPmax;

    private int Rapmax;

    //時間計測用変数
    public double RaceTime;
    private int TimerFlg;

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
    public USERTIME[] Users;
    private USERINF User;

    //ユーザー人数（通信形態によっては変更）
    private int Players;

    //他ユーザーとの通信用に扱う構造体
    public struct USERTIME
    {
        public double CPTime;
        public int CPcnt;
        public int Rap;
        public int UserNm;
    }

    /***************
     アイテム系変数
    ****************/

    //アイテムマネージャー
    private GameObject ItemManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InitSet();
        StartRace();
        //Invoke("CarSpawn", 5);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    #region 起動時処理
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
        Rapmax = 1;
        CPSet();

        //ランク用変数と他ユーザー用配列の生成
        Rank = new int[Players];
        Users = new USERTIME[Players];
        for(int i = 0; i < Players; i++)
        {
            Rank[i] = i;
            if (i != User.USERNm)
            {
                Users[i].UserNm = i;
            }
            else
            {
                //自分の位置なので情報入れない
                Users[i].UserNm = -1;
            }
        }

        //ユーザー(自分)
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
    public void StartRace()
    {
        GameFlg = 2;
        RaceTime = 0;
        TimerFlg = TRUE;
    }

    /// <summary>
    /// ゲーム開始時に移動させる
    /// </summary>
    public void CarSpawn()
    {
        GameObject SPlist = this.transform.Find("SpawnList").gameObject;
        Vector3 SP = SPlist.transform.GetChild(User.USERNm).gameObject.GetComponent<Transform>().position;
        User.USER.GetComponent<UserOperation>().SPCar(SP);
    }

    /// <summary>
    /// チェックポイント割り振り
    /// コースを変えるときは他のCPリストを削除or親子から外すこと！！
    /// </summary>
    void CPSet()
    {
        GameObject CPtmp;
        GameObject CPlist = this.transform.Find("CPList").gameObject;
        for (CPmax = 0;CPmax < CPlist.transform.childCount; CPmax++)
        {
            CPtmp = CPlist.transform.GetChild(CPmax).gameObject;
            CPtmp.GetComponent<CheckPoint>().CPset(CPmax);
        }
    }

    #endregion

    #region ユーザー系処理

    /***********
     ユーザー系
    ************/

    /// <summary>
    /// ユーザー番号を渡す
    /// </summary>
    private void NmSend()
    {
        int Er = User.USER.GetComponent<UserOperation>().InitUser(User.USERNm, CPmax - 1, Rapmax) ;
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

    //CP通過による処理(他ユーザーからの情報だけ入れる)
    public void CPpass(USERTIME rUSER)
    {
        for(int i = 0; i < Players; i++)
        {
            if(Users[i].UserNm == rUSER.UserNm)
            {
                Users[i] = rUSER;
            }
        }
    }

    //自分が通過したときに呼び出す（通過と同時）
    public void MyCPpass(int MyCPcnt,int MyRap)
    {
        User.CPTime = TimeGet();
        User.CPcnt = MyCPcnt;
        User.Rap = MyRap;

        if(MyRap == Rapmax)
        {
            Debug.Log("ゴールタイム:" + (User.CPTime).ToString("lf.3"));
        }
    }

    //順位判定

    #endregion

    /************
     システム系
    *************/

    //時間を計測する
    private void Timer()
    {
        if(TimerFlg == TRUE)
        {
            RaceTime += Time.deltaTime;
        }
    }

    //経過時間を返す
    public double TimeGet()
    {
        return RaceTime;
    }

}

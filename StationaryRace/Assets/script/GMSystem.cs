using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ITEMConst;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;

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

    //コース番号
    private int CoseNm;

    private int CPmax;

    private int Rapmax;

    //時間計測用変数
    public double RaceTime;
    private bool TimerFlg;

    //ゲーム終わり
    public GameObject GAMEOVER;

    
    GameObject CPlist;

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
        public int Rank;
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

    //他ユーザーの情報の保存先
    public GameObject SystemINF = null;
    public GameObject SystemINF_POP;

    /***************
     アイテム系変数
    ****************/

    //アイテムマネージャー
    private GameObject ItemManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //入室時に起動
        //InitSet();
        
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
        Players = 3; //4-1
        CoseNm = 0;

        //スタート前準備
        GameFlg = 1;
        Rapmax = 1;
        CPlist = this.transform.Find("CPList").gameObject;
        CPSet();


        //ユーザー(自分)
        User.USER = transform.Find("User").gameObject;
        User.USERNm = USERnmGet();
        Debug.Log(User.USERNm);
        User.CPcnt = 0;
        User.CPTime = 0;
        User.Rap = 3;
        User.Rank = 1;
        NmSend();
        //User.USER.GetComponent<UserOperation>().RankSet();

        //ランク用変数と他ユーザー用配列の生成
        //処理手順によって場所を変える
        Users = new USERTIME[Players];

        //アイテム
        //ItemManager = transform.Find("ItemManager").gameObject;

        //GAMEOVER = GameObject.Find("TimeText");
        //GAMEOVER.SetActive(false);
    }

    //レーススタート
    public void StartRace()
    {
        GameFlg = 2;
        RaceTime = 0;
        TimerFlg = true;
    }

    /// <summary>
    /// ゲーム開始時に移動させる
    /// </summary>
    public void CarSpawn()
    {
        
        GameObject SPlist = this.transform.Find("SpawnList").gameObject;
        Vector3 SPp = SPlist.transform.GetChild(User.USERNm).gameObject.GetComponent<Transform>().position;
        Quaternion SPr = SPlist.transform.GetChild(User.USERNm).gameObject.GetComponent<Transform>().rotation;
        User.USER.GetComponent<UserOperation>().SPCar(SPp, SPr);
    }

    /// <summary>
    /// チェックポイント割り振り
    /// コースを変えるときは他のCPリストを削除or親子から外すこと！！
    /// </summary>
    void CPSet()
    {
        GameObject CPtmp;
        for (CPmax = 0; CPmax < CPlist.transform.childCount; CPmax++)
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
        int Er = User.USER.GetComponent<UserOperation>().InitUser(User.USERNm, CPmax - 1, Rapmax);
        if (Er != 0)
        {
            GameFlg = 0;
        }
    }

    //ユーザー番号に応じた順位を返す
    public int RankGet()
    {
        if(User.Rank >= 1 || User.Rank <= 4)
        {
            return User.Rank;
        }

        //エラー
        return -1;
    }

    //CP通過による処理(他ユーザーからの情報だけ入れる)
    public void CPpass(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        if (rUSERNm != User.USERNm)
        {
            for (int i = 0; i < Players; i++)
            {
                if (Users[i].UserNm == rUSERNm)
                {
                    Users[i].CPTime = rUSERTime;
                    Users[i].CPcnt = rUSERCPcnt;
                    Users[i].Rap = rUSERRap;
                }
            }
        }
        Ranking();
    }

    //自分が通過したときに呼び出す（通過と同時）
    public void MyCPpass(int MyCPcnt, int MyRap)
    {
        User.CPTime = TimeGet();
        CPlist.transform.GetChild(User.CPcnt).gameObject.GetComponent<MeshRenderer>().enabled = false;
        User.CPcnt = MyCPcnt;
        CPlist.transform.GetChild(User.CPcnt + 1).gameObject.GetComponent<MeshRenderer>().enabled = true;
        User.Rap = MyRap;

        if (MyRap == Rapmax)
        {
            TimerFlg = false;
            Debug.Log("ゴールタイム:" + (User.CPTime).ToString("f3"));
            GAMEOVER.SetActive(true);
            string str1 = "ゴール!!" + (User.CPTime).ToString("f3");
            string str2 = "\n順位" + User.Rank;
            GAMEOVER.GetComponent<Text>().text = str1 + str2;
            //GAMEOVER.GetComponent<Result>().Decide_Timer(User.CPTime);
        }

        SystemINF.GetComponent<SystemINF>().USERCP(User.USERNm, User.CPTime, User.CPcnt, User.Rap);
    }

    //順位判定
    public void Ranking()
    {
        User.Rank = 1;
        for (int j = 0; j < Players; j++)
        {
            if(User.Rap < Users[j].Rap)
            {
                User.Rank++;
            }
            else if(User.CPcnt < Users[j].CPcnt)
            {
                User.Rank++;
            }
            else if(User.CPTime < Users[j].CPTime)
            {
                User.Rank++;
            }

        }
    } 

    #endregion

    /************
     システム系
    *************/

    //時間を計測する
    private void Timer()
    {
        if(TimerFlg == true)
        {
            RaceTime += Time.deltaTime;
        }
    }

    //経過時間を返す
    public double TimeGet()
    {
        return RaceTime;
    }

    //番号の取得
    public int USERnmGet()
    {
        //他ユーザー情報の確認
        SystemINF = GameObject.Find("SystemINF(Clone)");

        //ルームオーナー証明
        if (SystemINF == null)
        {
            //オーナーのみ生成
            SystemINF = Instantiate(SystemINF_POP);
            SystemINF.GetComponent<SystemINF>().USERcntRESET();
            Debug.Log("生成");
        }

        int Usernm = SystemINF.GetComponent<SystemINF>().USERcntSET(1);
        return Usernm;
    }

    //参加するたび情報を入れる
    public void PlayerJoin()
    {
        int Usernm = SystemINF.GetComponent<SystemINF>().USERcntSET(0);
        if (Usernm == User.USERNm) return;
        for(int i = 0; i < Players; i++)
        {
            if(Users[i].UserNm == null)
            {
                Users[i].UserNm = Usernm;
                break;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;

public class SystemINF : StrixBehaviour
{

    //UserNmを割り振るたびに増やしてくことで重なりをなくす
    //[StrixSyncField]
    public static int USERcnt;

    //他ユーザーとの通信用に扱う構造体
    
    public struct USERTIME
    {
        [StrixSyncField]
        public double CPTime;
        [StrixSyncField]
        public int CPcnt;
        [StrixSyncField]
        public int Rap;
        [StrixSyncField]
        public int UserNm;
        [StrixSyncField]
        public int Rank;
    }

    //[StrixSyncField]
    public USERTIME[] USERS = { new USERTIME { CPTime = 0, CPcnt = 0, Rap = 0, UserNm = 0, Rank = 1 },
                                new USERTIME { CPTime = 0, CPcnt = 0, Rap = 0, UserNm = 1, Rank = 1 },
                                new USERTIME { CPTime = 0, CPcnt = 0, Rap = 0, UserNm = 2, Rank = 1 },
                                new USERTIME { CPTime = 0, CPcnt = 0, Rap = 0, UserNm = 3, Rank = 1 },};


    public GameObject GMSystem;
    public GameObject INFtoGM;
    public GameObject INFtoGM_POP;
    public GameObject LastShortCut;
    public bool BreakFlg = false;



    // Start is called before the first frame update
    void Start()
    {
        //入退室イベント
        //StrixNetwork.instance.roomSession.roomClient.RoomJoinNotified += RoomJoinNotified_RPC;

        GMSystem = GameObject.Find("GMSystem");
        if (!isLocal)
        {
            return;
            //USERcntRESET();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //USER0 = USERS[0];
        //USER1 = USERS[1];
        //USER2 = USERS[2];
        //USER3 = USERS[3];
    }

    public void USERcntRESET()
    {
        USERcnt = -1;
    }

    /// <summary>
    /// Usercntを1増やして返す
    /// </summary>
    public int USERcntSET()
    {
        USERcnt++;

        return USERcnt;
    }

    /// <summary>
    /// Usercntを返す
    /// </summary>
    /// <returns></returns>
    public int USERcntGET()
    {
        return USERcnt;
    }

    ///// <summary>
    ///// 誰かが入るたびに各GMSystemに入ったUserの番号を入力させる
    ///// おそらく使わない
    ///// </summary>
    //[StrixRpc]
    //public void RoomJoinNotified()
    //{
    //    GMSystem.GetComponent<GMSystem>().PlayerJoin();
    //}


    //public void RoomJoinNotified_RPC()
    //{
    //    RpcToAll("RoomJoinNotified");
    //}

    ///// <summary>
    ///// CP通過時に情報を入れる（呼び出しは各ユーザー）
    ///// その後に各GMSystemに送信する
    ///// </summary>
    ///// <param name = "rUSER" ></ param >
    
    public int USERCP(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        Debug.Log(rUSERCPcnt);
        for (int i = 0; i < 4; i++)
        {
            if (USERS[i].UserNm == rUSERNm)
            {
                USERS[i].CPTime = rUSERTime;
                USERS[i].CPcnt = rUSERCPcnt;
                USERS[i].Rap = rUSERRap;
                USERS[i].Rank = 1;
                for(int j = 0; j < 4; j++)
                {
                    if(USERS[i].UserNm != USERS[j].UserNm)
                    {
                        if (USERS[i].Rap < USERS[j].Rap)
                        {
                            USERS[i].Rank++;
                            Debug.Log("RapRank");
                        }
                        else if (USERS[i].CPcnt < USERS[j].CPcnt)
                        {
                            USERS[i].Rank++;
                            Debug.Log("CPRank");
                        }
                        else if (USERS[i].CPTime > USERS[j].CPTime)
                        {
                            USERS[i].Rank++;
                            Debug.Log("TimeRank");
                        }
                    }
                }
                return USERS[i].Rank;
            }
            
        }
        return 1;
        //GMSystem.GetComponent<GMSystem>().CPpass(rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
    }

    public void USERCP_RPC(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        //RpcToAll("USERCP", rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
        RpcToAll("POP_RPC", rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
    }

    [StrixRpc]
    public void POP_RPC(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        INFtoGM = Instantiate(INFtoGM_POP);
        INFtoGM.GetComponent<INFtoGM>().RPC(rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
    }

    [StrixRpc]
    public void Bomber()
    {
        BreakFlg = true;
        LastShortCut = GameObject.Find("Break_Obj");
        LastShortCut.GetComponent<LastShortCut>().Bomber();
    }

    public void Bomber_RPC()
    {
        if(BreakFlg == false)
        {
            RpcToAll("Bomber");
        }
    }

    public void USER_RESET()
    {
        for(int i = 0; i < 4; i++)
        {
            USERS[i].CPcnt = 0;
            USERS[i].CPTime = 99;
            USERS[i].Rank = 1;
            USERS[i].Rap = 0;
            USERS[i].UserNm = i;
        }
        //USER0 = USERS[0];
        //USER1 = USERS[1];
        //USER2 = USERS[2];
        //USER3 = USERS[3];
    }

}

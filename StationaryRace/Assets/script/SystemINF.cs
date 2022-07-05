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
    [StrixSyncField]
    public static int USERcnt;

    //他ユーザーとの通信用に扱う構造体
    public struct USERTIME
    {
        public double CPTime;
        public int CPcnt;
        public int Rap;
        public int UserNm;
    }

    public USERTIME[] USERS = new USERTIME[4];

    private GameObject GMSystem;


    // Start is called before the first frame update
    void Start()
    {
        //入退室イベント
        //StrixNetwork.instance.roomSession.roomClient.RoomJoinNotified += RoomJoinNotified_RPC;

        GMSystem = GameObject.Find("GMSystem");
        if (isLocal)
        {
            //USERcntRESET();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

    /// <summary>
    /// CP通過時に情報を入れる（呼び出しは各ユーザー）
    /// その後に各GMSystemに送信する
    /// </summary>
    /// <param name="rUSER"></param>
    [StrixRpc]
    public void USERCP(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        for (int i = 0; i < 4; i++)
        {
            if (USERS[i].UserNm == rUSERNm)
            {
                USERS[i].CPTime = rUSERTime;
                USERS[i].CPcnt = rUSERCPcnt;
                USERS[i].Rap = rUSERRap;
            }
        }

        GMSystem.GetComponent<GMSystem>().CPpass(rUSERNm,rUSERTime,rUSERCPcnt,rUSERRap);
    }

    public void USERCP_RPC(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        RpcToAll("USERCP", rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
    }

}

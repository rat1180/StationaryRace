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

    //UserNm������U�邽�тɑ��₵�Ă����Ƃŏd�Ȃ���Ȃ���
    [StrixSyncField]
    public static int USERcnt;

    //�����[�U�[�Ƃ̒ʐM�p�Ɉ����\����
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
        GMSystem = GameObject.Find("GMSystem");
        if (isLocal)
        {
            USERcntRESET();
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
    /// Usercnt�����������₵�Ēl��Ԃ�
    /// ������mode,�߂�l��mode�ɂ���ĕϓ�
    /// 0�Ȃ瑝�₳���Ԃ��B1���ʏ�ő��₵�Ă���Ԃ�
    /// </summary>
    public int USERcntSET(int mode)
    {
        USERcnt += mode;

        return USERcnt;
    }

    /// <summary>
    /// CP�ʉߎ��ɏ�������i�Ăяo���͊e���[�U�[�j
    /// ���̌�ɊeGMSystem�ɑ��M����
    /// </summary>
    /// <param name="rUSER"></param>
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

}

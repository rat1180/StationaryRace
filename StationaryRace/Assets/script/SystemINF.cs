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
    public int USERcnt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void USERcntRESET()
    {
        USERcnt = -1;
    }

    /// <summary>
    /// Usercnt�����������₵�Ēl��Ԃ�
    /// ������mode,�߂�l��mode�ɂ���ĕϓ�
    /// 0�Ȃ瑝�₳���Ԃ��B1���ʏ�ő��₵�Ă���Ԃ�
    /// </summary>
    int USERcntSET(int mode)
    {
        USERcnt += mode;

        return USERcnt;
    }
}

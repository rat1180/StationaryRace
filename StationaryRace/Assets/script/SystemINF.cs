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
    /// Usercntを引数分増やして値を返す
    /// 引数はmode,戻り値はmodeによって変動
    /// 0なら増やさず返す。1が通常で増やしてから返す
    /// </summary>
    int USERcntSET(int mode)
    {
        USERcnt += mode;

        return USERcnt;
    }
}

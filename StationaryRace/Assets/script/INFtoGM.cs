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

public class INFtoGM : MonoBehaviour
{
    GameObject GMSystem;
    // Start is called before the first frame update
    void Awake()
    {
        GMSystem = GameObject.Find("GMSystem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //[StrixRpc]
    public void USERCP(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {

        GMSystem.GetComponent<GMSystem>().CPpass(rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
        this.gameObject.SetActive(false);
    }

    public void RPC(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        //RpcToAll("USERCP", rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
        USERCP(rUSERNm, rUSERTime, rUSERCPcnt, rUSERRap);
    }
}

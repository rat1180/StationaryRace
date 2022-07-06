using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class InkConlore : StrixBehaviour
{
    INDIA_INK InkSc;

    // Start is called before the first frame update
    void Start()
    {
        RpcToAll("INK_RPC");
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    [StrixRpc]
    public void INK_RPC()
    {
        if (!isLocal)
        {
            InkSc = GameObject.Find("INDIA_INK").GetComponent<INDIA_INK>();
            InkSc.Animation();
        }
        this.gameObject.SetActive(false);
    }
}

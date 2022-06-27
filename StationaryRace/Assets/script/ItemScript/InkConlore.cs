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

        if (!isLocal)
        {
            InkSc = GameObject.Find("InkSc").GetComponent<INDIA_INK>();
            InkSc.Animation();
        }
        this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}

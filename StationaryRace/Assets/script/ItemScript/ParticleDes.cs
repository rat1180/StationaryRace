using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Des", 10);
    }

    //自身を破壊する関数.
    void Des()
    {
        Destroy(this.gameObject);
    }
}

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

    // Update is called once per frame
    void Update()
    {
        
    }
    void Des()
    {
        Destroy(this.gameObject);
    }
}

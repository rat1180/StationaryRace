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

    //©g‚ğ”j‰ó‚·‚éŠÖ”.
    void Des()
    {
        Destroy(this.gameObject);
    }
}

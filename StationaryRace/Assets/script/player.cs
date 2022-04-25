using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //‘O•ûŒü‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0.0f,0.0f,0.01f);
        //¶•ûŒü‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(-0.01f, 0.0f, 0.0f);
        //Œã•ûŒü‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(0.0f, 0.0f, -0.01f);
        //‰E•ûŒü‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(0.01f, 0.0f, 0.0f);
    }
}

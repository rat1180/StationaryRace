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
        //前方向に移動
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0.0f,0.0f,0.01f);
        //左方向に移動
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(-0.01f, 0.0f, 0.0f);
        //後方向に移動
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(0.0f, 0.0f, -0.01f);
        //右方向に移動
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(0.01f, 0.0f, 0.0f);
    }
}

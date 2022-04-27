using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_car : MonoBehaviour
{
    public float speed = 10.0f;        //動く速度
    public int type = 0;               //テクスチャの選択
    public Material[] _material;       //テクスチャの割り当て

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //前方向に移動
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0.0f, 0.0f, 0.03f);
        //左方向に移動
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(-0.03f, 0.0f, 0.0f);
        //後方向に移動
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(0.0f, 0.0f, -0.03f);
        //右方向に移動
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(0.03f, 0.0f, 0.0f);

        //機体のテクスチャ変更
        switch (type)
        {
            case 0:
                this.GetComponent<Renderer>().material = _material[0];
                break;
            case 1:
                this.GetComponent<Renderer>().material = _material[1];
                break;
            case 2:
                this.GetComponent<Renderer>().material = _material[2];
                break;
        }
    }
}

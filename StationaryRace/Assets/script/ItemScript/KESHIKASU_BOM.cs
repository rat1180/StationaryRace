using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class KESHIKASU_BOM : StrixBehaviour
{
    public GameObject ERASER_RESIDDUE;//ケシカスのプレファブを使う
    public GameObject SOUND;          //爆発音を鳴らすプレファブを入れる
    public GameObject Effect;
    private Rigidbody rb;             //Rigidbodyを使用するための宣言
    private float speed;              //速度を入れる変数
    private Vector3 Pos;              //現在地取得用
    int i;                            //ループ用

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal) return;
        rb = GetComponent<Rigidbody>();
        speed = 100.0f;  //速度の設定
        Invoke("Des", 1);//1秒後に関数を呼び出す
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocal) return;
        rb.velocity = transform.forward * speed;//正面に進む処理
    }
    void Des()
    {
        Pos = this.transform.position;               //現在地を取得.
        Instantiate(SOUND, Pos, Quaternion.identity);//爆発音を鳴らす.
        Instantiate(Effect,Pos, Quaternion.identity);//エフェクト表示.
        for (i = 0; i < 33; i++)                     //ケシカスを99個生成
        {
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(90, 0, 0));
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(0, 90, 0));
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(0, 0, 90));
        }
        Destroy(this.gameObject);//爆弾を破壊
    }
}

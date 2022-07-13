using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class MECHANICAL_PEN_LEAD : StrixBehaviour
{

    private Rigidbody rb;
    private float speed;
    public int durability;
    Quaternion kai;
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 100.0f;
        Invoke("Des", 20);
        rb.velocity = transform.forward * speed;
        durability = 1;
        Player = GameObject.Find("Car");         //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }


    //ステージに当たった際にフラグを切り替える
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            {
                CarSc.SpeedDown();
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Stage")
        {
            rb.isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;//グラビティをなくす
        }
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {
            CarSc.SpeedDown();
            Destroy(this.gameObject);
        }
    }
}

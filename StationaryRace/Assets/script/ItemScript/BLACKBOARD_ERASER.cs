using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLACKBOARD_ERASER : MonoBehaviour
{
    public int durability;//耐久値
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Car");         //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.
        durability = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0)//耐久値が0になったら
        {
            Destroy(this.gameObject);
        }
    }

    //ステージに当たった際にフラグを切り替える
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        //if (collision.gameObject.tag == "Stage")
        {
            {
                durability -= 1;
                CarSc.SpeedDown();
                //this.GetComponent<BoxCollider>().isTrigger = true;//isTriggerをつける
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
            durability -= 1;
            CarSc.SpeedDown();
        }
    }
}

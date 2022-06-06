using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKY_NOTE : MonoBehaviour
{
    private int durability;//耐久値
    private float SpeedNow;
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;

    //testplay PlayerSc; //プレイヤーの関数を呼ぶための準備
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(2, 6); ; //耐久値を2～6でランダムに決める
        Player= GameObject.Find("Car");         //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.
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
        if (collision.gameObject.tag == "Stage")
        {
            {
                this.GetComponent<Rigidbody>().useGravity = false;//グラビティをなくす
                this.GetComponent<BoxCollider>().isTrigger = true;//isTriggerをつける
            }
        }
    }

        void OnTriggerEnter(Collider collider)
        {
            // 衝突した相手にPlayerタグが付いているとき.
            if (collider.gameObject.tag == "Player")
            {
                SpeedNow = CarSc.upspeed;
                durability -= 1;
                StartCoroutine("SpeedUp");
            }
    }
    //スピードアップ
    IEnumerator SpeedUp()
    {
        CarSc.upspeed = 1000.0f;
        yield return new WaitForSeconds(3.0f);
        CarSc.upspeed = SpeedNow;
    }
}

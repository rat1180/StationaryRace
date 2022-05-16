using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKY_NOTE : MonoBehaviour
{
    public int durability;//耐久値
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備.
    //testplay PlayerSc; //プレイヤーの関数を呼ぶための準備
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(2, 6); ; //耐久値を2～6でランダムに決める
        Player= GameObject.Find("Player");         //プレイヤーのゲームオブジェクトを取得.
        //PlayerSc = Player.GetComponent<testplay>(); //プレイヤーのスクリプトを参照する.
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
            this.GetComponent<BoxCollider>().isTrigger = true;//isTriggerをつける
            this.GetComponent<Rigidbody>().useGravity = false;//グラビティをなくす
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
        }
        //ここでプレイヤーのスピードアップ関数を呼び出す
        //PlayerSc.SpeedUp(); //プレーヤースクリプトでスピードアップ関数を呼ぶ
    }
}

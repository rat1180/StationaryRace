using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKY_NOTE : MonoBehaviour
{
    public int durability;//耐久値
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備.
    Car PlayerSc; //プレイヤーの関数を呼ぶための準備
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(2, 6); ; //耐久値を2～6でランダムに決める
        Player= GameObject.Find("Car");         //プレイヤーのゲームオブジェクトを取得.
        PlayerSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.

        this.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0)//耐久値が0になったら
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit");
        // 衝突した相手にPlayerタグが付いているとき.
        if (collision.gameObject.tag == "Player")
        {
            durability -= 1;
        }
        //ここでプレイヤーのスピードアップ関数を呼び出す
        PlayerSc.ItemSpeedUp(); //プレーヤースクリプトでスピードアップ関数を呼ぶ
    }

}

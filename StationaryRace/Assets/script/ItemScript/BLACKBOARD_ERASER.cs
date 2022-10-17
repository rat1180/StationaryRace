using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数値を使うために記入.

public class BLACKBOARD_ERASER : MonoBehaviour
{
    public int durability;   //耐久値
    GameObject Player;       //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;               //Carのスクリプトを取得する.
    GameObject IManager;     //アイテムマネージャーのゲームオブジェクトを取得する準備.
    ItemManager IMSc;        //ItemManagerのスクリプトを取得する.
    public Rigidbody rb;
    public GameObject Effect;//ステージに当たった際の煙のエフェクト

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Car");            //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>();         //プレイヤーのスクリプトを参照する.
        IManager = GameObject.Find("ITEMManager");  //アイテムマネージャーのゲームオブジェクトを取得.
        IMSc = IManager.GetComponent<ItemManager>();//アイテムマネージャーのスクリプトを参照する.
        durability = 1;
    }

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
        Instantiate(Effect, this.transform.position, Quaternion.identity);//煙のエフェクト表示.
        if (collision.gameObject.tag == "Player")
        {
            {
                durability -= 1;
                CarSc.SpeedDown();//Car側の関数を呼び出す
                IMSc.ItemIcon(ITEMConst.ITEM.BLACKBOARD_ERASER);//アイテムHITアイコンに画像を入れる
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Instantiate(Effect, this.transform.position, Quaternion.identity);//エフェクト表示.
        if (collider.gameObject.tag == "Stage")
        {
            rb.isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;//グラビティをなくす
            Instantiate(Effect, this.transform.position, Quaternion.identity);//エフェクト表示.
        }
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
            CarSc.SpeedDown();//Car側の関数を呼び出す
        }
    }
}

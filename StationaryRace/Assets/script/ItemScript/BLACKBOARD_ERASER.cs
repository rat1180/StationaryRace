using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数値を使うために記入.

public class BLACKBOARD_ERASER : MonoBehaviour
{
    public int durability;//耐久値
    GameObject Player;    //プレイヤーのゲームオブジェクトを取得する準備.
    Car CarSc;
    GameObject IManager; //アイテムマネージャーのゲームオブジェクトを取得する準備.
    ItemManager IMSc;
    public Rigidbody rb;
    public GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Car");    //プレイヤーのゲームオブジェクトを取得.
        CarSc = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.
        IManager = GameObject.Find("ITEMManager");    //アイテムマネージャーのゲームオブジェクトを取得.
        IMSc = IManager.GetComponent<ItemManager>(); //アイテムマネージャーのスクリプトを参照する.
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
        Instantiate(Effect, this.transform.position, Quaternion.identity);//エフェクト表示.
        if (collision.gameObject.tag == "Player")
        //if (collision.gameObject.tag == "Stage")
        {
            {
                durability -= 1;
                CarSc.SpeedDown();
                IMSc.ItemIcon(ITEMConst.ITEM.BLACKBOARD_ERASER);
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
            print("bbb");
        }
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
            CarSc.SpeedDown();
        }
    }
}

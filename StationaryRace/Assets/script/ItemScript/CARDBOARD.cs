using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;


public class CARDBOARD : StrixBehaviour
{
    public GameObject SOUND;
    private int durability;
    private Rigidbody rb;
    GameObject IManager; //アイテムマネージャーのゲームオブジェクトを取得する準備.
    ItemManager IMSc;//ItemManagerのスクリプトを取得する.

    void Start()
    {
        if (!isLocal) return;
        rb = GetComponent<Rigidbody>();
        durability = 1;
        rb.velocity = transform.forward;//向きを取得.
        Instantiate(SOUND, this.transform.position, Quaternion.identity);//段ボールの音を出す.
        IManager = GameObject.Find("ITEMManager");    //アイテムマネージャーのゲームオブジェクトを取得.
        IMSc = IManager.GetComponent<ItemManager>(); //アイテムマネージャーのスクリプトを参照する.
    }

    void Update()
    {

        if (!isLocal) return;
        if (durability == 0)//耐久値が0になったら
        {
            IMSc.ItemIcon(ITEMConst.ITEM.CARDBOARD);//アイテムHITアイコンを出す.
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手にPlayerタグが付いているとき.
        if (collision.gameObject.tag == "Player")
        {
            durability -= 1;
        }
    }
}

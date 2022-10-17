using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class MAGIC_PEN : StrixBehaviour
{
    private Rigidbody rb;
    private float speed;    //スピード設定用.
    public int durability;  //対kひゅうち設定.
    GameObject ItemMana;    //アイテムマネージャーの取得.
    ItemManager IMana;      //アイテムマネージャーのスクリプトを取得.

    // Start is called before the first frame update
    void Start()
    {
        ItemMana = GameObject.Find("ITEMManager");   //アイテムマネージャーを取得.
        IMana = ItemMana.GetComponent<ItemManager>();//アイテムマネージャーのスクリプトを取得

        rb = GetComponent<Rigidbody>();         //Rigidbodyを取得
        speed = 100.0f;                         //スピードを設定
        Invoke("Des", 10);                      //何にも当たらなければ破壊する.
        rb.velocity = transform.forward * speed;//向いている方向を取得
        durability = 1;                         //耐久値
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;//向いている方向に進ませる.
        if (durability <= 0)//耐久値が0以下になったら
        {
            IMana.INK();        //墨汁を出す関数を呼び出す.
            Des();
        }
    }
    /// <summary>
    /// 耐久値が0になった時にこのオブジェクトを破壊する関数
    /// </summary>
    void Des()
    {
        Destroy(this.gameObject);
        IMana.ItemIcon(ITEMConst.ITEM.MAGIC_PEN);//アイテムHITアイコンを出す.
    }

    void OnTriggerEnter(Collider collider)
    {
        durability -= 1;
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {  }
    }
}


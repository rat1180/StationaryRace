using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class MAGIC_PEN : StrixBehaviour
{
    private Rigidbody rb;
    private float speed;
    public int durability;
    GameObject ItemMana;
    ItemManager IMana;

    // Start is called before the first frame update
    void Start()
    {
        ItemMana = GameObject.Find("ITEMManager");   //アイテムマネージャーを取得.
        IMana = ItemMana.GetComponent<ItemManager>();//アイテムマネージャーのスクリプトを取得

        rb = GetComponent<Rigidbody>();//Rigidbodyを取得
        speed = 100.0f;//スピードを設定
        //Invoke("Des", 10);
        rb.velocity = transform.forward * speed;//向いている方向を取得
        durability = 1;//耐久値、１   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        if (durability <= 0)//耐久値が0以下になったら
        {
            IMana.INK();
            Des();
        }
    }
    /// <summary>
    /// 耐久値が0になった時にこのオブジェクトを破壊する関数
    /// </summary>
    void Des()
    {
        Destroy(this.gameObject);
        IMana.ItemIcon(ITEMConst.ITEM.MAGIC_PEN);
    }

    void OnTriggerEnter(Collider collider)
    {
        durability -= 1;
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {

        }
    }
}


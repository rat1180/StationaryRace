using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class ERASER_RESIDDUE : StrixBehaviour
{
    public int durability;//耐久値
    GameObject IManager;  //アイテムマネージャーのゲームオブジェクトを取得する準備.
    ItemManager IMSc;     //アイテムマネージャーのスクリプトを取得する.

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal) return;
        Invoke("Des", 5);                             //5秒後に破壊する.
        IManager = GameObject.Find("ITEMManager");    //アイテムマネージャーのゲームオブジェクトを取得.
        IMSc = IManager.GetComponent<ItemManager>();  //アイテムマネージャーのスクリプトを参照する.
    }

    void Update(){}

    //ステージに当たった際にフラグを切り替える
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
                this.GetComponent<Rigidbody>().useGravity = false;     //グラビティをなくす
                this.GetComponent<CapsuleCollider>().isTrigger = true; //isTriggerをつける
        }
        if (collision.gameObject.tag == "Player")
        {
            Des();
        }
        }
    //自身を破壊する関数.
    void Des()
    {
        //IMSc.ItemIcon(ITEMConst.ITEM.ERASER_RESIDDUE);
        Destroy(this.gameObject);
    }
}

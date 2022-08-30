using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAPE_BALL : MonoBehaviour
{
    private int durability;
    public Vector3 Pos;
    GameObject IManager; //アイテムマネージャーのゲームオブジェクトを取得する準備.
    ItemManager IMSc;
    // Start is called before the first frame update
    void Start()
    {
        durability = 1;
        Pos = this.transform.position;
        IManager = GameObject.Find("ITEMManager");    //アイテムマネージャーのゲームオブジェクトを取得.
        IMSc = IManager.GetComponent<ItemManager>(); //アイテムマネージャーのスクリプトを参照する.
    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0)//耐久値が0になったら
        {
            IMSc.ItemIcon(ITEMConst.ITEM.TAPE_BALL);
            Destroy(this.gameObject);
        }
        Pos.y += 5;
        Pos.z += 5;
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

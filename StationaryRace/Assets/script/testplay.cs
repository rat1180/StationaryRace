using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplay : MonoBehaviour
{
    public float speed = 0.1f;
    public bool itemhave = false;
    private int USER_Num = 0;//ユーザ番号
    ItemManager IManager;//アイテムマネージャー参照準備

    GameObject ItemMana;       //アイテムマネージャーのゲームオブジェクトを取得する準備.

    // Start is called before the first frame update
    void Start()
    {
        ItemMana = GameObject.Find("ITEMManager");   //アイテムマネージャーを取得.
        IManager = ItemMana.GetComponent<ItemManager>();
        USER_Num = 1; //ユーザー番号（ここでは試験的に1）
    }

    // Update is called once per frame
    void Update()
    {
        //キー入力で移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        //スペースキーでアイテムの使用（テスト）
        if (Input.GetKey(KeyCode.Space))
        {
            IManager.Item_Use(USER_Num);//
            itemhave = false;
        }
    }
    public void ItemHave()
    {
        IManager.USER_NUM(USER_Num);
        itemhave = true;
    }

    public int NUMBER_RETURN() //ユーザー番号を返す関数
    {
        return USER_Num;
    }
}

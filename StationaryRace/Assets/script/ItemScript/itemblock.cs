using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemblock : MonoBehaviour
{
    int ItemNum = 0;           //アイテムマネージャーに数値を渡す用変数.
    int USER_NUM = 0;          //ユーザー番号
    GameObject ItemMana;       //アイテムマネージャーのゲームオブジェクトを取得する準備.
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備. 
    testplay ItemHave;         //スクリプトを参照する準備.
    public AudioClip Dessound; //CDみたいなもの.
    AudioSource audioSource;   //CDプレイヤーみたいなもの.
    public GameObject SetBox_particle; //アイテムボックスが破壊されたらパーティクルを生成

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得.
        audioSource = GetComponent<AudioSource>();  //オーディオソースの取得.
        ItemMana = GameObject.Find("ITEMManager");  //アイテムマネージャーを取得.
        Player = GameObject.Find("Car");            //プレイヤーのゲームオブジェクトを取得.
        ItemHave = Player.GetComponent<testplay>(); //プレイヤーのスクリプトを参照する.
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {  
        if (collision.gameObject.tag == "Car")// 衝突した相手にCarタグが付いているとき.
        {
         AudioSource.PlayClipAtPoint(Dessound, transform.position); //アイテムが破壊された際に効果音を鳴らす.

         this.gameObject.SetActive(false);                                           //アイテムブロックのゲームオブジェクトを非表示にする.
         Instantiate(SetBox_particle, this.transform.position, Quaternion.identity); //パーティクルを生成.

            if (ItemHave.itemhave == false)//プレイヤーがアイテムを持っていなければアイテムマネージャーに数値を渡す.
            {
                USER_NUM = ItemHave.NUMBER_RETURN();                         //どのプレイヤーがアイテムを取得したか番号を参照.
                ItemNum = Random.Range(100, 112);                            //100～111の範囲でランダムな整数値が返る(int型だと後ろは除外される).
                ItemMana.GetComponent<ItemManager>().Item(USER_NUM,ItemNum); //ItemManagerというスクリプトのItem関数を使う.
                ItemHave.ItemHave();                                         //プレーヤースクリプトでアイテムフラグをtrueにする.
            }
            Invoke("Respawn", 3); //3秒後にその場に複製される.
        }
    }

    void Respawn()//アイテムボックス復活用関数.
    {
        Instantiate(SetBox_particle, this.transform.position, Quaternion.identity); //パーティクルを生成.
        this.gameObject.SetActive(true);
    }
}
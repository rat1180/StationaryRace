using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class itemblock : MonoBehaviour
{
    int ItemNum = 0;           //アイテムマネージャーに数値を渡す用変数.
    int USER_NUM = 1;          //ユーザー番号
    GameObject ItemMana;       //アイテムマネージャーのゲームオブジェクトを取得する準備.
    GameObject Player;         //プレイヤーのゲームオブジェクトを取得する準備. 
    Car ItemHave;         //スクリプトを参照する準備.
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
        ItemHave = Player.GetComponent<Car>(); //プレイヤーのスクリプトを参照する.
    }

    // Update is called once per frame
    void Update()
    {
    }
    //ステージに当たった際にフラグを切り替える
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            {
                this.GetComponent<Rigidbody>().useGravity = false;//グラビティをなくす
                this.GetComponent<BoxCollider>().isTrigger = true;//isTriggerをつける
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")// 衝突した相手にPlayerタグが付いているとき.
        {
            StrixReplicator Check = collider.transform.parent.GetComponent<StrixReplicator>();
            if (Check == null || !(Check.isLocal)) return;
            AudioSource.PlayClipAtPoint(Dessound, transform.position); //アイテムが破壊された際に効果音を鳴らす.

            this.gameObject.SetActive(false);                                           //アイテムブロックのゲームオブジェクトを非表示にする.
            Instantiate(SetBox_particle, this.transform.position, Quaternion.identity); //パーティクルを生成.

            if (ItemHave.itemhave == false)//プレイヤーがアイテムを持っていなければアイテムマネージャーに数値を渡す.
            {
                //USER_NUM = ItemHave.NUMBER_RETURN();                         //どのプレイヤーがアイテムを取得したか番号を参照.
                ItemMana.GetComponent<ItemManager>().Item(); //ItemManagerというスクリプトのItem関数を使う.
                ItemHave.itemhave = true;                                         //プレーヤースクリプトでアイテムフラグをtrueにする.
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst;

public class itemblock : MonoBehaviour
{
    int rnd = 0;
    GameObject ItemNum; //アイテムマネージャーにナンバーを送る準備
    public AudioClip Dessound;              //CDみたいなもの
    AudioSource audioSource;               //CDプレイヤーみたいなもの
    bool soundflg = false;
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        audioSource = GetComponent<AudioSource>();
        ItemNum = GameObject.Find("ITEMManager");//アイテムマネージャーを探す
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Player")
        {
         AudioSource.PlayClipAtPoint(Dessound, transform.position);
         // 0.1秒後に消える

         Destroy(gameObject, 0.1f);
         rnd = Random.Range(100, 111); // ※ 100～110の範囲でランダムな整数値が返る(int型だと後ろは除外される)
         //Debug.Log(rnd);
         ItemNum.GetComponent<ItemManager>().Item(rnd);//ItemManagerというスクリプトのItem関数を使う
         }
    }

}
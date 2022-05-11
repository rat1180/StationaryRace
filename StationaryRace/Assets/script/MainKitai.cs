using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    public int KitaiNumber = 0;        //機体番号
    private int o_max = 0;             //機体数
    GameObject[] kitaiObject;          //オブジェクトの割り当て

    // Start is called before the first frame update
    void Start()
    {
        o_max = this.transform.childCount;        //子オブジェクトの個数を取得
        kitaiObject = new GameObject[o_max];      //インスタンス作成

        //全ての子オブジェクトを取得
        for(int i = 0; i < o_max; i++)
        {
            kitaiObject[i] = transform.GetChild(i).gameObject;
        }

        //全ての子オブジェクトを非アクティブ
        foreach (GameObject gamObj in kitaiObject)
        {
            gamObj.SetActive(false);
        }
        //一つだけアクティブにする
        kitaiObject[KitaiNumber].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //現在のアクティブな子オブジェクトを非アクティブ
            kitaiObject[KitaiNumber].SetActive(false);
            KitaiNumber++;

            //子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
            if (KitaiNumber == o_max) { KitaiNumber = 0; }

            //次のオブジェクトをアクティブ化
            kitaiObject[KitaiNumber].SetActive(true);
        }
    }
}
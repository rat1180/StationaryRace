using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    private int index = 0;
    private int o_max = 0;             //機体数
    public int KitaiNumber;            //機体番号
    //public Material[] _material;       //テクスチャの割り当て
    GameObject[] kitaiObject;   //オブジェクトの割り当て

    // Start is called before the first frame update
    void Start()
    {
        o_max = this.transform.childCount;     //子オブジェクトの個数を取得
        kitaiObject = new GameObject[o_max];

        for(int i = 0; i < o_max; i++)
        {
            kitaiObject[i] = transform.GetChild(i).gameObject;
        }


        foreach (GameObject gamObj in kitaiObject)
        {
            gamObj.SetActive(false);
        }
        kitaiObject[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //現在のアクティブな子オブジェクトを非アクティブ
            kitaiObject[index].SetActive(false);
            index++;

            //子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
            if (index == o_max) { index = 0; }

            //次のオブジェクトをアクティブ化
            kitaiObject[index].SetActive(true);
        }
    }

    /*
    //選択された機体の番号を受け取る
    public void KitaiSet(int type)
    {
        KitaiNumber = type;

        //機体のテクスチャ変更
        switch (type)
        {
            case 0:
                this.GetComponent<Renderer>().material = kitaiObject[0];
                break;
            case 1:
                this.GetComponent<Renderer>().material = kitaiObject[1];
                break;
            case 2:
                this.GetComponent<Renderer>().material = kitaiObject[2];
                break;
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    public int MachineNum = 0;         //機体番号
    private int o_max = 0;             //機体数
    GameObject[] kitaiObject;          //オブジェクトの割り当て

    public int Player_Mode = 0; //プレーヤーの状態

    private const int StartRase = 10;   //レース前
    private const int RaseNow = 20;     //レース中
    private const int Goal = 30;        //ゴール
    private const int AttackItem = 40;  //攻撃アイテムが当たった
    private const int DownStage = 50;   //ステージから落ちた
    private const int ORIGAMI_CRANE = 60;//鶴の折り紙に変身

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
        kitaiObject[MachineNum].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //現在のアクティブな子オブジェクトを非アクティブ
            kitaiObject[MachineNum].SetActive(false);
            MachineNum++;

            //子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
            if (MachineNum == o_max) { MachineNum = 0; }

            //次のオブジェクトをアクティブ化
            kitaiObject[MachineNum].SetActive(true);
        }
    }
}
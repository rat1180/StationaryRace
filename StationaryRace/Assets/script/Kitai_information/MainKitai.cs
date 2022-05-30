using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    private int o_max = 2;             //最大機体番号
    private float min_y = -13.0f;

    public int Player_Mode = 0;        //機体の状態

    private const int CharacterChenge =  0;    //キャラ選択
    private const int StartRace       = 10;    //レース前
    private const int RaseNow         = 20;    //レース中
    private const int Goal            = 30;    //ゴール
    private const int AttackItem      = 40;    //攻撃アイテムが当たった
    private const int DownStage       = 50;    //ステージから落ちた
    private const int ORIGAMI_CRANE   = 60;    //鶴の折り紙に変身

    public int MachineNum = 0;         //機体番号
    GameObject[] kitaiObject;          //オブジェクトの割り当て

    ////機体の性能
    //public struct KitaiAblty
    //{

    //}

    //public struct KitaiNum
    //{
    //    public int num;
    //}

    // Start is called before the first frame update
    void Start()
    {
        o_max = this.transform.childCount;        //子オブジェクトの個数を取得
        kitaiObject = new GameObject[o_max];      //インスタンス作成

        //全ての子オブジェクトを取得
        for (int i = 0; i < o_max; i++)
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
        switch (Player_Mode)
        {
            //キャラ選択
            case 0:
                MachineNumber();
                break;
            //スタート前
            case 10:
                break;
            //レース中
            case 20:
                break;
            //ゴール
            case 30:
                break;
            case 40:
                break;
            //落下時
            case 50:
                break;
            default:
                Debug.Log("PlayerModeエラー");
                break;
        }
    }

    //機体の状態の受け取り
    public void MachineMode()
    {
        //Player_Mode = mode;

        //if (Player_Mode == 10)
        //{
        //    MachineNumber();
        //}
    }

    public void MachineNumber()
    {
        //MachineNum = machine_num;

        if (Input.GetKeyDown("q"))
        {
            //現在のアクティブな子オブジェクトを非アクティブ
            kitaiObject[MachineNum].SetActive(false);
            MachineNum++;

            //子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
            if (MachineNum == o_max) { MachineNum = 0; }

            KitaiChange();

        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Player_Mode = 10;
            Debug.Log("キャラ選択終わり");
        }
    }

    //ユーザーから機体番号の受け取り
    private void KitaiChange()
    {
        switch (MachineNum)
        {
            case 0:
                //次のオブジェクトをアクティブ化
                kitaiObject[MachineNum].SetActive(true);
                Debug.Log(MachineNum);
                break;
            case 1:
                //次のオブジェクトをアクティブ化
                kitaiObject[MachineNum].SetActive(true);
                Debug.Log(MachineNum);
                break;
            case 2:
                //次のオブジェクトをアクティブ化
                kitaiObject[MachineNum].SetActive(true);
                Debug.Log(MachineNum);
                break;
            case 3:
                break;
            default:
                Debug.LogError("機体番号が呼び出されませんでした");
                break;
        }
    }
}
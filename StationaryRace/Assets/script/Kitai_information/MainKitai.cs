using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    public int MachineNum = 0;        //機体番号
    private int o_max = 0;             //機体数
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
        //if (Input.GetKeyDown("q"))
        //{
        //    //現在のアクティブな子オブジェクトを非アクティブ
        //    kitaiObject[MachineNum].SetActive(false);
        //    MachineNum++;

        //    //子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
        //    if (MachineNum == o_max) { MachineNum = 0; }

        //    //次のオブジェクトをアクティブ化
        //    kitaiObject[MachineNum].SetActive(true);
        //    Debug.Log(MachineNum);
        //}

        MachineNumber();
    }

    //ユーザーから機体番号の受け取り
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
                    Debug.Log("機体番号が呼び出されませんでした");
                    break;
            }
        }
    }
}
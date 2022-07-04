using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectKitai : MonoBehaviour
{
    private int mode = 0;              //機体の状態
    private int MachineNum = 0;        //機体番号
    private int SkinNum = 0;

    public GameObject Skin;            //オブジェクトの割り当て

    // Start is called before the first frame update
    void Start()
    {
        Skin = this.transform.Find("Skin").gameObject;

        //Skin内の全ての子オブジェクトを非アクティブ
        for (int i = 0; i < Skin.transform.childCount; i++)
        {
            Skin.transform.GetChild(i).gameObject.SetActive(false);
        }

        //最初の一つをアクティブ
        Skin.transform.GetChild(SkinNum).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            //キャラ選択
            case 0:
                KeyProcess();
                break;
            case 1:
                SelectOff();
                break;
            default:
                Debug.Log("PlayerModeエラー");
                break;
        }
    }

    /// <summary>
    /// キーボード処理
    /// </summary>
    private void KeyProcess()
    {
        //Qキー押下
        if (Input.GetKeyDown("q"))
        {
            //現在のアクティブな子オブジェクトを非アクティブ
            Skin.transform.GetChild(MachineNum).gameObject.SetActive(false);
            MachineNum++;

            //子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
            if (MachineNum == Skin.transform.childCount) { MachineNum = 0; }

            KitaiChange();   //機体変更

        }

        //Enterキー押下
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //スタート前へシーン切り替え
            //SceneManager.LoadScene("Kitai");
            mode = 1;
                Debug.Log("キャラ選択終わり");
        }
    }

    /// <summary>
    /// 機体のテクスチャと性能の切り替え
    /// </summary>
    private void KitaiChange()
    {
        switch (MachineNum)
        {
            case 0:
                //次のオブジェクトをアクティブ化
                Skin.transform.GetChild(MachineNum).gameObject.SetActive(true);
                Debug.Log("機体番号 : " + MachineNum);
                break;
            case 1:
                Skin.transform.GetChild(MachineNum).gameObject.SetActive(true);
                Debug.Log("機体番号 : " + MachineNum);
                break;
            case 2:
                Skin.transform.GetChild(MachineNum).gameObject.SetActive(true);
                Debug.Log("機体番号 : " + MachineNum);
                break;
            case 3:
                break;
            default:
                Debug.LogError("機体番号が呼び出されませんでした");
                break;
        }
    }

    public void SelectOff()
    {
        this.GetComponent<SelectKitai>().enabled = false;
    }
}

class SceneLoder
{

}
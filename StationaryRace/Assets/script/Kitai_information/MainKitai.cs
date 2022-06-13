using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainKitai : MonoBehaviour
{
    public int Player_Mode = 10;        //機体の状態
    public GameObject Skin;            //オブジェクトの割り当て

    private const int CharacterChenge =  0;    //キャラ選択
    private const int StartRace       = 10;    //レース前
    private const int RaseNow         = 20;    //レース中
    private const int Goal            = 30;    //ゴール
    private const int AttackItem      = 40;    //攻撃アイテムが当たった
    private const int DownStage       = 50;    //ステージから落ちた
    private const int ORIGAMI_CRANE   = 60;    //鶴の折り紙に変身

    private int MachineNum = 0;         //機体番号
    private int SkinNum = 0;

    public CountTime countTime;
    private float Atime = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PLmode();
    }

    private void PLmode()
    {
        Atime -= Time.deltaTime;

        switch (Player_Mode)
        {
            ////キャラ選択
            //case 0:
            //    KeyProcess();
            //    break;
            //スタート前
            case 10:
                MachineMode();
                break;
            //レース中
            case 20:
                if(Atime <= 0)
                {
                    Player_Mode = 30;
                }
                break;
            //ゴール
            case 30:
                Debug.Log("ゴール");
                SceneManager.LoadScene("KitaiSelect");
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
    private void MachineMode()
    {
        //if (Player_Mode == 0)
        //{
        //    MachineNumber();
        //}

        if (countTime.gamestart == 1)
        {
            Player_Mode = 20;
            Debug.Log("レース中");
        }
    }
}
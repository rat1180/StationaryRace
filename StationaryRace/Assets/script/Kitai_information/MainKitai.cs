using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SoftGear.Strix.Unity.Runtime;

public class MainKitai : MonoBehaviour
{
    #region 変数宣言
    private const int CharacterChenge = 0;    //キャラ選択
    private const int StartRace = 10;    //レース前
    private const int RaseNow = 20;    //レース中
    private const int Goal = 30;    //ゴール
    private const int AttackItem = 40;    //攻撃アイテムが当たった
    private const int DownStage = 50;    //ステージから落ちた
    private const int ORIGAMI_CRANE = 60;    //鶴の折り紙に変身

    private float Atime;           //テスト用タイマー

    public int Player_Mode;        //機体の状態
    public GameObject Skin;             //オブジェクトの割り当て
    public CountTime countTime;         //CountTimeスクリプトへ参照
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Atime = 10;
        Player_Mode = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isLocal) return;
        PLmode();
    }

    /// <summary>
    /// プレイヤーの状態管理
    /// </summary>
    private void PLmode()
    {
        Atime -= Time.deltaTime;

        switch (Player_Mode)
        {
            //キャラ選択
            case 0:
                //KeyProcess();
                break;
            //スタート前
            case 10:
                MachineMode();
                break;
            //レース中
            case 20:
                if (Atime <= 0)
                {
                    Player_Mode = 30;
                }
                break;
            //ゴール
            case 30:
                Debug.Log("ゴール");
                SceneManager.LoadScene("KitaiSelect");
                break;
            //攻撃アイテムに衝突
            case 40:
                break;
            //落下時
            case 50:
                break;
            //鶴の折り紙に変身
            case 60:
                break;
            default:
                Debug.Log("PlayerModeエラー");
                break;
        }
    }

    /// <summary>
    /// 機体の状態の受け取り
    /// </summary>
    private void MachineMode()
    {
        if (countTime.gamestart == 1)
        {
            Player_Mode = 20;
            Debug.Log("レース中");
        }
    }
}
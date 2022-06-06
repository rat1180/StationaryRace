using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキストを扱う場合は、using UnityEngine.UI; を忘れずに記述

using ITEMConst;
public class UI : MonoBehaviour
{
    // 値を受け取るための変数
    public static int rank;                        
    public int draw_item;

    // 順位表示のオブジェクト
    public GameObject RankNunber1;                
    public GameObject RankNunber2;                 
    public GameObject RankNunber3;                　
    public GameObject RankNunber4;                 
    public GameObject RankNunber5;                 
    public GameObject RankNunber6;            
    
    // アイテム表示のオブジェクト
    public GameObject Item_nunber1;
    public GameObject Item_nunber2;
    public GameObject Item_nunber3;
    public GameObject Item_nunber4;
    public GameObject Item_nunber5;
    public GameObject Item_nunber6;
    public GameObject Item_nunber7;
    public GameObject Item_nunber8;
    public GameObject Item_nunber9;
    public GameObject Item_nunber10;
    public GameObject Item_nunber11;
    public GameObject Item_nunber12;
    //public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        RankNunber1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        DRAW_SCORE();
        DRAW_ITEM();
    }
    public void RankingChange(int ranker) // 他スクリプトから値を受け取る 
    {
        rank = ranker;
    }
    // 値によって表示するオブジェクトを変える
    void DRAW_SCORE()
    {
        RankNunber1.SetActive(false);
        RankNunber2.SetActive(false);
        RankNunber3.SetActive(false);
        RankNunber4.SetActive(false);
        RankNunber5.SetActive(false);
        RankNunber6.SetActive(false);
        switch (rank)
        {
            case 1:
                RankNunber1.SetActive(true);
                break;
            case 2:
                RankNunber2.SetActive(true);
                break;
            case 3:
                RankNunber3.SetActive(true);
                break;
            case 4:
                RankNunber4.SetActive(true);
                break;
            case 5:
                RankNunber5.SetActive(true);
                break;
            case 6:
                RankNunber6.SetActive(true);
                break;
            default:
                break;
           
        }


    }
    // 上の処理と同じ
    public void ITEM_CHANGE(int item)
    {
        draw_item = item;
    }
    void DRAW_ITEM()
    {
        Item_nunber1.SetActive(false);
        Item_nunber2.SetActive(false);
        Item_nunber3.SetActive(false);
        Item_nunber4.SetActive(false);
        Item_nunber5.SetActive(false);
        Item_nunber6.SetActive(false);
        Item_nunber7.SetActive(false);
        Item_nunber8.SetActive(false);
        Item_nunber9.SetActive(false);
        Item_nunber10.SetActive(false);
        Item_nunber11.SetActive(false);
        Item_nunber12.SetActive(false);

        switch (draw_item)
        {
            case ITEM.ERASER_RESIDDUE:
                Item_nunber1.SetActive(true);
                Debug.Log(draw_item);
                break;
            case ITEM.BIRIBIRI_PEN:
                Item_nunber2.SetActive(true);
                break;
            case ITEM.MECHANICAL_PEN_LEAD:
                Item_nunber3.SetActive(true);
                Debug.Log(draw_item);
                break;
            case ITEM.STICKY_NOTE:
                Item_nunber4.SetActive(true);
                break;
            case ITEM.TAPE_BALL:
                Item_nunber5.SetActive(true);
                break;
            case ITEM.SCOTCH_TAPE:
                Item_nunber6.SetActive(true);
                break;
            case ITEM.MAGIC_PEN:
                Item_nunber7.SetActive(true);
                break;
            case ITEM.CARDBOARD:
                Item_nunber8.SetActive(true);
                break;
            case ITEM.KESHIKASU_BOM:
                Item_nunber9.SetActive(true);
                break;
            case ITEM.BLACKBOARD_ERASER:
                Item_nunber10.SetActive(true);
                Debug.Log(draw_item);
                break;
            case ITEM.ORIGAMI_CRANE:
                Item_nunber11.SetActive(true);
                break;
            case ITEM.INDIA_INK:
                Item_nunber12.SetActive(true);
                break;
            default:
                break;
        }
    }
}

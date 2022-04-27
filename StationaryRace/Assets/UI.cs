using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキストを扱う場合は、using UnityEngine.UI; を忘れずに記述

public class UI : MonoBehaviour
{
    public static int rank;
    public static int draw_item;
    public GameObject ranknunber1;                 //スコア表示用の宣言
    public GameObject ranknunber2;                 //スコア表示用の宣言
    public GameObject ranknunber3;                 //スコア表示用の宣言
    public GameObject ranknunber4;                 //スコア表示用の宣言
    public GameObject ranknunber5;                 //スコア表示用の宣言
    public GameObject ranknunber6;                 //スコア表示用の宣言

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
    //public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DRAW_SCORE();
        DRAW_ITEM();
    }
    public void RankingChange(int ranker)
    {
        rank = ranker;
    }
    void DRAW_SCORE()
    {
        ranknunber1.SetActive(false);
        ranknunber2.SetActive(false);
        ranknunber3.SetActive(false);
        ranknunber4.SetActive(false);
        ranknunber5.SetActive(false);
        ranknunber6.SetActive(false);
        switch (rank)
        {
            case 1:
                ranknunber1.SetActive(true);
                break;
            case 2:
                ranknunber2.SetActive(true);
                break;
            case 3:
                ranknunber3.SetActive(true);
                break;
            case 4:
                ranknunber4.SetActive(true);
                break;
            case 5:
                ranknunber5.SetActive(true);
                break;
            case 6:
                ranknunber6.SetActive(true);
                break;
            case -1:
                ranknunber1.SetActive(false);
                ranknunber2.SetActive(false);
                ranknunber3.SetActive(false);
                ranknunber4.SetActive(false);
                ranknunber5.SetActive(false);
                ranknunber6.SetActive(false);
                break;


        }


    }
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

        switch (draw_item)
        {
            case 1:
                Item_nunber1.SetActive(true);
                break;
            case 2:
                Item_nunber2.SetActive(true);
                break;
            case 3:
                Item_nunber3.SetActive(true);
                break;
            case 4:
                Item_nunber4.SetActive(true);
                break;
            case 5:
                Item_nunber5.SetActive(true);
                break;
            case 6:
                Item_nunber6.SetActive(true);
                break;
            case 7:
                Item_nunber7.SetActive(true);
                break;
            case 8:
                Item_nunber8.SetActive(true);
                break;
            case 9:
                Item_nunber9.SetActive(true);
                break;
            case 10:
                Item_nunber10.SetActive(true);
                break;
            case -1:
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
                break;


        }
    }
}

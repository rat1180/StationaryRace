using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキストを扱う場合は、using UnityEngine.UI; を忘れずに記述

public class UI : MonoBehaviour
{
    public static int rank;
    //public static int draw;
    public GameObject ranknunber1;                 //スコア表示用の宣言
    public GameObject ranknunber2;                 //スコア表示用の宣言
    public GameObject ranknunber3;                 //スコア表示用の宣言
    public GameObject ranknunber4;                 //スコア表示用の宣言
    public GameObject ranknunber5;                 //スコア表示用の宣言
    public GameObject ranknunber6;                 //スコア表示用の宣言

    //public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DRAW_SCORE();
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


        }


    }
    //public void DRAW_ITEM(int item,int dereate_item)
    //{

    //}
}

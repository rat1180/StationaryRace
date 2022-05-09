using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキストを扱う場合は、using UnityEngine.UI; を忘れずに記述

public class Result : MonoBehaviour
{
    public int   decide_rank;
    public float decide_time;
    public Text TimeText;                 //タイム表示用の宣言
    public Text RankText;                 //順位表示用の宣言
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Draw_Ranking();
        Draw_Timer();
    }
    public void Decide_Ranking(int rank) // 他スクリプトから値を受け取る 
    {
        decide_rank = rank;
    }
    void Draw_Ranking()
    {
        RankText.text = decide_rank.ToString();
    }

    public void Decide_Timer(int time) // 他スクリプトから値を受け取る 
    {
        decide_time = time;
    }
    void Draw_Timer()
    {
        TimeText.text = decide_time.ToString();
    }
}

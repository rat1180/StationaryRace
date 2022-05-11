using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�e�L�X�g�������ꍇ�́Ausing UnityEngine.UI; ��Y�ꂸ�ɋL�q

public class Result : MonoBehaviour
{
    public int   decide_rank;
    public float decide_time;
    public Text TimeText;                 //�^�C���\���p�̐錾
    public Text RankText;                 //���ʕ\���p�̐錾
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
    public void Decide_Ranking(int rank) // ���X�N���v�g����l���󂯎�� 
    {
        decide_rank = rank;
    }
    void Draw_Ranking()
    {
        RankText.text = decide_rank.ToString();
    }

    public void Decide_Timer(int time) // ���X�N���v�g����l���󂯎�� 
    {
        decide_time = time;
    }
    void Draw_Timer()
    {
        TimeText.text = decide_time.ToString();
    }
}

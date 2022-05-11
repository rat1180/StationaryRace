using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�e�L�X�g�������ꍇ�́Ausing UnityEngine.UI; ��Y�ꂸ�ɋL�q

using ITEMConst;
public class UI : MonoBehaviour
{
    // �l���󂯎�邽�߂̕ϐ�
    public static int rank;                        
    public int draw_item;

    // ���ʕ\���̃I�u�W�F�N�g
    public GameObject RankNunber1;                
    public GameObject RankNunber2;                 
    public GameObject RankNunber3;                �@
    public GameObject RankNunber4;                 
    public GameObject RankNunber5;                 
    public GameObject RankNunber6;            
    
    // �A�C�e���\���̃I�u�W�F�N�g
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
    public void RankingChange(int ranker) // ���X�N���v�g����l���󂯎�� 
    {
        rank = ranker;
    }
    // �l�ɂ���ĕ\������I�u�W�F�N�g��ς���
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
            case -1:
                RankNunber1.SetActive(false);
                RankNunber2.SetActive(false);
                RankNunber3.SetActive(false);
                RankNunber4.SetActive(false);
                RankNunber5.SetActive(false);
                RankNunber6.SetActive(false);
                break;


        }


    }
    // ��̏����Ɠ���
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
            case ITEM.ENPITU:
                Item_nunber1.SetActive(true);
                Debug.Log(draw_item);
                break;
            case ITEM.ERASER_RESIDDUE:
                Item_nunber2.SetActive(true);
                Debug.Log(draw_item);
                break;
            case ITEM.BLACKBOARD_ERASER:
                Item_nunber3.SetActive(true);
                Debug.Log(draw_item);
                break;
            case ITEM.MECHANICAL_PEN_LEAD:
                Item_nunber4.SetActive(true);
                Debug.Log(draw_item);
                break;
            case ITEM.STICKY_NOTE:
                Item_nunber5.SetActive(true);
                break;
            case ITEM.TAPE_BALL:
                Item_nunber6.SetActive(true);
                break;
            case ITEM.SCOTCH_TAPE:
                Item_nunber7.SetActive(true);
                break;
            case ITEM.MAGIC_PEN:
                Item_nunber8.SetActive(true);
                break;
            case ITEM.ORIGAMI_CRANE:
                Item_nunber9.SetActive(true);
                break;
            case ITEM.BIRIBIRI_PEN:
                Item_nunber10.SetActive(true);
                break;
            case ITEM.ItemNull:
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

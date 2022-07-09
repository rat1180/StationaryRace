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
    public GameObject RankNunber;                
    
    public string[] RankUI = new string[6]; // �A�C�e���̉摜�̔z��
    // �A�C�e���\���̃I�u�W�F�N�g
    public GameObject Item_nunber;
   
    public Sprite[] ItemUI = new Sprite[13]; // �A�C�e���̉摜�̔z��
    //public Text ScoreText;

    #region �e�X�g
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // RankNunber.SetActive(true);

        #region �e�X�g
        Player = GameObject.Find("Car");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //DRAW_SCORE();
        //DRAW_ITEM();
    }
    public void RankingChange(int ranker) // ���X�N���v�g����l���󂯎�� 
    {
        rank = ranker;
    }
    // �l�ɂ���ĕ\������I�u�W�F�N�g��ς���
    void DRAW_SCORE()
    {
        switch (rank)
        {
            case 1:
                RankNunber.GetComponent<Text>().text = RankUI[0];
                break;
            case 2:
                RankNunber.GetComponent<Text>().text = RankUI[1];
                RankNunber.GetComponent<Text>().color = new Color(255.0f, 0.0f, 0.0f, 255.0f);
                break;
            case 3:
                RankNunber.GetComponent<Text>().text = RankUI[2];
                RankNunber.GetComponent<Text>().color = new Color(0.0f, 150.0f, 250.0f, 255.0f);
                break;
            case 4:
                RankNunber.GetComponent<Text>().text = RankUI[3];
                RankNunber.GetComponent<Text>().color = new Color(50.0f, 255.0f, 0.0f, 255.0f);
                break;
            case 5:
                RankNunber.GetComponent<Text>().text = RankUI[4];
                RankNunber.GetComponent<Text>().color = new Color(255.0f, 0.0f, 255.0f, 255.0f);
                break;
            case 6:
                RankNunber.GetComponent<Text>().text = RankUI[5];
                RankNunber.GetComponent<Text>().color = new Color(50.0f, 50.0f, 50.0f, 255.0f);
                break;
            default:
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
        Item_nunber.SetActive(false);
       
        switch (CarSc.ITEM_NUM)
        //switch (draw_item)
        {
            case ITEM.ERASER_RESIDDUE:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[0];
                Item_nunber.SetActive(true);
                //Debug.Log(draw_item);
                break;
            case ITEM.BIRIBIRI_PEN:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[1];
                Item_nunber.SetActive(true);
                break;
            case ITEM.MECHANICAL_PEN_LEAD:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[2];
                Item_nunber.SetActive(true);
                //Debug.Log(draw_item);
                break;
            case ITEM.STICKY_NOTE:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[3];
                Item_nunber.SetActive(true);
                break;
            case ITEM.TAPE_BALL:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[4];
                Item_nunber.SetActive(true);
                break;
            case ITEM.SCOTCH_TAPE:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[5];
                Item_nunber.SetActive(true);
                break;
            case ITEM.MAGIC_PEN:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[6];
                Item_nunber.SetActive(true);
                break;
            case ITEM.CARDBOARD:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[7];
                Item_nunber.SetActive(true);
                break;
            case ITEM.KESHIKASU_BOM:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[8];
                Item_nunber.SetActive(true);
                break;
            case ITEM.BLACKBOARD_ERASER:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[9];
                Item_nunber.SetActive(true);
                //Debug.Log(draw_item);
                break;
            case ITEM.ORIGAMI_CRANE:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[10];
                Item_nunber.SetActive(true);
                break;
            case ITEM.INDIA_INK:
                Item_nunber.GetComponent<Image>().sprite = ItemUI[11];
                Item_nunber.SetActive(true);
                break;
            case ITEM.CARDBOARD_WALL:
                //Item_nunber13.SetActive(true);
                break;
            default:
                break;
        }
    }
}

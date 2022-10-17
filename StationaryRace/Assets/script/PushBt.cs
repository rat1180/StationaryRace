using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PushBt : MonoBehaviour
{
    public AudioClip Push; // 効果音
    public static int GAMEMODE;
    public int selectButton;
    public int nowButton;
    public int HButton;
    GameObject nowObject;
    public bool PushFlg;
    public static string PASS;
    AudioSource audioSource;
    public GameObject MODEselect;
    public GameObject PASSInput;
    public GameObject Players;
    public GameObject InputSpace;
    public static string PlayerName;
    InputField RoomInputField;
    float YAxis;
    float XAxis;
    bool ButtonFlg;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
        PushFlg = false;
        GAMEMODE = 1;
        selectButton = 0;
        nowButton = 0;
        HButton = 0;
        PASS = "";

        ButtonFlg = true;

        PlayerName = "Player";

	}

    void Update()
    {
        YAxis = Input.GetAxis("ClossKeyYAxis");
        XAxis = Input.GetAxis("ClossKeyXAxis");
        if(XAxis ==0 && YAxis == 0)
        {
            ButtonFlg = true;
        }
        switch (selectButton)
        {
            case 0:
                nowObject = transform.GetChild(0).gameObject;
                selectmode();
                break;
            case 1:
                nowObject = transform.GetChild(1).gameObject;
                RoomInputField = nowObject.transform.GetChild(0).gameObject.GetComponent<InputField>();
                selectMalti();
                break;
        }

        switch (GAMEMODE)
        {
            case 1:
                break;
            case 2:
                Players.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                Players.transform.GetChild(1).GetComponent<Image>().color = Color.white;
                Players.transform.GetChild(2).GetComponent<Image>().color = Color.white;
                break;
            case 3:
                Players.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                Players.transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
                Players.transform.GetChild(2).GetComponent<Image>().color = Color.white;
                break;
            case 4:
                Players.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                Players.transform.GetChild(1).GetComponent<Image>().color = Color.white;
                Players.transform.GetChild(2).GetComponent<Image>().color = Color.yellow;
                break;
            default:
                break;
        }
    }

    void selectmode()
    {
        //二つしかないので同じ
        if (YAxis == 1 && ButtonFlg)
        {
            nowButton = (0 == nowButton) ? 1 : 0;
            ButtonFlg = false;
        }
        if (YAxis == -1 && ButtonFlg)
        {
            nowButton = (0 == nowButton) ? 1 : 0;
            ButtonFlg = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(nowButton == 0)
            {
                ReturnPushBtSolo();
            }
            else
            {
                PushMalti();
            }
        }

        if(nowButton == 0)
        {
            nowObject.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
            nowObject.transform.GetChild(1).GetComponent<Image>().color = Color.white;
        }
        else
        {
            nowObject.transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
            nowObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }

    void selectMalti()
    {
        nowObject.transform.GetChild(0).gameObject.GetComponent<Outline>().enabled = false;
        for(int i=0;i< nowObject.transform.GetChild(3).gameObject.transform.childCount; i++)
        {
            nowObject.transform.GetChild(3).gameObject.transform.GetChild(i).gameObject.GetComponent<Outline>().enabled = false;
        }
        nowObject.transform.GetChild(1).GetComponent<Image>().color = Color.white;
        nowObject.transform.GetChild(2).GetComponent<Image>().color = Color.white;
        if (YAxis == -1 && ButtonFlg)
        {
            nowButton++;
            if (nowButton > 2) nowButton = 0;
            ButtonFlg = false;
        }
        if (YAxis == 1 && ButtonFlg)
        {
            nowButton--;
            if (nowButton < 0) nowButton = 2;
            ButtonFlg = false;
        }

        switch (nowButton)
        {
            case 0:
                for (int i = 0; i < nowObject.transform.GetChild(3).gameObject.transform.childCount; i++)
                {
                    nowObject.transform.GetChild(3).gameObject.transform.GetChild(i).gameObject.GetComponent<Outline>().enabled = true;
                }

                if (XAxis == 1 && ButtonFlg)
                {
                    GAMEMODE++;
                    if (GAMEMODE > 4) GAMEMODE = 0;
                    ButtonFlg = false;
                }
                if (XAxis == -1 && ButtonFlg)
                {
                    GAMEMODE--;
                    if (GAMEMODE < 0) GAMEMODE = 4;
                    ButtonFlg = false;
                }
                break;

            case 1:
                RoomInputField.Select();
                nowObject.transform.GetChild(0).gameObject.GetComponent<Outline>().enabled = true;
                break;

            case 2:
                if (XAxis == 1 && ButtonFlg)
                {
                    HButton++;
                    if (HButton > 2) HButton = 0;
                    ButtonFlg = false;
                }
                if (XAxis == -1 && ButtonFlg)
                {
                    HButton--;
                    if (HButton < 0) HButton = 1;
                    ButtonFlg = false;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (HButton == 0)
                    {
                        PushBack();
                    }
                    else
                    {
                        PushStart();
                    }
                }

                if (HButton == 0)
                {
                    nowObject.transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
                    nowObject.transform.GetChild(2).GetComponent<Image>().color = Color.white;
                }
                else
                {
                    nowObject.transform.GetChild(2).GetComponent<Image>().color = Color.yellow;
                    nowObject.transform.GetChild(1).GetComponent<Image>().color = Color.white;
                }
                break;

        }
    }

    public void ReturnPushBt()
    {
        if (PushFlg == false)
        {
            Invoke("SceneTrip", 1);
            audioSource.PlayOneShot(Push); // 効果音を鳴らす
            PushFlg = true;
        }
    }

    public void ReturnPushBtSolo()
    {
        if (PushFlg == false)
        {
            Invoke("SceneTrip", 1);
            PushFlg = true;
            audioSource.PlayOneShot(Push); // 効果音を鳴らす
            GAMEMODE = 1;
        }
    }

    public void ReturnPushBtDuo()
    {
        if (PushFlg == false)
        {
            audioSource.PlayOneShot(Push); // 効果音を鳴らす
            GAMEMODE = 2;
        }
    }

    public void ReturnPushBtTrio()
    {
        if (PushFlg == false)
        {
            audioSource.PlayOneShot(Push); // 効果音を鳴らす
            GAMEMODE = 3;
        }
    }

    public void ReturnPushBtRace()
    {
        if (PushFlg == false)
        {
            audioSource.PlayOneShot(Push); // 効果音を鳴らす
            GAMEMODE = 4;
        }
    }

    public void PushMalti()
    {
        GAMEMODE = 4;
        MODEselect.SetActive(false);
        PASSInput.SetActive(true);
        audioSource.PlayOneShot(Push); // 効果音を鳴らす
        nowButton = 0;
        selectButton = 1;
    }

    public void PushBack()
    {
        GAMEMODE = 1;
        MODEselect.SetActive(true);
        PASSInput.SetActive(false);
        selectButton = 0;
        nowButton = 0;
        InputSpace.GetComponent<InputField>().text = "";
    }

    public void PushStart()
    {
        if (PushFlg == false)
        {
            PASS = InputSpace.GetComponent<InputField>().text;
            if (PASS != "")
            {
                Invoke("SceneTrip", 1);
                PushFlg = true;
                audioSource.PlayOneShot(Push); // 効果音を鳴らす
            }
        }
    }

    public void SceneTrip()
    {
        //現在のシーンのインデックス番号を取得
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++nowSceneIndexNumber);
    }

    public void NameInput()
    {
        PlayerName = transform.GetChild(0).transform.GetChild(2).GetComponent<InputField>().text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PushBt : MonoBehaviour
{
    public AudioClip Push; // ���ʉ�
    public static int GAMEMODE;
    public bool PushFlg;
    public static string PASS;
    AudioSource audioSource;
    public GameObject MODEselect;
    public GameObject PASSInput;
    public GameObject Players;
    public GameObject InputSpace;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
        PushFlg = false;
        GAMEMODE = 1;
        PASS = "";
	}

    void Update()
    {
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

    public void ReturnPushBt()
    {
        if (PushFlg == false)
        {
            Invoke("SceneTrip", 1);
            audioSource.PlayOneShot(Push); // ���ʉ���炷
            PushFlg = true;
        }
    }

    public void ReturnPushBtSolo()
    {
        if (PushFlg == false)
        {
            Invoke("SceneTrip", 1);
            PushFlg = true;
            audioSource.PlayOneShot(Push); // ���ʉ���炷
            GAMEMODE = 1;
        }
    }

    public void ReturnPushBtDuo()
    {
        if (PushFlg == false)
        {
            audioSource.PlayOneShot(Push); // ���ʉ���炷
            GAMEMODE = 2;
        }
    }

    public void ReturnPushBtTrio()
    {
        if (PushFlg == false)
        {
            audioSource.PlayOneShot(Push); // ���ʉ���炷
            GAMEMODE = 3;
        }
    }

    public void ReturnPushBtRace()
    {
        if (PushFlg == false)
        {
            audioSource.PlayOneShot(Push); // ���ʉ���炷
            GAMEMODE = 4;
        }
    }

    public void PushMalti()
    {
        GAMEMODE = 4;
        MODEselect.SetActive(false);
        PASSInput.SetActive(true);
    }

    public void PushBack()
    {
        GAMEMODE = 1;
        MODEselect.SetActive(true);
        PASSInput.SetActive(false);
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
                audioSource.PlayOneShot(Push); // ���ʉ���炷
            }
        }
    }

    public void SceneTrip()
    {
        //���݂̃V�[���̃C���f�b�N�X�ԍ����擾
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++nowSceneIndexNumber);
    }
}

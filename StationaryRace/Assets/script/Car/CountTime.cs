using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public static CountTime instance;

    //AudioSource audiosource;
    //public AudioClip startsound;

    public float cnttime = 3; 
    public GameObject CountText;   // �e�L�X�g�̕\���p
    public GameObject panel; // �p�l���̕\���ؑ�
    public GameObject counttime;
    public bool cntflg;
    public int gamestart = 0;
    public GameObject GMSytem;

    // Start is called before the first frame update
    void Start()
    {
        //audiosource = GetComponent<AudioSource>();
        //cntflg = true;
        gamestart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetCountTime();

        // Debug.Log("gamestart = " + gamestart);
    }

    /// <summary>
    /// �J�E���g�̕\��
    /// </summary>
    public int GetCountTime()
    {
        if (cntflg == true)
        {
            //AudioSource.PlayClipAtPoint(startsound, transform.position);

            cnttime -= Time.deltaTime; // �J�E���g�_�E��

            if (cnttime >= 0.5f)
            {
                CountText.GetComponent<Text>().text = "" + cnttime.ToString("f0");
            }
            else if (cnttime <= 0.5f)
            {
                CountText.GetComponent<Text>().text = "GO";
                gamestart = 1;
                //Debug.Log("GO");
            }
            if (cnttime <= -1)
            {
                Destroy(panel);
                Destroy(counttime);
                panel.SetActive(false);
                cntflg = false;
                GMSytem.GetComponent<GMSystem>().StartRace();
            }
        }
        return gamestart;
    }

    public int GetGameStart()
    {
        return gamestart;
    }

    public void CountStart()
    {
        cntflg = true;
    }

}

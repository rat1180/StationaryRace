using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public static CountTime instance;

    public float cnttime = 3; 
    public GameObject CountText;   // テキストの表示用
    public GameObject panel; // パネルの表示切替
    public GameObject counttime;
    public bool cntflg;
    public int gamestart = 0;

    // Start is called before the first frame update
    void Start()
    {
        cntflg = true;
        gamestart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetCountTime();

        // Debug.Log("gamestart = " + gamestart);
    }

    /// <summary>
    /// カウントの表示
    /// </summary>
    public int GetCountTime()
    {
        if (cntflg == true)
        {
            cnttime -= Time.deltaTime; // カウントダウン

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
            }
        }
        return gamestart;
    }

    public int GetGameStart()
    {
        return gamestart;
    }

}

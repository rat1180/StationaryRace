using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapPOP : MonoBehaviour
{
    private Text Raptxt;
    public bool txtflg;
    public double Timer;
    public bool Popflg;
    public int RAP;
    public int Timecnt;
    // Start is called before the first frame update
    void Start()
    {
        Raptxt = this.GetComponent<Text>();
        txtflg = false;
        Timer = 0;
        Popflg = false;
        RAP = 0;
        Timecnt = 0;
        Downtext();
    }

    // Update is called once per frame
    void Update()
    {
        if(txtflg == true)
        {
            Timer += Time.deltaTime;
            if(Timer >= 1)
            {
                Popflg = !Popflg;
                Timecnt++;
                Timer = 0;
                if (Popflg)
                {
                    Uptext();
                }
                else
                {
                    Downtext();
                }
                if(Timecnt >= 6)
                {
                    txtflg = false;
                    Timer = 0;
                    Timecnt = 0;
                    Downtext();
                }
            }
        }
    }

    public void GetRap(int rRap)
    {
        RAP = rRap;
        txtflg = true;
    }

    public void Downtext()
    {
        Raptxt.text = "";
    }

    public void Uptext()
    {
        Raptxt.text = "écÇËé¸âÒêî:" + (3 - RAP);
    }
}

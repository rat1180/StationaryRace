using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEBUGLOGS : MonoBehaviour
{
    public GameObject GMSystem;
    GMSystem GMSystemCP;
    public int Nm;
    public int CP;
    public double TIME;
    public int Rap;
    public int Rank;
    GameObject txtNm;
    GameObject txtCP;
    GameObject txtTIME;
    GameObject txtRap;
    GameObject txtRank;
    // Start is called before the first frame update
    void Start()
    {
        GMSystemCP = GMSystem.GetComponent<GMSystem>();
        txtNm = transform.GetChild(0).gameObject;
        txtCP = transform.GetChild(1).gameObject;
        txtTIME = transform.GetChild(2).gameObject;
        txtRap = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Nm = GMSystemCP.User.USERNm;
        CP = GMSystemCP.User.CPcnt;
        TIME = GMSystemCP.User.CPTime;
        Rap = GMSystemCP.User.Rap;
        Rank = GMSystemCP.User.Rank;

        txtNm.GetComponent<Text>().text = "Nm" + Nm;
        txtCP.GetComponent<Text>().text = "CP" + CP;
        txtTIME.GetComponent<Text>().text = "TIME" + TIME;
        txtRap.GetComponent<Text>().text = "Rap" + Rap;

    }
}

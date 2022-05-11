using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_car : MonoBehaviour
{
    public int joutai = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //機体の状態
    public void State()
    {
        switch(joutai){
            case 0:       //スタート前
                break;
            case 1:       //レース中
                break;
            case -1:      //被弾時
                break;
            default:
                break;
        }
    }
}

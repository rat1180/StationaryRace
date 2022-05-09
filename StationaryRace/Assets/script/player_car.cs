using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_car : MonoBehaviour
{
    public float upspeed = 1.0f;   // 前進スピード
    public float backspeed = -5.0f; // 後退スピードorブレーキ
    public float maxspeed = 150;    // 最大加速
    public float accel = 1.010f;    // 加速値
    private float sensitivity = 0.3f;   // 感度
    public bool Accelflg = false;

    public int type = 0;               //テクスチャの選択
    public Material[] _material;       //テクスチャの割り当て

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CarMove();
    }
    /*
    public void kitai()
    {
        //機体のテクスチャ変更
        switch (type)
        {
            case 0:
                this.GetComponent<Renderer>().material = _material[0];
                break;
            case 1:
                this.GetComponent<Renderer>().material = _material[1];
                break;
            case 2:
                this.GetComponent<Renderer>().material = _material[2];
                break;
        }
    }*/

    private void CarMove()
    {

        if (Input.GetKey(KeyCode.W)) // Wキーを押している間
        {

            Accelflg = true;

            if (Accelflg == true)
            {
                transform.position += transform.forward * Time.deltaTime * upspeed;

                if (upspeed < maxspeed) // upspeedがmaxspeedより小さい間
                {
                    upspeed *= accel;   // 徐々に加速する
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -sensitivity, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, sensitivity, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S)) // Sキーを押している間
        {
            Accelflg = false;

            if (Accelflg == false)
            {
                transform.position -= transform.forward * Time.deltaTime * backspeed;

                if (backspeed < maxspeed) // backspeedがmaxspeedより小さい間
                {
                    backspeed *= accel;   // accelの値を掛け続ける
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, sensitivity, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, -sensitivity, 0);
            }
        }
        else
        {
            upspeed = 1;
            backspeed = 1;
        }

    }
}

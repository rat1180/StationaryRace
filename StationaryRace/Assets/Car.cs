using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float upspeed = 10.0f;   // 前進スピード
    public float backspeed = -5.0f; // 後退スピードorブレーキ
    public float maxspeed = 150;    // 最大加速
    public float accel = 1.010f;    // 加速値
    private float sensitivity = 0.3f;   // 感度
    public bool Accelflg = false; 

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
    public struct Moveflg  // フラグ用構造体
    {
        // アクセル用フラグ  true / ON  false / OFF
        public bool Accelflg;

        // バックorブレーキ用フラグ  true / ON  false / OFF
        public bool Backflg;

        // アイテム用フラグ  true / ON  false / OFF
        public bool Itemflg;

        // ハンドル用フラグ  0 : なし  1 : 右  2 : 左
        public bool Handleflg;
    } 
    */

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
        else if(Input.GetKey(KeyCode.S)) // Sキーを押している間
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

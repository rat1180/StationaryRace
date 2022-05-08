using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float upspeed;       // 前進スピード
    public float backspeed;     // 後退スピードorブレーキ
    private float maxspeed;     // 最大加速
    public float accel;         // 加速値
    public float handle;        // 旋回力
    private bool Accelflg;      // 機体が動いているか

    // Start is called before the first frame update
    void Start()
    {
        //upspeed = 20.0f;
        //backspeed = 20.0f;
        maxspeed = 120.0f;
        accel = 1.001f;
        handle = 0.1f;
        Accelflg = true;
    }

    // Update is called once per frame
    void Update()
    {
        CarMoveAccel();
        CarMoveHandle();
        CarMoveDrift();
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

    //機体の前進後退
    private void CarMoveAccel()
    {

        if (Input.GetKey(KeyCode.W)) // Wキーを押している間
        {
            Accelflg = true;

            // Time.deltaTimeを掛ける事でfpsの違いによって速度が変わらなくなる
            GetComponent<Rigidbody>().velocity += transform.forward * Time.deltaTime * upspeed;

            if (upspeed < maxspeed) // upspeedがmaxspeedより小さい間
            {
                upspeed *= accel;   // 徐々に加速する
            }
        }
        else if (Input.GetKey(KeyCode.S)) // Sキーを押している間
        {
            Accelflg = false;

            // Time.deltaTimeを掛ける事でfpsの違いによって速度が変わらなくなる
            GetComponent<Rigidbody>().velocity -= transform.forward * Time.deltaTime * backspeed;

            if (backspeed < maxspeed * 0.3) // backspeedがmaxspeedより小さい間
            {
                backspeed *= accel;   // accelの値を掛け続ける
            }
        }
        else  // 何の操作もしていない状態
        {
            upspeed = 20.0f;
            backspeed = 19.0f;
        }

    }

    // ハンドル操作
    private void CarMoveHandle()
    {
        if (Accelflg == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -handle, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, handle, 0);
            }

        }
        else if(Accelflg == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, handle, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, -handle, 0);

            }
        }
    }

    // ドリフト操作
    private void CarMoveDrift()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            handle = 0.5f;
        }
        else
        {
            handle = 0.1f;
        }
    }
}


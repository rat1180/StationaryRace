using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float upspeed = 10.0f;   // 前進スピード
    public float backspeed = -5.0f; // 後退スピードorブレーキ
    public float maxspeed = 150;    // 最大加速
    public float accel = 1.005f;    // 加速値
    public float decel = 0.995f;    // 減速値

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

        float x = Input.GetAxisRaw("Horizontal"); // 左 / 右
        float z = Input.GetAxisRaw("Vertical");   // 上 / 下

        Vector3 direction = new Vector3(0, 0, z).normalized;

        if (Input.GetKey(KeyCode.W)){    // 上矢印キーを押している間

            Accelflg = true;

            if (Accelflg == true)
            {
                GetComponent<Rigidbody>().velocity = direction * upspeed;   // 前進のスピード

                if (upspeed < maxspeed) // upspeedがmaxspeedより小さい間
                {
                    upspeed *= accel;   // 徐々に加速する
                }
            }
            else
            {
                upspeed *= decel;
            }
        }
        else if (Input.GetKey(KeyCode.S)) // 下矢印キーを押している間
        {
            Accelflg = false;

            if (Accelflg == false)
            {

                GetComponent<Rigidbody>().velocity = direction * backspeed; // 後退スピード

                if (backspeed < maxspeed) // backspeedがmaxspeedより小さい間
                {
                    backspeed *= accel;   // accelの値を掛け続ける
                }
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    public float upspeed;       // 前進スピード
    public float backspeed;     // 後退スピードorブレーキ
    private float maxspeed;     // 最大加速
    private float accel;        // 加速値
    public float handle;        // 旋回力
    private bool Accelflg;      // 機体が動いているか
    public float time;          // 時間
    public GameObject cp;       // チェックポイント

    // Start is called before the first frame update
    void Start()
    {
        upspeed = 20.0f;
        backspeed = 19.0f;
        maxspeed = 100.0f;
        accel = 1.001f;
        handle = 0.2f;
        Accelflg = true;
        cp = GameObject.Find("CP");
    }

    // Update is called once per frame
    void Update()
    {
        CarMoveAccel();
        CarMoveHandle();
        //CarMoveDrift();
    }

    private void OnTriggerEnter(Collider collision)
    {

        ItemSpeedUp();
        ItemHit();
        WallHit(collision);

        if (collision.gameObject.tag == "CP") //CPタグの付いたオブジェクトと当たった時に関数を呼ぶ
        {
            CPHit();
        }
        
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

            if (backspeed < maxspeed * 0.2) // backspeedがmaxspeedより小さい間
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
        if (upspeed > backspeed)
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
        else if(backspeed > upspeed)
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

    /*
    // ドリフト操作
    private void CarMoveDrift()
    {
        if (Input.GetKey(KeyCode.Space)) // スペースキーを押している間
        {
            handle = 0.3f;
        }
        else
        {
            handle = 0.1f;
        }
    }
    */
    
    // スピードアップ用関数
    public void ItemSpeedUp()
    {
        
        if (gameObject.name == "STICKY_NOTE") // 付箋
        {
            upspeed = maxspeed;
            maxspeed = 150;
            upspeed += 20;
        }
        Debug.Log("SpeedUp");

    }

    // アイテムが当たった時の処理
    public void ItemHit()
    {
        if (gameObject.name == "ENPITU")
        {
            Debug.Log("ENPITU");
        }
        else if (gameObject.name == "ERASER_RESIDDUE")
        {
            Debug.Log("ERASER_RESIDDUE");
        }
        else if (gameObject.name == "BLACKBOARD_ERASER")
        {
            Debug.Log("BLACKBOARD_ERASER");
        }
        else if (gameObject.name == "MECHANICAL_PEN_LEAD")
        {
            Debug.Log("MECHANICAL_PEN_LEAD");
        } 
        else if (gameObject.name == "TAPE_BALL")
        {
            Debug.Log("TAPE_BALL");
        }
        else if (gameObject.name == "SCOTCH_TAPE")
        {
            Debug.Log("SCOTCH_TAPE");
        }
        else if (gameObject.name == "MAGIC_PEN")
        {
            Debug.Log("MAGIC_PEN");
        }
        else if (gameObject.name == "ORIGAMI_CRANE")
        {
            Debug.Log("ORIGAMI_CRANE");
        }
        else if (gameObject.name == "BIRIBIRI_PEN")
        {
            Debug.Log("BIRIBIRI_PEN");
        }
        else if (gameObject.name == "INDIA_INK")
        {
            Debug.Log("INDIA_INK");
        }

    }
    public void CountTime()
    {
        time -= Time.deltaTime;
    }

    public void CPHit()  // チェックポイントと当たった時に呼び出す関数
    {
       // cp.GetComponent<CheckP>(); // CheckPointスクリプトの関数呼び出し
    }

    public void WallHit(Collider collision)  // 壁と当たった時
    {
        if (collision.gameObject.tag == "Wall")
        {
            
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Car : MonoBehaviour
{
    #region 変数
    Rigidbody rb;

    public float upspeed;       // 前進スピード
    public float backspeed;     // 後退スピードorブレーキ
    private float maxspeed;     // 最大加速
    private float accel;        // 加速値
    public float handle;        // 旋回力
    public float time;          // 時間
    private float colorR;       // 赤色の値
    private float colorG;       // 緑色の値
    private float colorB;       // 青色の値
    private float clear;        // 色の透明度

    private bool Accelflg;      // 機体が動いているか

    public GameObject cp;       // チェックポイント
    public GameObject hitbox;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region 初期化処理
        rb = this.GetComponent<Rigidbody>();

        upspeed = 20.0f;
        backspeed = 19.0f;
        maxspeed = 100.0f;
        accel = 1.001f;
        handle = 0.2f;
        clear = 0.001f;

        Accelflg = true;

        cp = GameObject.Find("CP");
        hitbox = GameObject.Find("HitBox");

        colorR = 0;
        colorG = 255;
        colorB = 0;

        // 初期は緑色
        hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        CarMoveAccel();
        CarMoveHandle();
        CarMoveDrift();
        CarColor();
    }

    private void OnTriggerEnter(Collider collision)
    {

        ItemSpeedUp();
        ItemHit();
        WallHit(collision);
        CPHit(collision);

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

    /// <summary>
    /// 機体の前進後退
    /// </summary>
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

        }
        else  // 何の操作もしていない状態
        {
            upspeed = rb.velocity.magnitude + 20;    // 現在のスピードを取得 + 20することで速さが20より下がらなくする
        }
        Debug.Log("現在の速度" + rb.velocity.magnitude);  // ゲームオブジェクトの速さ表示 velocityは速度ベクトル magnitudeはベクトルの長さの取得

    }

    /// <summary>
    /// ハンドル操作
    /// </summary>
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
        else if (Accelflg == false)
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

    /// <summary>
    /// ドリフト操作
    /// </summary>
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

    /// <summary>
    /// スピードアップ用関数
    /// </summary>
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

    /// <summary>
    /// アイテムが当たった時の処理
    /// </summary>
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

    /// <summary>
    /// 時間カウント用（予定）
    /// </summary>
    public void CountTime()
    {
        time -= Time.deltaTime;
    }

    /// <summary>
    /// チェックポイントと当たった時に呼び出す関数
    /// </summary>
    public void CPHit(Collider collision)
    {
        if (collision.gameObject.tag == "CP") //CPタグの付いたオブジェクトと当たった時に関数を呼ぶ
        {

        }
        // cp.GetComponent<CheckP>(); // CheckPointスクリプトの関数呼び出し
    }

    /// <summary>
    /// 壁と当たった時
    /// </summary>
    /// <param name="collision"></param>
    public void WallHit(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")  // Wallタグが付いたオブジェクトと当たった時
        {
            
            SceneManager.LoadScene("GOAL");  // 後で消す
        }

    }

    public void CarColor()
    {
        if(rb.velocity.magnitude >= 70)
        {
            colorR = 255;
            colorG = 0;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // 赤色
        }
        else if(rb.velocity.magnitude >= 30 && rb.velocity.magnitude < 70)
        {
            colorR = 255;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // 黄色
        }
        else
        {
            colorR = 0;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // 緑色
        }


    }
}

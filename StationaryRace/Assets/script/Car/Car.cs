using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SoftGear.Strix.Unity.Runtime;

public class Car : StrixBehaviour
{
    #region 変数
    Rigidbody rb;

    public GameObject camera01; // 正面カメラ
    public GameObject camera02; // 後ろ向きカメラ

    public int carnum;          // 機体番号
    public float upspeed;       // 前進スピード
    public float backspeed;     // 後退スピードorブレーキ
    private float maxspeed;     // 最大加速
    private float maxspeed_state;//最大加速の元の値
    private float accel;        // 加速値
    public float handle;        // 旋回力
    private float handle_state; // 旋回力の元の値
    public float time;          // 時間
    private float colorR;       // 赤色の値
    private float colorG;       // 緑色の値
    private float colorB;       // 青色の値
    private float clear;        // 色の透明度
    private float goaltime;     // ゴールしたときのタイム

    private bool Accelflg;      // 機体が動いているか
    private bool goalflg;        // ゴールしたかどうか

    public GameObject cp;       // チェックポイント
    public GameObject hitbox;
    public GameObject particlespeed01; // 機体のスピードが早いときに呼び出すパーティクル
    public GameObject particlespeed02; // 機体のスピードが早いときに呼び出すパーティクル

    public CountTime counttime;

    int gamestart;

    public GameObject User;

    #region 追加項目
    private int USER_Num = 0;//ユーザ番号
    public bool itemhave = false;
    public int ITEM_NUM = -1;
    ItemManager IManager;//アイテムマネージャー参照準備
    GameObject ItemMana;       //アイテムマネージャーのゲームオブジェクトを取得する準備.
    //private int ItemFront = 1;//アイテムの向き
    //private const int Before = 1;
    //private const int After = 2;

    public GameObject ORIGAMI_CRANE;
    private float speednow;

    public Vector3 Pos;
    #endregion

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal)
        {
            transform.Find("Main Camera1").gameObject.SetActive(false);
            return;
        }
        #region 初期化処理
        rb = this.GetComponent<Rigidbody>();

        Performance();

        Accelflg = true;
        ItemMana = GameObject.Find("ITEMManager");
        IManager = ItemMana.GetComponent<ItemManager>();
        cp = GameObject.Find("CP");
        hitbox = transform.Find("HitBox").gameObject;
        User = this.transform.parent.gameObject;
        //counttime = GameObject.Find("Counttime").GetComponent<CountTime>();

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
        if (!isLocal) return;
        gamestart = counttime.GetGameStart();
        //gamestart = 1;
        //Debug.Log(gamestart);
        if (gamestart == 1)
        {
            //Debug.Log("Start");
            CarMoveAccel();
            CarMoveHandle();
            CarMoveDrift();
            CarColor();
            Cameraswitc();
        }

        //追加
        //スペースキーでアイテムの使用（テスト）
        if (Input.GetKey(KeyCode.P) && itemhave == true)
        {
            IManager.Item_Use(ITEM_NUM);//アイテム使用

            itemhave = false;
            //ORIGAMI_CHANGE();
        }
        Pos = this.transform.position;
    }

    private void Cameraswitc()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camera01.SetActive(false);
            camera02.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            camera01.SetActive(true);
            camera02.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!isLocal) return;
        ItemHit();
        GOALHit(collision);
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
    /// 機体の性能
    /// 1.鉛筆：標準　2.消しゴム：曲がりやすい　3.定規：加速しやすい
    /// </summary>
    public void Performance()
    {
        carnum = 1;
        switch (carnum)
        {
            case 1:  // 鉛筆
                upspeed = 30.0f;
                backspeed = 19.0f;
                maxspeed_state = 90.0f;
                accel = 1.0011f;
                handle_state = 0.15f;
                clear = 0.001f;
                break;
            case 2:  // 消しゴム
                upspeed = 40.0f;
                backspeed = 20.0f;
                maxspeed_state = 70.0f;
                accel = 1.0007f;
                handle_state = 0.25f;
                clear = 0.001f;
                break;
            case 3:  // 定規
                upspeed = 25.0f;
                backspeed = 21.0f;
                maxspeed_state = 80.0f;
                accel = 1.0015f;
                handle_state = 0.07f;
                clear = 0.001f;
                break;
            default:
                Debug.Log("1～3の番号以外使えません");
                break;
        }
        handle = handle_state;
        maxspeed = maxspeed_state;
    }

    /// <summary>
    /// 機体の前進後退
    /// </summary>
    private void CarMoveAccel()
    {
        if (!isLocal) return;
        if (Input.GetKey(KeyCode.W)) // Wキーを押している間
        {
            Accelflg = true;

            // Time.deltaTimeを掛ける事でfpsの違いによって速度が変わらなくなる
            rb.velocity += transform.forward * Time.deltaTime * upspeed;

            if (upspeed < maxspeed) // upspeedがmaxspeedより小さい間
            {
                upspeed *= accel;   // 徐々に加速する
            }
        }
        else if (Input.GetKey(KeyCode.S)) // Sキーを押している間
        {
            Accelflg = false;

            // Time.deltaTimeを掛ける事でfpsの違いによって速度が変わらなくなる
            rb.velocity -= transform.forward * Time.deltaTime * backspeed;

        }
        else  // 何の操作もしていない状態
        {
            Accelflg = true;
            if (carnum == 1)
            {
                upspeed = rb.velocity.magnitude + 20;    // 現在のスピードを取得 + 20することで速さが20より下がらなくする
            }
            if (carnum == 2)
            {
                upspeed = rb.velocity.magnitude + 100;    // 現在のスピードを取得 + 20することで速さが20より下がらなくする
            }
            if(carnum == 3)
            {
                upspeed = rb.velocity.magnitude + 200;    // 現在のスピードを取得 + 20することで速さが20より下がらなくする
            }
        }
       // Debug.Log("現在の速度" + rb.velocity.magnitude);  // ゲームオブジェクトの速さ表示 velocityは速度ベクトル magnitudeはベクトルの長さの取得

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
            if (handle < handle_state * 1.5)
            {
                handle = handle * 1.003f;
            }
            maxspeed = maxspeed_state * 0.8f;
        }
        else
        {
            handle = handle_state;
            maxspeed = maxspeed_state;
        }
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
    /// チェックポイントと当たった時に呼び出す関数
    /// </summary>
    public void CPHit(Collider collision)
    {
        if (!isLocal) return;
        // CPが含まれていればOK
        if (collision.name.Contains("CP"))
        {
            int CPNm = collision.GetComponent<CheckPoint>().CheckP();
            User.GetComponent<UserOperation>().CP(CPNm);
        }
        // cp.GetComponent<CheckP>(); // CheckPointスクリプトの関数呼び出し
    }

    /// <summary>
    /// 壁と当たった時
    /// </summary>
    /// <param name="collision"></param>
    public void GOALHit(Collider collision)
    {
        if (collision.gameObject.tag == "GOAL")  // 指定したタグが付いたオブジェクトと当たった時
        {
            Debug.Log(goaltime);
            goalflg = false;
        }
        if (goalflg == true && gamestart == 1)
        {
            goaltime++;
        }
    }

    /// <summary>
    /// スピードによってHitBoxの色を変化させる
    /// </summary>
    public void CarColor()
    {
        if (!isLocal) return;
        if (rb.velocity.magnitude >= 70)
        {

            colorR = 255;
            colorG = 0;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // 赤色
            particlespeed01.SetActive(true);
            particlespeed02.SetActive(false);
        }
        else if (rb.velocity.magnitude >= 30 && rb.velocity.magnitude < 70)
        {
            colorR = 255;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // 黄色
            particlespeed01.SetActive(false);
            particlespeed02.SetActive(true);
        }
        else
        {
            colorR = 0;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // 緑色
            particlespeed01.SetActive(false);
            particlespeed02.SetActive(false);
        }
    }

    //追加
    public void ItemHave()
    {
        itemhave = true;
    }
    public void ORIGAMI_CHANGE()
    {
        ORIGAMI_CRANE.SetActive(true);
        this.transform.Find("Skin").gameObject.SetActive(false);
        speednow = upspeed;
        StartCoroutine("ORIGAMI_SpeedUp");
    }

    IEnumerator ORIGAMI_SpeedUp()
    {
        upspeed = 180.0f;
        yield return new WaitForSeconds(3.0f);
        upspeed = speednow;
        ORIGAMI_CRANE.SetActive(false);
        this.transform.Find("Skin").gameObject.SetActive(true);
    }

    public void BIRIBIRI_PEN()
    {
        Pos.y += 1f;
        this.transform.position = Pos;
    }

    //スピードダウン
    public void SpeedDown()
    {
        StartCoroutine("SpeedDownA");
    }
    public IEnumerator SpeedDownA()
    {
        rb.isKinematic = true;
        yield return new WaitForSeconds(1.0f);

        rb.isKinematic = false;
        upspeed = 10f;
    }
}

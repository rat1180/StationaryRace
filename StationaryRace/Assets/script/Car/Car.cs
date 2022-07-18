using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SoftGear.Strix.Unity.Runtime;

public class Car : StrixBehaviour
{
    #region �ϐ�
    Rigidbody rb;

    public GameObject camera01; // ���ʃJ����
    public GameObject camera02; // �������J����

    public int carnum;          // �@�̔ԍ�
    public float upspeed;       // �O�i�X�s�[�h
    public float backspeed;     // ��ރX�s�[�hor�u���[�L
    private float maxspeed;     // �ő����
    private float maxspeed_state;//�ő�����̌��̒l
    private float accel;        // �����l
    public float handle;        // �����
    private float handle_state; // ����͂̌��̒l
    public float time;          // ����
    private float colorR;       // �ԐF�̒l
    private float colorG;       // �ΐF�̒l
    private float colorB;       // �F�̒l
    private float clear;        // �F�̓����x
    private float goaltime;     // �S�[�������Ƃ��̃^�C��

    private bool Accelflg;      // �@�̂������Ă��邩
    private bool goalflg;        // �S�[���������ǂ���

    public GameObject cp;       // �`�F�b�N�|�C���g
    public GameObject hitbox;
    public GameObject particlespeed01; // �@�̂̃X�s�[�h�������Ƃ��ɌĂяo���p�[�e�B�N��
    public GameObject particlespeed02; // �@�̂̃X�s�[�h�������Ƃ��ɌĂяo���p�[�e�B�N��

    public CountTime counttime;

    int gamestart;

    public GameObject User;

    #region �ǉ�����
    private int USER_Num = 0;//���[�U�ԍ�
    public bool itemhave = false;
    public int ITEM_NUM = -1;
    ItemManager IManager;//�A�C�e���}�l�[�W���[�Q�Ə���
    GameObject ItemMana;       //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    //private int ItemFront = 1;//�A�C�e���̌���
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
        #region ����������
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

        // �����͗ΐF
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

        //�ǉ�
        //�X�y�[�X�L�[�ŃA�C�e���̎g�p�i�e�X�g�j
        if (Input.GetKey(KeyCode.P) && itemhave == true)
        {
            IManager.Item_Use(ITEM_NUM);//�A�C�e���g�p

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
    public struct Moveflg  // �t���O�p�\����
    {
        // �A�N�Z���p�t���O  true / ON  false / OFF
        public bool Accelflg;

        // �o�b�Nor�u���[�L�p�t���O  true / ON  false / OFF
        public bool Backflg;

        // �A�C�e���p�t���O  true / ON  false / OFF
        public bool Itemflg;

        // �n���h���p�t���O  0 : �Ȃ�  1 : �E  2 : ��
        public bool Handleflg;
    } 
    */

    /// <summary>
    /// �@�̂̐��\
    /// 1.���M�F�W���@2.�����S���F�Ȃ���₷���@3.��K�F�������₷��
    /// </summary>
    public void Performance()
    {
        carnum = 1;
        switch (carnum)
        {
            case 1:  // ���M
                upspeed = 30.0f;
                backspeed = 19.0f;
                maxspeed_state = 90.0f;
                accel = 1.0011f;
                handle_state = 0.15f;
                clear = 0.001f;
                break;
            case 2:  // �����S��
                upspeed = 40.0f;
                backspeed = 20.0f;
                maxspeed_state = 70.0f;
                accel = 1.0007f;
                handle_state = 0.25f;
                clear = 0.001f;
                break;
            case 3:  // ��K
                upspeed = 25.0f;
                backspeed = 21.0f;
                maxspeed_state = 80.0f;
                accel = 1.0015f;
                handle_state = 0.07f;
                clear = 0.001f;
                break;
            default:
                Debug.Log("1�`3�̔ԍ��ȊO�g���܂���");
                break;
        }
        handle = handle_state;
        maxspeed = maxspeed_state;
    }

    /// <summary>
    /// �@�̂̑O�i���
    /// </summary>
    private void CarMoveAccel()
    {
        if (!isLocal) return;
        if (Input.GetKey(KeyCode.W)) // W�L�[�������Ă����
        {
            Accelflg = true;

            // Time.deltaTime���|���鎖��fps�̈Ⴂ�ɂ���đ��x���ς��Ȃ��Ȃ�
            rb.velocity += transform.forward * Time.deltaTime * upspeed;

            if (upspeed < maxspeed) // upspeed��maxspeed��菬������
            {
                upspeed *= accel;   // ���X�ɉ�������
            }
        }
        else if (Input.GetKey(KeyCode.S)) // S�L�[�������Ă����
        {
            Accelflg = false;

            // Time.deltaTime���|���鎖��fps�̈Ⴂ�ɂ���đ��x���ς��Ȃ��Ȃ�
            rb.velocity -= transform.forward * Time.deltaTime * backspeed;

        }
        else  // ���̑�������Ă��Ȃ����
        {
            Accelflg = true;
            if (carnum == 1)
            {
                upspeed = rb.velocity.magnitude + 20;    // ���݂̃X�s�[�h���擾 + 20���邱�Ƃő�����20��艺����Ȃ�����
            }
            if (carnum == 2)
            {
                upspeed = rb.velocity.magnitude + 100;    // ���݂̃X�s�[�h���擾 + 20���邱�Ƃő�����20��艺����Ȃ�����
            }
            if(carnum == 3)
            {
                upspeed = rb.velocity.magnitude + 200;    // ���݂̃X�s�[�h���擾 + 20���邱�Ƃő�����20��艺����Ȃ�����
            }
        }
       // Debug.Log("���݂̑��x" + rb.velocity.magnitude);  // �Q�[���I�u�W�F�N�g�̑����\�� velocity�͑��x�x�N�g�� magnitude�̓x�N�g���̒����̎擾

    }

    /// <summary>
    /// �n���h������
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
    /// �h���t�g����
    /// </summary>
    private void CarMoveDrift()
    {
        if (Input.GetKey(KeyCode.Space)) // �X�y�[�X�L�[�������Ă����
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
    /// �A�C�e���������������̏���
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
    /// �`�F�b�N�|�C���g�Ɠ����������ɌĂяo���֐�
    /// </summary>
    public void CPHit(Collider collision)
    {
        if (!isLocal) return;
        // CP���܂܂�Ă����OK
        if (collision.name.Contains("CP"))
        {
            int CPNm = collision.GetComponent<CheckPoint>().CheckP();
            User.GetComponent<UserOperation>().CP(CPNm);
        }
        // cp.GetComponent<CheckP>(); // CheckPoint�X�N���v�g�̊֐��Ăяo��
    }

    /// <summary>
    /// �ǂƓ���������
    /// </summary>
    /// <param name="collision"></param>
    public void GOALHit(Collider collision)
    {
        if (collision.gameObject.tag == "GOAL")  // �w�肵���^�O���t�����I�u�W�F�N�g�Ɠ���������
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
    /// �X�s�[�h�ɂ����HitBox�̐F��ω�������
    /// </summary>
    public void CarColor()
    {
        if (!isLocal) return;
        if (rb.velocity.magnitude >= 70)
        {

            colorR = 255;
            colorG = 0;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // �ԐF
            particlespeed01.SetActive(true);
            particlespeed02.SetActive(false);
        }
        else if (rb.velocity.magnitude >= 30 && rb.velocity.magnitude < 70)
        {
            colorR = 255;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // ���F
            particlespeed01.SetActive(false);
            particlespeed02.SetActive(true);
        }
        else
        {
            colorR = 0;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // �ΐF
            particlespeed01.SetActive(false);
            particlespeed02.SetActive(false);
        }
    }

    //�ǉ�
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

    //�X�s�[�h�_�E��
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

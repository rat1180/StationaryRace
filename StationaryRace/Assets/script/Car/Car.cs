using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Car : MonoBehaviour
{
    #region �ϐ�
    Rigidbody rb;

    public float upspeed;       // �O�i�X�s�[�h
    public float backspeed;     // ��ރX�s�[�hor�u���[�L
    private float maxspeed;     // �ő����
    private float accel;        // �����l
    public float handle;        // �����
    public float time;          // ����
    private float colorR;       // �ԐF�̒l
    private float colorG;       // �ΐF�̒l
    private float colorB;       // �F�̒l
    private float clear;        // �F�̓����x

    private bool Accelflg;      // �@�̂������Ă��邩

    public GameObject cp;       // �`�F�b�N�|�C���g
    public GameObject hitbox;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region ����������
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

        // �����͗ΐF
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
    /// �@�̂̑O�i���
    /// </summary>
    private void CarMoveAccel()
    {

        if (Input.GetKey(KeyCode.W)) // W�L�[�������Ă����
        {
            Accelflg = true;

            // Time.deltaTime���|���鎖��fps�̈Ⴂ�ɂ���đ��x���ς��Ȃ��Ȃ�
            GetComponent<Rigidbody>().velocity += transform.forward * Time.deltaTime * upspeed;

            if (upspeed < maxspeed) // upspeed��maxspeed��菬������
            {
                upspeed *= accel;   // ���X�ɉ�������
            }
        }
        else if (Input.GetKey(KeyCode.S)) // S�L�[�������Ă����
        {
            Accelflg = false;

            // Time.deltaTime���|���鎖��fps�̈Ⴂ�ɂ���đ��x���ς��Ȃ��Ȃ�
            GetComponent<Rigidbody>().velocity -= transform.forward * Time.deltaTime * backspeed;

        }
        else  // ���̑�������Ă��Ȃ����
        {
            upspeed = rb.velocity.magnitude + 20;    // ���݂̃X�s�[�h���擾 + 20���邱�Ƃő�����20��艺����Ȃ�����
        }
        Debug.Log("���݂̑��x" + rb.velocity.magnitude);  // �Q�[���I�u�W�F�N�g�̑����\�� velocity�͑��x�x�N�g�� magnitude�̓x�N�g���̒����̎擾

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
            handle = 0.3f;
        }
        else
        {
            handle = 0.1f;
        }
    }

    /// <summary>
    /// �X�s�[�h�A�b�v�p�֐�
    /// </summary>
    public void ItemSpeedUp()
    {

        if (gameObject.name == "STICKY_NOTE") // �t�
        {
            upspeed = maxspeed;
            maxspeed = 150;
            upspeed += 20;
        }
        Debug.Log("SpeedUp");

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
    /// ���ԃJ�E���g�p�i�\��j
    /// </summary>
    public void CountTime()
    {
        time -= Time.deltaTime;
    }

    /// <summary>
    /// �`�F�b�N�|�C���g�Ɠ����������ɌĂяo���֐�
    /// </summary>
    public void CPHit(Collider collision)
    {
        if (collision.gameObject.tag == "CP") //CP�^�O�̕t�����I�u�W�F�N�g�Ɠ����������Ɋ֐����Ă�
        {

        }
        // cp.GetComponent<CheckP>(); // CheckPoint�X�N���v�g�̊֐��Ăяo��
    }

    /// <summary>
    /// �ǂƓ���������
    /// </summary>
    /// <param name="collision"></param>
    public void WallHit(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")  // Wall�^�O���t�����I�u�W�F�N�g�Ɠ���������
        {
            
            SceneManager.LoadScene("GOAL");  // ��ŏ���
        }

    }

    public void CarColor()
    {
        if(rb.velocity.magnitude >= 70)
        {
            colorR = 255;
            colorG = 0;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // �ԐF
        }
        else if(rb.velocity.magnitude >= 30 && rb.velocity.magnitude < 70)
        {
            colorR = 255;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // ���F
        }
        else
        {
            colorR = 0;
            colorG = 255;
            colorB = 0;
            hitbox.GetComponent<Renderer>().material.color = new Color(colorR, colorG, colorB, clear);   // �ΐF
        }


    }
}

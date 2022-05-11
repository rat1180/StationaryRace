using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float upspeed;       // �O�i�X�s�[�h
    public float backspeed;     // ��ރX�s�[�hor�u���[�L
    private float maxspeed;     // �ő����
    private float accel;        // �����l
    public float handle;        // �����
    private bool Accelflg;      // �@�̂������Ă��邩
    public float time;          // ����
    public float maxtime;

    // Start is called before the first frame update
    void Start()
    {
        upspeed = 20.0f;
        backspeed = 19.0f;
        maxspeed = 100.0f;
        accel = 1.001f;
        handle = 0.1f;
        Accelflg = true;
    }

    // Update is called once per frame
    void Update()
    {
        CarMoveAccel();
        CarMoveHandle();
        //CarMoveDrift();
        ItemSpeedUp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ItemSpeedUp();
        ItemHit();
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

    //�@�̂̑O�i���
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

            if (backspeed < maxspeed * 0.2) // backspeed��maxspeed��菬������
            {
                backspeed *= accel;   // accel�̒l���|��������
            }
        }
        else  // ���̑�������Ă��Ȃ����
        {
            upspeed = 20.0f;
            backspeed = 19.0f;
        }

    }

    // �n���h������
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
    // �h���t�g����
    private void CarMoveDrift()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            handle = 0.3f;
        }
        else
        {
            handle = 0.1f;
        }
    }
    */

    public void ItemSpeedUp()
    {
        if (gameObject.name == "STICKY_NOTE") // �t�
        {
            upspeed = maxspeed;
            maxspeed = 150;
            upspeed += 20;
        }
    }

    // �A�C�e���������������̏���
    public void ItemHit()
    {
        if (gameObject.name == "ENPITU")
        {

        }
        else if (gameObject.name == "ERASER_RESIDDUE")
        {

        }
        else if (gameObject.name == "BLACKBOARD_ERASER")
        {

        }
        else if (gameObject.name == "MECHANICAL_PEN_LEAD")
        {

        } 
        else if (gameObject.name == "TAPE_BALL")
        {

        }
        else if (gameObject.name == "SCOTCH_TAPE")
        {

        }
        else if (gameObject.name == "MAGIC_PEN")
        {

        }
        else if (gameObject.name == "ORIGAMI_CRANE")
        {

        }
        else if (gameObject.name == "BIRIBIRI_PEN")
        {

        }
        else if (gameObject.name == "INDIA_INK")
        {

        }
    }

}


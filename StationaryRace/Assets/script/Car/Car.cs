using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float upspeed;       // �O�i�X�s�[�h
    public float backspeed;     // ��ރX�s�[�hor�u���[�L
    private float maxspeed;     // �ő����
    public float accel;         // �����l
    public float handle;        // �����
    private bool Accelflg;      // �@�̂������Ă��邩

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

            if (backspeed < maxspeed * 0.3) // backspeed��maxspeed��菬������
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

    // �h���t�g����
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


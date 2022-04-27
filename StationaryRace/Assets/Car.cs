using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float upspeed = 10.0f;   // �O�i�X�s�[�h
    public float backspeed = -5.0f; // ��ރX�s�[�hor�u���[�L
    public float maxspeed = 150;    // �ő����
    public float accel = 1.005f;    // �����l
    public float decel = 0.995f;    // �����l

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

    private void CarMove()
    {

        float x = Input.GetAxisRaw("Horizontal"); // �� / �E
        float z = Input.GetAxisRaw("Vertical");   // �� / ��

        Vector3 direction = new Vector3(0, 0, z).normalized;

        if (Input.GetKey(KeyCode.W)){    // ����L�[�������Ă����

            Accelflg = true;

            if (Accelflg == true)
            {
                GetComponent<Rigidbody>().velocity = direction * upspeed;   // �O�i�̃X�s�[�h

                if (upspeed < maxspeed) // upspeed��maxspeed��菬������
                {
                    upspeed *= accel;   // ���X�ɉ�������
                }
            }
            else
            {
                upspeed *= decel;
            }
        }
        else if (Input.GetKey(KeyCode.S)) // �����L�[�������Ă����
        {
            Accelflg = false;

            if (Accelflg == false)
            {

                GetComponent<Rigidbody>().velocity = direction * backspeed; // ��ރX�s�[�h

                if (backspeed < maxspeed) // backspeed��maxspeed��菬������
                {
                    backspeed *= accel;   // accel�̒l���|��������
                }
            }

        }
    }
}

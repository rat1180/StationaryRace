using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_car : MonoBehaviour
{
    public float upspeed = 10.0f;   // �O�i�X�s�[�h
    public float backspeed = -5.0f; // ��ރX�s�[�hor�u���[�L
    public float maxspeed = 150;    // �ő����
    public float accel = 1.010f;    // �����l
    private float sensitivity = 0.3f;   // ���x
    public bool Accelflg = false;

    public int type = 0;               //�e�N�X�`���̑I��
    public Material[] _material;       //�e�N�X�`���̊��蓖��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CarMove();

        //�@�̂̃e�N�X�`���ύX
        switch (type)
        {
            case 0:
                this.GetComponent<Renderer>().material = _material[0];
                break;
            case 1:
                this.GetComponent<Renderer>().material = _material[1];
                break;
            case 2:
                this.GetComponent<Renderer>().material = _material[2];
                break;
        }
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

        if (Input.GetKey(KeyCode.W)) // W�L�[�������Ă����
        {

            Accelflg = true;

            if (Accelflg == true)
            {
                transform.position += transform.forward * Time.deltaTime * upspeed;

                if (upspeed < maxspeed) // upspeed��maxspeed��菬������
                {
                    upspeed *= accel;   // ���X�ɉ�������
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -sensitivity, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, sensitivity, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S)) // S�L�[�������Ă����
        {
            Accelflg = false;

            if (Accelflg == false)
            {
                transform.position -= transform.forward * Time.deltaTime * backspeed;

                if (backspeed < maxspeed) // backspeed��maxspeed��菬������
                {
                    backspeed *= accel;   // accel�̒l���|��������
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, sensitivity, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, -sensitivity, 0);
            }
        }
        else
        {
            upspeed = 1;
            backspeed = 1;
        }

    }
}

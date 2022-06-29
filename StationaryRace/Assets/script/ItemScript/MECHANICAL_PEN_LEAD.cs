using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MECHANICAL_PEN_LEAD : MonoBehaviour
{

    private Rigidbody rb;
    private float speed;
    public int durability;
    Quaternion kai;
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 40.0f;
        Invoke("Des", 20);
        rb.velocity = transform.forward * speed;
        durability = 1;
        Player = GameObject.Find("Car");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        if (durability == 0)
        {
            Des();
        }
    }



    void Des()
    {
        Destroy(this.gameObject);
    }

    //�X�e�[�W�ɓ��������ۂɃt���O��؂�ւ���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            {
                durability -= 1;
                CarSc.SpeedDown();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Stage")
        {
            rb.isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;//�O���r�e�B���Ȃ���
        }
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
            CarSc.SpeedDown();
        }
    }
}

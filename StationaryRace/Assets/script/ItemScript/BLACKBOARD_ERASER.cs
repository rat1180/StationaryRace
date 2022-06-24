using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLACKBOARD_ERASER : MonoBehaviour
{
    public int durability;//�ϋv�l
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Car");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.
        durability = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            Destroy(this.gameObject);
        }
    }

    //�X�e�[�W�ɓ��������ۂɃt���O��؂�ւ���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        //if (collision.gameObject.tag == "Stage")
        {
            {
                durability -= 1;
                CarSc.SpeedDown();
                //this.GetComponent<BoxCollider>().isTrigger = true;//isTrigger������
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

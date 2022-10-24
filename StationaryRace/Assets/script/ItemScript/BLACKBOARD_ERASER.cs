using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //�A�C�e���̒萔�l���g�����߂ɋL��.

public class BLACKBOARD_ERASER : MonoBehaviour
{
    public int durability;   //�ϋv�l
    GameObject Player;       //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;               //Car�̃X�N���v�g���擾����.
    GameObject IManager;     //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    ItemManager IMSc;        //ItemManager�̃X�N���v�g���擾����.
    public Rigidbody rb;
    public GameObject Effect;//�X�e�[�W�ɓ��������ۂ̉��̃G�t�F�N�g

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Car");            //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>();         //�v���C���[�̃X�N���v�g���Q�Ƃ���.
        IManager = GameObject.Find("ITEMManager");  //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾.
        IMSc = IManager.GetComponent<ItemManager>();//�A�C�e���}�l�[�W���[�̃X�N���v�g���Q�Ƃ���.
        durability = 1;
    }

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
        Instantiate(Effect, this.transform.position, Quaternion.identity);//���̃G�t�F�N�g�\��.
        if (collision.gameObject.tag == "Player")
        {
            {
                durability -= 1;
                CarSc.SpeedDown();//Car���̊֐����Ăяo��
                IMSc.ItemIcon(ITEMConst.ITEM.BLACKBOARD_ERASER);//�A�C�e��HIT�A�C�R���ɉ摜������
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Instantiate(Effect, this.transform.position, Quaternion.identity);//�G�t�F�N�g�\��.
        if (collider.gameObject.tag == "Stage")
        {
            rb.isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;//�O���r�e�B���Ȃ���
            Instantiate(Effect, this.transform.position, Quaternion.identity);//�G�t�F�N�g�\��.
        }
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
            CarSc.SpeedDown();//Car���̊֐����Ăяo��
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKY_NOTE : MonoBehaviour
{
    public int durability;//�ϋv�l
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    //testplay PlayerSc; //�v���C���[�̊֐����ĂԂ��߂̏���
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(2, 6); ; //�ϋv�l��2�`6�Ń����_���Ɍ��߂�
        Player= GameObject.Find("Player");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        //PlayerSc = Player.GetComponent<testplay>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.
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
        if (collision.gameObject.tag == "Stage")
        {
            this.GetComponent<BoxCollider>().isTrigger = true;//isTrigger������
            this.GetComponent<Rigidbody>().useGravity = false;//�O���r�e�B���Ȃ���
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
        }
        //�����Ńv���C���[�̃X�s�[�h�A�b�v�֐����Ăяo��
        //PlayerSc.SpeedUp(); //�v���[���[�X�N���v�g�ŃX�s�[�h�A�b�v�֐����Ă�
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKY_NOTE : MonoBehaviour
{
    private int durability;//�ϋv�l
    private float SpeedNow;
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;

    //testplay PlayerSc; //�v���C���[�̊֐����ĂԂ��߂̏���
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(2, 6); ; //�ϋv�l��2�`6�Ń����_���Ɍ��߂�
        Player= GameObject.Find("Car");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.
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
            {
                this.GetComponent<Rigidbody>().useGravity = false;//�O���r�e�B���Ȃ���
                this.GetComponent<BoxCollider>().isTrigger = true;//isTrigger������
            }
        }
    }

        void OnTriggerEnter(Collider collider)
        {
            // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
            if (collider.gameObject.tag == "Player")
            {
                SpeedNow = CarSc.upspeed;
                durability -= 1;
                StartCoroutine("SpeedUp");
            }
    }
    //�X�s�[�h�A�b�v
    IEnumerator SpeedUp()
    {
        CarSc.upspeed = 1000.0f;
        yield return new WaitForSeconds(3.0f);
        CarSc.upspeed = SpeedNow;
    }
}

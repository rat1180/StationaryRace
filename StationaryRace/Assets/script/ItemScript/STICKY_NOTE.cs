using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class STICKY_NOTE : StrixBehaviour
{
    public int durability;     //�ϋv�l
    private float SpeedNow;    //���݂̃X�s�[�h������.
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car CarSc;                 //Car�̃X�N���v�g���擾.
    public Rigidbody rb;
    public GameObject SOUND;   //����炷����.

    //testplay PlayerSc; //�v���C���[�̊֐����ĂԂ��߂̏���
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        durability = Random.Range(2, 6); ; //�ϋv�l��2�`6�Ń����_���Ɍ��߂�
        Player= GameObject.Find("Car");    //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        CarSc = Player.GetComponent<Car>();//�v���C���[�̃X�N���v�g���Q�Ƃ���.
    }

    // Update is called once per frame
    void Update()
    {
        if (durability <= 0)//�ϋv�l��0�ɂȂ�����
        {
            Destroy(this.gameObject);
        }
    }

    //�X�e�[�W�ɓ��������ۂɃt���O��؂�ւ���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                SpeedNow = CarSc.upspeed;                                          //Car�̕ϐ��ɑ��.
                durability -= 1;                                                   //�ϋv�l�����炷.
                Instantiate(SOUND, this.transform.position, Quaternion.identity);
                StartCoroutine("SpeedUp");                                         //�X�s�[�h�A�b�v
                //this.GetComponent<BoxCollider>().isTrigger = true;//isTrigger������
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
         SpeedNow = CarSc.upspeed;
         durability -= 1;
            Instantiate(SOUND, this.transform.position, Quaternion.identity);
            StartCoroutine("SpeedUp");
       }
    }
    //�X�s�[�h�A�b�v
    IEnumerator SpeedUp()
    {
        CarSc.upspeed = 100.0f;
        yield return new WaitForSeconds(2.0f);//�Q�b��.
        CarSc.upspeed = SpeedNow;             //���̃X�s�[�h�ɖ߂�.
    }
}

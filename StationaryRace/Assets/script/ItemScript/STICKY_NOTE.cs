using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKY_NOTE : MonoBehaviour
{
    public int durability;//�ϋv�l
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    Car PlayerSc; //�v���C���[�̊֐����ĂԂ��߂̏���
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(2, 6); ; //�ϋv�l��2�`6�Ń����_���Ɍ��߂�
        Player= GameObject.Find("Car");         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        PlayerSc = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.

        this.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit");
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collision.gameObject.tag == "Player")
        {
            durability -= 1;
        }
        //�����Ńv���C���[�̃X�s�[�h�A�b�v�֐����Ăяo��
        PlayerSc.ItemSpeedUp(); //�v���[���[�X�N���v�g�ŃX�s�[�h�A�b�v�֐����Ă�
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class KESHIKASU_BOM : StrixBehaviour
{
    public GameObject ERASER_RESIDDUE;//�P�V�J�X�̃v���t�@�u���g��
    public GameObject SOUND;          //��������炷�v���t�@�u������
    public GameObject Effect;
    private Rigidbody rb;             //Rigidbody���g�p���邽�߂̐錾
    private float speed;              //���x������ϐ�
    private Vector3 Pos;              //���ݒn�擾�p
    int i;                            //���[�v�p

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal) return;
        rb = GetComponent<Rigidbody>();
        speed = 100.0f;  //���x�̐ݒ�
        Invoke("Des", 1);//1�b��Ɋ֐����Ăяo��
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocal) return;
        rb.velocity = transform.forward * speed;//���ʂɐi�ޏ���
    }
    void Des()
    {
        Pos = this.transform.position;               //���ݒn���擾.
        Instantiate(SOUND, Pos, Quaternion.identity);//��������炷.
        Instantiate(Effect,Pos, Quaternion.identity);//�G�t�F�N�g�\��.
        for (i = 0; i < 33; i++)                     //�P�V�J�X��99����
        {
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(90, 0, 0));
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(0, 90, 0));
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(0, 0, 90));
        }
        Destroy(this.gameObject);//���e��j��
    }
}

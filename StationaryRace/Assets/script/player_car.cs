using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_car : MonoBehaviour
{
    public float speed = 10.0f;        //�������x
    public int type = 0;               //�e�N�X�`���̑I��
    public Material[] _material;       //�e�N�X�`���̊��蓖��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //�O�����Ɉړ�
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0.0f, 0.0f, 0.03f);
        //�������Ɉړ�
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(-0.03f, 0.0f, 0.0f);
        //������Ɉړ�
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(0.0f, 0.0f, -0.03f);
        //�E�����Ɉړ�
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(0.03f, 0.0f, 0.0f);

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
}

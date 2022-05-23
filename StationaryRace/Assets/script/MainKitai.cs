using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    public int MachineNum = 0;         //�@�̔ԍ�
    private int o_max = 0;             //�@�̐�
    GameObject[] kitaiObject;          //�I�u�W�F�N�g�̊��蓖��

    public int Player_Mode = 0; //�v���[���[�̏��

    private const int StartRase = 10;   //���[�X�O
    private const int RaseNow = 20;     //���[�X��
    private const int Goal = 30;        //�S�[��
    private const int AttackItem = 40;  //�U���A�C�e������������
    private const int DownStage = 50;   //�X�e�[�W���痎����
    private const int ORIGAMI_CRANE = 60;//�߂̐܂莆�ɕϐg

    // Start is called before the first frame update
    void Start()
    {
        o_max = this.transform.childCount;        //�q�I�u�W�F�N�g�̌����擾
        kitaiObject = new GameObject[o_max];      //�C���X�^���X�쐬

        //�S�Ă̎q�I�u�W�F�N�g���擾
        for(int i = 0; i < o_max; i++)
        {
            kitaiObject[i] = transform.GetChild(i).gameObject;
        }

        //�S�Ă̎q�I�u�W�F�N�g���A�N�e�B�u
        foreach (GameObject gamObj in kitaiObject)
        {
            gamObj.SetActive(false);
        }
        //������A�N�e�B�u�ɂ���
        kitaiObject[MachineNum].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g���A�N�e�B�u
            kitaiObject[MachineNum].SetActive(false);
            MachineNum++;

            //�q�I�u�W�F�N�g�����ׂĐ؂�ւ�����܂��ŏ��̃I�u�W�F�N�g�ɖ߂�
            if (MachineNum == o_max) { MachineNum = 0; }

            //���̃I�u�W�F�N�g���A�N�e�B�u��
            kitaiObject[MachineNum].SetActive(true);
        }
    }
}
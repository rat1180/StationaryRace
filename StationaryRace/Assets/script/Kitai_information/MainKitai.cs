using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    private int o_max = 2;             //�ő�@�̔ԍ�
    private float min_y = -13.0f;

    public int Player_Mode = 0;        //�@�̂̏��

    private const int CharacterChenge =  0;    //�L�����I��
    private const int StartRace       = 10;    //���[�X�O
    private const int RaseNow         = 20;    //���[�X��
    private const int Goal            = 30;    //�S�[��
    private const int AttackItem      = 40;    //�U���A�C�e������������
    private const int DownStage       = 50;    //�X�e�[�W���痎����
    private const int ORIGAMI_CRANE   = 60;    //�߂̐܂莆�ɕϐg

    public int MachineNum = 0;         //�@�̔ԍ�
    GameObject[] kitaiObject;          //�I�u�W�F�N�g�̊��蓖��

    ////�@�̂̐��\
    //public struct KitaiAblty
    //{

    //}

    //public struct KitaiNum
    //{
    //    public int num;
    //}

    // Start is called before the first frame update
    void Start()
    {
        o_max = this.transform.childCount;        //�q�I�u�W�F�N�g�̌����擾
        kitaiObject = new GameObject[o_max];      //�C���X�^���X�쐬

        //�S�Ă̎q�I�u�W�F�N�g���擾
        for (int i = 0; i < o_max; i++)
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
        switch (Player_Mode)
        {
            //�L�����I��
            case 0:
                MachineNumber();
                break;
            //�X�^�[�g�O
            case 10:
                break;
            //���[�X��
            case 20:
                break;
            //�S�[��
            case 30:
                break;
            case 40:
                break;
            //������
            case 50:
                break;
            default:
                Debug.Log("PlayerMode�G���[");
                break;
        }
    }

    //�@�̂̏�Ԃ̎󂯎��
    public void MachineMode()
    {
        //Player_Mode = mode;

        //if (Player_Mode == 10)
        //{
        //    MachineNumber();
        //}
    }

    public void MachineNumber()
    {
        //MachineNum = machine_num;

        if (Input.GetKeyDown("q"))
        {
            //���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g���A�N�e�B�u
            kitaiObject[MachineNum].SetActive(false);
            MachineNum++;

            //�q�I�u�W�F�N�g�����ׂĐ؂�ւ�����܂��ŏ��̃I�u�W�F�N�g�ɖ߂�
            if (MachineNum == o_max) { MachineNum = 0; }

            KitaiChange();

        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Player_Mode = 10;
            Debug.Log("�L�����I���I���");
        }
    }

    //���[�U�[����@�̔ԍ��̎󂯎��
    private void KitaiChange()
    {
        switch (MachineNum)
        {
            case 0:
                //���̃I�u�W�F�N�g���A�N�e�B�u��
                kitaiObject[MachineNum].SetActive(true);
                Debug.Log(MachineNum);
                break;
            case 1:
                //���̃I�u�W�F�N�g���A�N�e�B�u��
                kitaiObject[MachineNum].SetActive(true);
                Debug.Log(MachineNum);
                break;
            case 2:
                //���̃I�u�W�F�N�g���A�N�e�B�u��
                kitaiObject[MachineNum].SetActive(true);
                Debug.Log(MachineNum);
                break;
            case 3:
                break;
            default:
                Debug.LogError("�@�̔ԍ����Ăяo����܂���ł���");
                break;
        }
    }
}
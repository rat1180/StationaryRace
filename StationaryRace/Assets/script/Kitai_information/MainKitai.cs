using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainKitai : MonoBehaviour
{
    public int Player_Mode = 10;        //�@�̂̏��
    public GameObject Skin;            //�I�u�W�F�N�g�̊��蓖��

    private const int CharacterChenge =  0;    //�L�����I��
    private const int StartRace       = 10;    //���[�X�O
    private const int RaseNow         = 20;    //���[�X��
    private const int Goal            = 30;    //�S�[��
    private const int AttackItem      = 40;    //�U���A�C�e������������
    private const int DownStage       = 50;    //�X�e�[�W���痎����
    private const int ORIGAMI_CRANE   = 60;    //�߂̐܂莆�ɕϐg

    private int MachineNum = 0;         //�@�̔ԍ�
    private int SkinNum = 0;

    public CountTime countTime;
    private float Atime = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PLmode();
    }

    private void PLmode()
    {
        Atime -= Time.deltaTime;

        switch (Player_Mode)
        {
            ////�L�����I��
            //case 0:
            //    KeyProcess();
            //    break;
            //�X�^�[�g�O
            case 10:
                MachineMode();
                break;
            //���[�X��
            case 20:
                if(Atime <= 0)
                {
                    Player_Mode = 30;
                }
                break;
            //�S�[��
            case 30:
                Debug.Log("�S�[��");
                SceneManager.LoadScene("KitaiSelect");
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
    private void MachineMode()
    {
        //if (Player_Mode == 0)
        //{
        //    MachineNumber();
        //}

        if (countTime.gamestart == 1)
        {
            Player_Mode = 20;
            Debug.Log("���[�X��");
        }
    }
}
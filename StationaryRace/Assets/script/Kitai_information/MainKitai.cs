using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SoftGear.Strix.Unity.Runtime;

public class MainKitai : MonoBehaviour
{
    private const int CharacterChenge = 0;    //�L�����I��
    private const int StartRace = 10;    //���[�X�O
    private const int RaseNow = 20;    //���[�X��
    private const int Goal = 30;    //�S�[��
    private const int AttackItem = 40;    //�U���A�C�e������������
    private const int DownStage = 50;    //�X�e�[�W���痎����
    private const int ORIGAMI_CRANE = 60;    //�߂̐܂莆�ɕϐg

    private float Atime = 10;           //�e�X�g�p�^�C�}�[

    public int Player_Mode = 10;        //�@�̂̏��
    public GameObject Skin;             //�I�u�W�F�N�g�̊��蓖��
    public CountTime countTime;         //CountTime�X�N���v�g�֎Q��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (!isLocal) return;
        PLmode();
    }

    /// <summary>
    /// �v���C���[�̏�ԊǗ�
    /// </summary>
    private void PLmode()
    {
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
                Player_Mode = 30;
                break;
            //�S�[��
            case 30:
                Debug.Log("�S�[��");
                SceneManager.LoadScene("KitaiSelect");
                break;
            //�U���A�C�e���ɏՓ�
            case 40:
                break;
            //������
            case 50:
                break;
            //�߂̐܂莆�ɕϐg
            case 60:
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

        //if (countTime.gamestart == 1)
        //{
        //    Player_Mode = 20;
        //    Debug.Log("���[�X��");
        //}
    }
}
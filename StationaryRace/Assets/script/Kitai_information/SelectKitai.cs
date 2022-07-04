using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectKitai : MonoBehaviour
{
    private int mode = 0;              //�@�̂̏��
    private int MachineNum = 0;        //�@�̔ԍ�
    private int SkinNum = 0;

    public GameObject Skin;            //�I�u�W�F�N�g�̊��蓖��

    // Start is called before the first frame update
    void Start()
    {
        Skin = this.transform.Find("Skin").gameObject;

        //Skin���̑S�Ă̎q�I�u�W�F�N�g���A�N�e�B�u
        for (int i = 0; i < Skin.transform.childCount; i++)
        {
            Skin.transform.GetChild(i).gameObject.SetActive(false);
        }

        //�ŏ��̈���A�N�e�B�u
        Skin.transform.GetChild(SkinNum).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            //�L�����I��
            case 0:
                KeyProcess();
                break;
            case 1:
                SelectOff();
                break;
            default:
                Debug.Log("PlayerMode�G���[");
                break;
        }
    }

    /// <summary>
    /// �L�[�{�[�h����
    /// </summary>
    private void KeyProcess()
    {
        //Q�L�[����
        if (Input.GetKeyDown("q"))
        {
            //���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g���A�N�e�B�u
            Skin.transform.GetChild(MachineNum).gameObject.SetActive(false);
            MachineNum++;

            //�q�I�u�W�F�N�g�����ׂĐ؂�ւ�����܂��ŏ��̃I�u�W�F�N�g�ɖ߂�
            if (MachineNum == Skin.transform.childCount) { MachineNum = 0; }

            KitaiChange();   //�@�̕ύX

        }

        //Enter�L�[����
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //�X�^�[�g�O�փV�[���؂�ւ�
            //SceneManager.LoadScene("Kitai");
            mode = 1;
                Debug.Log("�L�����I���I���");
        }
    }

    /// <summary>
    /// �@�̂̃e�N�X�`���Ɛ��\�̐؂�ւ�
    /// </summary>
    private void KitaiChange()
    {
        switch (MachineNum)
        {
            case 0:
                //���̃I�u�W�F�N�g���A�N�e�B�u��
                Skin.transform.GetChild(MachineNum).gameObject.SetActive(true);
                Debug.Log("�@�̔ԍ� : " + MachineNum);
                break;
            case 1:
                Skin.transform.GetChild(MachineNum).gameObject.SetActive(true);
                Debug.Log("�@�̔ԍ� : " + MachineNum);
                break;
            case 2:
                Skin.transform.GetChild(MachineNum).gameObject.SetActive(true);
                Debug.Log("�@�̔ԍ� : " + MachineNum);
                break;
            case 3:
                break;
            default:
                Debug.LogError("�@�̔ԍ����Ăяo����܂���ł���");
                break;
        }
    }

    public void SelectOff()
    {
        this.GetComponent<SelectKitai>().enabled = false;
    }
}

class SceneLoder
{

}
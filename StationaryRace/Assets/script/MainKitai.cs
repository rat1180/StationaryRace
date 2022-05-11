using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainKitai : MonoBehaviour
{
    public int KitaiNumber = 0;        //�@�̔ԍ�
    private int o_max = 0;             //�@�̐�
    //public Material[] _material;       //�e�N�X�`���̊��蓖��
    GameObject[] kitaiObject;   //�I�u�W�F�N�g�̊��蓖��

    // Start is called before the first frame update
    void Start()
    {
        o_max = this.transform.childCount;     //�q�I�u�W�F�N�g�̌����擾
        kitaiObject = new GameObject[o_max];

        for(int i = 0; i < o_max; i++)
        {
            kitaiObject[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject gamObj in kitaiObject)
        {
            gamObj.SetActive(false);
        }
        kitaiObject[KitaiNumber].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g���A�N�e�B�u
            kitaiObject[KitaiNumber].SetActive(false);
            KitaiNumber++;

            //�q�I�u�W�F�N�g�����ׂĐ؂�ւ�����܂��ŏ��̃I�u�W�F�N�g�ɖ߂�
            if (KitaiNumber == o_max) { KitaiNumber = 0; }

            //���̃I�u�W�F�N�g���A�N�e�B�u��
            kitaiObject[KitaiNumber].SetActive(true);
        }
    }

    /*
    //�I�����ꂽ�@�̂̔ԍ����󂯎��
    public void KitaiSet(int type)
    {
        KitaiNumber = type;

        //�@�̂̃e�N�X�`���ύX
        switch (type)
        {
            case 0:
                this.GetComponent<Renderer>().material = kitaiObject[0];
                break;
            case 1:
                this.GetComponent<Renderer>().material = kitaiObject[1];
                break;
            case 2:
                this.GetComponent<Renderer>().material = kitaiObject[2];
                break;
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class whereserect : MonoBehaviour
{
   
    /*
     * ���ݑI�𒆂̃{�^��
     */
    
    private GameObject Button;
    /*
     * ���݂̈�O�ɑI�����Ă����{�^��
     */
   
    private GameObject ButtonBuf;
    /*
     * �{�^���ɕt������G�t�F�N�g
     */
    
    private GameObject[] ButtonEffect = new GameObject[3];
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        * ���݂̑I������Ă���{�^�����擾���AButton�ɑ��
        */
        Button = EventSystem.current.currentSelectedGameObject;
        /*
         *-----------------------------------------------------------------------------------
         * update��1��ڂ����s������(Start�̎��ɑI������Ă���{�^�����擾�ł��Ȃ���������)
         * ButtonBuf�Ɍ��݂̑I������Ă���{�^������(������)
         *-----------------------------------------------------------------------------------
         */
        if (i == 0)
        {
            ButtonBuf = Button;
            i++;
        }
        /*
         *-----------------------------------------------------------------------------------------
         * ���݂̑I������Ă���{�^�����O�ɑI������Ă���{�^���ƈႤ�ꍇ(�I�������ړ��������ꍇ)
         * ���݂̃{�^���̃G�t�F�N�g��\��������
         * ��O�ɑI�����Ă����{�^���̃G�t�F�N�g���\���ɂ�����
         *-----------------------------------------------------------------------------------------
         */
        if (Button != ButtonBuf)
        {
            int j = 0;
            /*
             * �I�𒆂̃{�^���̎q�v�f���擾(1�Ԗڂ̗v�f�͕����Ȃ̂Ŕ�΂�)
             */
            foreach (Transform child in Button.transform)
            {
                ButtonEffect[j] = child.gameObject;
                if (j > 0) ButtonEffect[j].SetActive(true);
                j++;
            }
            /*
            * �e�L�X�g�̃G�t�F�N�g��ON�ɂ���
            */
            ButtonEffect[0].GetComponent<whereserect>().enabled = true;
            j = 0;
            /*
             * ��O�ɂɑI�����Ă����{�^���̎q�v�f���擾(1�Ԗڂ̗v�f�͕����Ȃ̂Ŕ�΂�)
             */
            foreach (Transform child in ButtonBuf.transform)
            {
                ButtonEffect[j] = child.gameObject;
                if (j > 0) ButtonEffect[j].SetActive(false);
                j++;
            }
            /*
            * �e�L�X�g�̃G�t�F�N�g��OFF�ɂ���
            */
            ButtonEffect[0].GetComponent<whereserect>().enabled = false;
            /*
            * �e�L�X�g�̃G�t�F�N�g�𕁒ʂ̏��(0)�ɖ߂�
            */
            TextMeshProUGUI tmPro = ButtonEffect[0].GetComponent<TextMeshProUGUI>();
            Material material = tmPro.fontMaterial;
            material.SetFloat("_OutlineWidth", 0);
        }
            /*
         * ���ݑI������Ă���{�^����ButtonBuf�ɑ��(���݂̃{�^������O�ɑI�����Ă����{�^���ɐݒ肷��)
         */
            ButtonBuf = Button;
        }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct KEYS
{
    //�A�N�Z���L�[ true:�I�� false:�I�t
    bool AcceleKey;
    //�u���[�L�L�[ true:�I�� false:�I�t
    bool BrakeKey;
    //�A�C�e���L�[ true:�I�� false:�I�t
    bool ItemKey;
    //�n���h�����̓L�[ 0:�Ȃ� 1:�E 2:��
    int HandleKey;

}

public class UserOperation : MonoBehaviour
{
    /******************
     �e�L�[�̓��͔���p�ϐ�
    *******************/

    public KEYS key;

    

    /****************
     �q�N���X�̎擾�p�I�u�W�F�N�g
    *****************/

    //�����̋@��
    //private gameobject 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�L�[�̏�����
    private void InitKey()
    {
        key.AcceleKey = false;
        key.BrakeKey = false;
        key.ItemKey = false;
        key.HandleKey = 0;

    }

}
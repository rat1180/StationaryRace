using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //�A�C�e���̒萔(ITEMConst.cs)���Ăяo�����߂ɋL��
public class TestDestroy : MonoBehaviour
{
    int rnd = 0; //�����p
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5);//5�b��ɂ��̃I�u�W�F�N�g��j�󂷂�
    }

    // Update is called once per frame
    void Update()
    {
        rnd = Random.Range(100, 110); // �� 1�`9�͈̔͂Ń����_���Ȑ����l���Ԃ�
        //Debug.Log(ITEMConst.ITEM.ENPITU);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}

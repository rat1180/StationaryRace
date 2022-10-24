using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class ERASER_RESIDDUE : StrixBehaviour
{
    public int durability;//�ϋv�l
    GameObject IManager;  //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    ItemManager IMSc;     //�A�C�e���}�l�[�W���[�̃X�N���v�g���擾����.

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal) return;
        Invoke("Des", 5);                             //5�b��ɔj�󂷂�.
        IManager = GameObject.Find("ITEMManager");    //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾.
        IMSc = IManager.GetComponent<ItemManager>();  //�A�C�e���}�l�[�W���[�̃X�N���v�g���Q�Ƃ���.
    }

    void Update(){}

    //�X�e�[�W�ɓ��������ۂɃt���O��؂�ւ���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
                this.GetComponent<Rigidbody>().useGravity = false;     //�O���r�e�B���Ȃ���
                this.GetComponent<CapsuleCollider>().isTrigger = true; //isTrigger������
        }
        if (collision.gameObject.tag == "Player")
        {
            Des();
        }
        }
    //���g��j�󂷂�֐�.
    void Des()
    {
        //IMSc.ItemIcon(ITEMConst.ITEM.ERASER_RESIDDUE);
        Destroy(this.gameObject);
    }
}

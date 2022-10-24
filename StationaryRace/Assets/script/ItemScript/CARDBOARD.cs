using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;


public class CARDBOARD : StrixBehaviour
{
    public GameObject SOUND;
    private int durability;
    private Rigidbody rb;
    GameObject IManager; //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    ItemManager IMSc;//ItemManager�̃X�N���v�g���擾����.

    void Start()
    {
        if (!isLocal) return;
        rb = GetComponent<Rigidbody>();
        durability = 1;
        rb.velocity = transform.forward;//�������擾.
        Instantiate(SOUND, this.transform.position, Quaternion.identity);//�i�{�[���̉����o��.
        IManager = GameObject.Find("ITEMManager");    //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾.
        IMSc = IManager.GetComponent<ItemManager>(); //�A�C�e���}�l�[�W���[�̃X�N���v�g���Q�Ƃ���.
    }

    void Update()
    {

        if (!isLocal) return;
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            IMSc.ItemIcon(ITEMConst.ITEM.CARDBOARD);//�A�C�e��HIT�A�C�R�����o��.
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collision.gameObject.tag == "Player")
        {
            durability -= 1;
        }
    }
}

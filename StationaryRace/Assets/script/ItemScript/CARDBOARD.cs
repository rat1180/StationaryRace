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
    ItemManager IMSc;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal) return;
        rb = GetComponent<Rigidbody>();
        durability = 1;
        rb.velocity = transform.forward;
        Instantiate(SOUND, this.transform.position, Quaternion.identity);
        IManager = GameObject.Find("ITEMManager");    //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾.
        IMSc = IManager.GetComponent<ItemManager>(); //�A�C�e���}�l�[�W���[�̃X�N���v�g���Q�Ƃ���.
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocal) return;
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            IMSc.ItemIcon(ITEMConst.ITEM.CARDBOARD);
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

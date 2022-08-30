using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAPE_BALL : MonoBehaviour
{
    private int durability;
    public Vector3 Pos;
    GameObject IManager; //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    ItemManager IMSc;
    // Start is called before the first frame update
    void Start()
    {
        durability = 1;
        Pos = this.transform.position;
        IManager = GameObject.Find("ITEMManager");    //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾.
        IMSc = IManager.GetComponent<ItemManager>(); //�A�C�e���}�l�[�W���[�̃X�N���v�g���Q�Ƃ���.
    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            IMSc.ItemIcon(ITEMConst.ITEM.TAPE_BALL);
            Destroy(this.gameObject);
        }
        Pos.y += 5;
        Pos.z += 5;
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

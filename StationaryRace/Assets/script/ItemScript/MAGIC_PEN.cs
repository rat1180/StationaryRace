using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class MAGIC_PEN : StrixBehaviour
{
    private Rigidbody rb;
    private float speed;
    public int durability;
    GameObject ItemMana;
    ItemManager IMana;

    // Start is called before the first frame update
    void Start()
    {
        ItemMana = GameObject.Find("ITEMManager");   //�A�C�e���}�l�[�W���[���擾.
        IMana = ItemMana.GetComponent<ItemManager>();//�A�C�e���}�l�[�W���[�̃X�N���v�g���擾

        rb = GetComponent<Rigidbody>();//Rigidbody���擾
        speed = 100.0f;//�X�s�[�h��ݒ�
        //Invoke("Des", 10);
        rb.velocity = transform.forward * speed;//�����Ă���������擾
        durability = 1;//�ϋv�l�A�P   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        if (durability <= 0)//�ϋv�l��0�ȉ��ɂȂ�����
        {
            IMana.INK();
            Des();
        }
    }
    /// <summary>
    /// �ϋv�l��0�ɂȂ������ɂ��̃I�u�W�F�N�g��j�󂷂�֐�
    /// </summary>
    void Des()
    {
        Destroy(this.gameObject);
        IMana.ItemIcon(ITEMConst.ITEM.MAGIC_PEN);
    }

    void OnTriggerEnter(Collider collider)
    {
        durability -= 1;
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collider.gameObject.tag == "Player")
        {

        }
    }
}


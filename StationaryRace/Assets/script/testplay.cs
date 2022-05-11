using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplay : MonoBehaviour
{
    public float speed = 0.1f;
    public bool itemhave = false;
    private int USER_Num = 0;//���[�U�ԍ�
    ItemManager IManager;//�A�C�e���}�l�[�W���[�Q�Ə���

    GameObject ItemMana;       //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.

    // Start is called before the first frame update
    void Start()
    {
        ItemMana = GameObject.Find("ITEMManager");   //�A�C�e���}�l�[�W���[���擾.
        IManager = ItemMana.GetComponent<ItemManager>();
        USER_Num = 1; //���[�U�[�ԍ��i�����ł͎����I��1�j
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[���͂ňړ�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        //�X�y�[�X�L�[�ŃA�C�e���̎g�p�i�e�X�g�j
        if (Input.GetKey(KeyCode.Space))
        {
            IManager.Item_Use(USER_Num);//
            itemhave = false;
        }
    }
    public void ItemHave()
    {
        IManager.USER_NUM(USER_Num);
        itemhave = true;
    }

    public int NUMBER_RETURN() //���[�U�[�ԍ���Ԃ��֐�
    {
        return USER_Num;
    }
}

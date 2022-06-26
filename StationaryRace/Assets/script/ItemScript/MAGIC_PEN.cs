using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAGIC_PEN : MonoBehaviour
{

    private Rigidbody rb;
    private float speed;
    public int durability;
    GameObject ItemMana;
    ItemManager IMana;
    GameObject ItemUI;
    GameObject INDIA_INK;
    INDIA_INK InkSc;

    // Start is called before the first frame update
    void Start()
    {
        ItemMana = GameObject.Find("ITEMManager");  //�A�C�e���}�l�[�W���[���擾.
        IMana = ItemMana.GetComponent<ItemManager>();
        ItemUI = transform.GetChild(0).gameObject;
        INDIA_INK = ItemUI.GetComponent<Transform>().transform.GetChild(0).gameObject;

        InkSc = INDIA_INK.GetComponent<INDIA_INK>();

        rb = GetComponent<Rigidbody>();
        speed = 8.0f;
        //Invoke("Des", 10);
        rb.velocity = transform.forward * speed;

        durability = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            IMana.INK();
            Des();
        }
    }



    void Des()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        InkSc.Animation();
        durability -= 1;
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("hitoooooooo");
            //InkSc.Animation();
            //durability -= 1;

        }
    }
}

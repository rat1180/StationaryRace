using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERASER_RESIDDUE : MonoBehaviour
{
    public int durability;//�ϋv�l
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Des", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�X�e�[�W�ɓ��������ۂɃt���O��؂�ւ���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            {
                this.GetComponent<Rigidbody>().useGravity = false;//�O���r�e�B���Ȃ���
                this.GetComponent<CapsuleCollider>().isTrigger = true;//isTrigger������
            }
        }
    }
    void Des()
    {
        Destroy(this.gameObject);
    }
}

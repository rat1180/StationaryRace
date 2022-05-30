using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARDBOARD : MonoBehaviour
{
    private int durability;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        durability = 1;
        rb.velocity = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
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

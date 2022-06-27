using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;


public class CARDBOARD : StrixBehaviour
{
    private int durability;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal) return;
        rb = GetComponent<Rigidbody>();
        durability = 1;
        rb.velocity = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocal) return;
        if (durability == 0)//耐久値が0になったら
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手にPlayerタグが付いているとき.
        if (collision.gameObject.tag == "Player")
        {
            durability -= 1;
        }
    }
}

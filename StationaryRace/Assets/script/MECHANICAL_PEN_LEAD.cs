using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MECHANICAL_PEN_LEAD : MonoBehaviour
{

    private Rigidbody rb;
    private float speed;
    private int durability;
    Quaternion kai;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5.0f;
        Invoke("Des", 3);
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        //transform.Rotate(90, 0, 0);
    }



    void Des()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
        }
    }
}

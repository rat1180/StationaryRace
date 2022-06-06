using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MECHANICAL_PEN_LEAD : MonoBehaviour
{

    private Rigidbody rb;
    private float speed;
    private Vector3 Pos;
    private int durability;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 30.0f;
        Invoke("Des", 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
        //this.transform.Translate(Vector3.forward * speed);
    }
    void Des()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        // Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«.
        if (collider.gameObject.tag == "Player")
        {
            durability -= 1;
        }
    }
}

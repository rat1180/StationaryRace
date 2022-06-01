using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KESHIKASU_BOM : MonoBehaviour
{
    public GameObject ERASER_RESIDDUE;

    private Rigidbody rb;
    private float speed;
    private Vector3 Pos;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 30.0f;
        Invoke("Des", 1);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        
    }
    void Des()
    {
        Pos = this.transform.position;
        for (i = 0; i < 100; i++)
        {
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(90, 0, 0));
        }
        Destroy(this.gameObject);
    }
}

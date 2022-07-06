using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class KESHIKASU_BOM : StrixBehaviour
{
    public GameObject ERASER_RESIDDUE;
    public GameObject SOUND;
    private Rigidbody rb;
    private float speed;
    private Vector3 Pos;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocal) return;
        rb = GetComponent<Rigidbody>();
        speed = 30.0f;
        Invoke("Des", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocal) return;
        rb.velocity = transform.forward * speed;
        
    }
    void Des()
    {
        Pos = this.transform.position;
        Instantiate(SOUND, Pos, Quaternion.identity);
        for (i = 0; i < 33; i++)
        {
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(90, 0, 0));
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(0, 90, 0));
            Instantiate(ERASER_RESIDDUE, Pos, Quaternion.Euler(0, 0, 90));
        }
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destory", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Destory()
    {
        Destroy(this.gameObject);
    }
}

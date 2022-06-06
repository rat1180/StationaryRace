using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERASER_RESIDDUE : MonoBehaviour
{
    public int durability;//耐久値
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Des", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ステージに当たった際にフラグを切り替える
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            {
                this.GetComponent<Rigidbody>().useGravity = false;//グラビティをなくす
                this.GetComponent<CapsuleCollider>().isTrigger = true;//isTriggerをつける
            }
        }
    }
    void Des()
    {
        Destroy(this.gameObject);
    }
}

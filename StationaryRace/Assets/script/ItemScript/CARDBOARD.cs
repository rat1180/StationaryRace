using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARDBOARD : MonoBehaviour
{
    private int durability;
    // Start is called before the first frame update
    void Start()
    {
        durability = 1;
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

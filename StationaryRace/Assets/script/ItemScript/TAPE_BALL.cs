using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAPE_BALL : MonoBehaviour
{
    private int durability;
    public Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        durability = 1;
        Pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            Destroy(this.gameObject);
        }
        Pos.y += 5;
        Pos.z += 5;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAPE_BALL : MonoBehaviour
{
    private int durability;
    GameObject IManager; //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    ItemManager IMSc;
    GameObject Car;
    Car CarSc;
    [SerializeField]
    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        durability = 5;
        speed = 0.01f;
        IManager = GameObject.Find("ITEMManager");    //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾.
        IMSc = IManager.GetComponent<ItemManager>(); //�A�C�e���}�l�[�W���[�̃X�N���v�g���Q�Ƃ���.
        Car = GameObject.Find("Car");
        CarSc = Car.GetComponent<Car>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * speed;
        if (durability == 0)//�ϋv�l��0�ɂȂ�����
        {
            Des();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        durability -= 1;
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collision.gameObject.tag == "Player")
        {
            IMSc.ItemIcon(ITEMConst.ITEM.TAPE_BALL);
            CarSc.GetComponent<Car>().SpeedDown();
            Des();
        }
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }

    void Des()
    {
        
        Destroy(this.gameObject);
    }
}

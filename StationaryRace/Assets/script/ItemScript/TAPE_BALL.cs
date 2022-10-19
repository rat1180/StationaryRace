using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAPE_BALL : MonoBehaviour
{
    private int durability;
    GameObject IManager; //アイテムマネージャーのゲームオブジェクトを取得する準備.
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
        IManager = GameObject.Find("ITEMManager");    //アイテムマネージャーのゲームオブジェクトを取得.
        IMSc = IManager.GetComponent<ItemManager>(); //アイテムマネージャーのスクリプトを参照する.
        Car = GameObject.Find("Car");
        CarSc = Car.GetComponent<Car>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * speed;
        if (durability == 0)//耐久値が0になったら
        {
            Des();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        durability -= 1;
        // 衝突した相手にPlayerタグが付いているとき.
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

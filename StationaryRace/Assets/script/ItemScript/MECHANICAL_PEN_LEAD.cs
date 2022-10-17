using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class MECHANICAL_PEN_LEAD : StrixBehaviour
{
    #region 元のソース
    GameObject target;
    GameObject Car;
    Car CarSc;
    public float speed;
    GameObject IManager;       //アイテムマネージャーのゲームオブジェクトを取得する準備.
    ItemManager IMSc;          //アイテムマネージャーのスクリプトを取得.
    public bool targetflg;
    string Name;
    GameObject Enemy;
    public GameObject FrontCollider;


    void Awake()
    {
        FrontCollider = GameObject.Find("FrontCollider");
        Name = FrontCollider.GetComponent<FrontColliderHIt>().Namereturn();
        Enemy = GameObject.Find(Name);
    }

    void Start()
    {

        if (Enemy == null)
        {
            Debug.Log("???");
        }
        speed = 0.05f;
        Car = GameObject.Find("Car");
        CarSc = Car.GetComponent<Car>();
        IManager = GameObject.Find("ITEMManager");  //アイテムマネージャーのゲームオブジェクトを取得.
        IMSc = IManager.GetComponent<ItemManager>();//アイテムマネージャーのスクリプトを参照する.
        Debug.Log(Name);
        targetflg = true;
    }

    void Update()
    {
        if (Enemy)
        {
            this.transform.LookAt(Enemy.transform);
            this.transform.position += transform.forward * speed;
        }
        else
        {
            transform.position += transform.forward * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手にPlayerタグが付いているとき.
        if (collision.gameObject.tag == "Player")
        {
            CarSc.GetComponent<Car>().SpeedDown();                                  //Car側の関数を呼び出す.
            //IMSc.ItemIcon(ITEMConst.ITEM.MECHANICAL_PEN_LEAD);  //アイテムHITアイテムを出す.
            Destroy(this.gameObject);
        }
    }

    public void HitPlayerCollider(string EnemyName)
    {
        //target = GameObject.Find("Cube");
        //Name = EnemyName;
        target = GameObject.Find(EnemyName);
        targetflg = true;
        //target = GameObject.Find(EnemyName);
        Debug.Log("nice");
        //this.transform.LookAt(target.transform);
        //targetflg = true;
    }
    #endregion


    #region 参考ソース

    //[SerializeField]
    //Transform target;
    //[SerializeField, Min(0)]
    //float time = 1;
    //[SerializeField]
    //float lifeTime = 2;
    //[SerializeField]
    //bool limitAcceleration = false;
    //[SerializeField, Min(0)]
    //float maxAcceleration = 100;
    //[SerializeField]
    //Vector3 minInitVelocity;
    //[SerializeField]
    //Vector3 maxInitVelocity;
    //Vector3 position;
    //Vector3 velocity;
    //Vector3 acceleration;
    //Transform thisTransform;
    //public Transform Target
    //{
    //    set
    //    {
    //        target = value;
    //    }
    //    get
    //    {
    //        return target;
    //    }
    //}
    //void Start()
    //{
    //    thisTransform = transform;
    //    position = thisTransform.position;
    //    velocity = new Vector3(Random.Range(minInitVelocity.x, maxInitVelocity.x), Random.Range(minInitVelocity.y, maxInitVelocity.y), Random.Range(minInitVelocity.z, maxInitVelocity.z));
    //    StartCoroutine(nameof(Timer));
    //}
    //public void Update()
    //{
    //    if (target == null)
    //    {
    //        return;
    //    }
    //    acceleration = 2f / (time * time) * (target.position - position - time * velocity);
    //    if (limitAcceleration && acceleration.sqrMagnitude > maxAcceleration * maxAcceleration)
    //    {
    //        acceleration = acceleration.normalized * maxAcceleration;
    //    }
    //    time -= Time.deltaTime;
    //    if (time < 0f)
    //    {
    //        return;
    //    }
    //    velocity += acceleration * Time.deltaTime;
    //    position += velocity * Time.deltaTime;
    //    thisTransform.position = position;
    //    thisTransform.rotation = Quaternion.LookRotation(velocity);
    //}
    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(lifeTime);
    //    Destroy(gameObject);
    //}
    #endregion
}

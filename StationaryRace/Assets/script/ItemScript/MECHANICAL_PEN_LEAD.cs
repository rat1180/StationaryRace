using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class MECHANICAL_PEN_LEAD : StrixBehaviour
{
    #region ���̃\�[�X
    GameObject target;
    GameObject Car;
    Car CarSc;
    public float speed;
    GameObject IManager;       //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    ItemManager IMSc;          //�A�C�e���}�l�[�W���[�̃X�N���v�g���擾.
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
        IManager = GameObject.Find("ITEMManager");  //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾.
        IMSc = IManager.GetComponent<ItemManager>();//�A�C�e���}�l�[�W���[�̃X�N���v�g���Q�Ƃ���.
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
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        if (collision.gameObject.tag == "Player")
        {
            CarSc.GetComponent<Car>().SpeedDown();                                  //Car���̊֐����Ăяo��.
            //IMSc.ItemIcon(ITEMConst.ITEM.MECHANICAL_PEN_LEAD);  //�A�C�e��HIT�A�C�e�����o��.
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


    #region �Q�l�\�[�X

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

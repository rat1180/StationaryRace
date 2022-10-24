using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontColliderHIt : MonoBehaviour
{
    string objName;
    GameObject Enemy;
    GameObject MECHANICAL_PEN;
    [SerializeField] GameObject Pen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collider)
    {
        // 衝突した相手にPlayerタグが付いているとき.
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            objName = collider.gameObject.name;
            Debug.Log(objName);
            //ここからテスト
            //Enemy = GameObject.Find(objName);
            //Enemy.GetComponent<Test>().DebugTest();
            //MECHANICAL_PEN = GameObject.Find("MECHANICAL_PEN_LEAD");
            //MECHANICAL_PEN.GetComponent<MECHANICAL_PEN_LEAD>().HitPlayerCollider(objName);
            //Pen.GetComponent<MECHANICAL_PEN_LEAD>().HitPlayerCollider(objName);
            //Pen.GetComponent<MECHANICAL_PEN_LEAD>().targetflg = true;

        }

    }
    public string Namereturn()
    {

        return objName;
    }
}

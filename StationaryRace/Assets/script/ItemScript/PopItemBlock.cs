using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using itemposition; //アイテムの場所の参照

public class PopItemBlock : MonoBehaviour
{
    public GameObject ItemBlock;
    public Vector3 item01 = new Vector3(2.111388f, 0.38f, 0.921896f);
    // Start is called before the first frame update
    void Start()
    {
        //ItemBlock.transform.Translate(7.1f, 0.02f, -0.329999f);
        //GameObject itemblock = (GameObject)Resources.Load("itemblock");
        // Cubeプレハブを元に、インスタンスを生成.
       Instantiate(ItemBlock, item01,Quaternion.identity);
       Instantiate(ItemBlock, new Vector3(1.5f,-0.06f,2.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

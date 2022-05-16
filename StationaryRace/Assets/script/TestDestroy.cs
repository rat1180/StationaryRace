using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ITEMConst; //アイテムの定数(ITEMConst.cs)を呼び出すために記入
public class TestDestroy : MonoBehaviour
{
    int rnd = 0; //乱数用
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5);//5秒後にこのオブジェクトを破壊する
    }

    // Update is called once per frame
    void Update()
    {
        rnd = Random.Range(100, 110); // ※ 1～9の範囲でランダムな整数値が返る
        //Debug.Log(ITEMConst.ITEM.ENPITU);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}

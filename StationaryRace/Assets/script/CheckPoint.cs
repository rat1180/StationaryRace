using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public int CPNm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //生成時に割り振り
    public void CPset(int Nm)
    {
        CPNm = Nm;
    }

    //自分の番号を渡す
    public int CheckP()
    {
        return CPNm;
    }

}

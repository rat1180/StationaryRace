using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private int CPNm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�������Ɋ���U��
    public void CPset(int Nm)
    {
        CPNm = Nm;
    }

    //�����̔ԍ���n��
    public int CheckP()
    {
        return CPNm;
    }

}

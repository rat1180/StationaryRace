using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_car : MonoBehaviour
{
    public int joutai = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�@�̂̏��
    public void State()
    {
        switch(joutai){
            case 0:       //�X�^�[�g�O
                break;
            case 1:       //���[�X��
                break;
            case -1:      //��e��
                break;
            default:
                break;
        }
    }
}

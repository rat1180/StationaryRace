using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheackFlame : MonoBehaviour
{
    int i;
    float time;
    float max;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        time = 0;
        max = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        i++;
        if(time >= max)
        {
            if (max == 1) {
                Debug.Log("1�b�o��:" + i);
                max = 3;
            }else if (max == 3)
            {
                Debug.Log("3�b�o��:" + i);
                max = 5;
            }else if (max == 5)
            {
                Debug.Log("5�b�o��:" + i);
                max = 10;
            }else if (max == 10)
            {
                Debug.Log("10�b�o��:" + i);
                max = 10000;
            }
        }

    }
}

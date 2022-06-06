using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    public float speed;
    private float blademove;
    private float time;
    private bool moveflg;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        moveflg = true;
    }

    // Update is called once per frame
    void Update()
    {
        BladeMove();
    }

    /// <summary>
    /// カッターの刃を動かす
    /// </summary>
    void BladeMove()  
    {
        // カウントダウン
        time -= Time.deltaTime;


        if (moveflg == true)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
 
            if (time <= 0)
            {
                moveflg = false;
                time = 3;
            }
        }
        else
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            
            if (time <= 0)
            {
                moveflg = true;
                time = 3;
            }
        }

    }
}

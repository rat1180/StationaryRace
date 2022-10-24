using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastShortCut : MonoBehaviour
{
    public GameObject Break_wall;
    public GameObject Break_wall2;

    private float speed = 10.0f;
    public bool BreakFlg = false;
    public bool BreakMsFlg = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(BreakFlg == true)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            BreakMsFlg = true;
        }
        if(BreakMsFlg == true)
        {
            Invoke("BomberMs", 8);
        }
    }
    public void Bomber()
    {
        BreakFlg = true;
        Break_wall.SetActive(false);
        Break_wall2.SetActive(false);
    }
    void BomberMs()
    {
        Destroy(this.gameObject);
    }
}

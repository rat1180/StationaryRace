using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastShortCut : MonoBehaviour
{
    public GameObject Break_wall;
    public GameObject Break_wall2;

    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Bomber()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        Break_wall.SetActive(false);
        Break_wall2.SetActive(false);
    }
}

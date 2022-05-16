using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplesource : MonoBehaviour
{
    private bool check_pt1;
    private bool check_pt2;
    private bool check_pt3;
    private bool finish;

    

    private float speed = 8.0f;

    private float rotateSpeed = 2.0f;             // 回転の速さ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // キー移動
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        // 視点移動
        // Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる
        transform.RotateAround(transform.position, Vector3.up, angle.x);
        transform.RotateAround(transform.position, transform.right, angle.y);
    }
    void OnCollisionEnter(Collision other)   // 触れている時のやつ
    {
        if (other.gameObject.tag == "check1")
        {
            check_pt1 = true;
        }
        if (other.gameObject.tag == "check2") // 地面に触れている時にジャンプできるようにする
        {
            check_pt2 = true;
        }
        if (other.gameObject.tag == "check3") // 地面に触れている時にジャンプできるようにする
        {
            check_pt3 = true;
        }
        if (other.gameObject.tag == "goal") // 地面に触れている時にジャンプできるようにする
        {
            finish = true;
        }
    }
}

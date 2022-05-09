using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestory : MonoBehaviour
{
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particle.isStopped) //パーティクルが終了したか判別
        {
            Destroy(this.gameObject);//パーティクル用ゲームオブジェクトを削除
        }
    }
    //衝突が発生した場合に実行される
    void OnCollisionEnter(Collision collision)
    {
        //衝突対象がPlayer(Ethan)の場合にparticleをPlayする
        if (collision.gameObject.tag == "Player")
            particle.Play();
    }
}

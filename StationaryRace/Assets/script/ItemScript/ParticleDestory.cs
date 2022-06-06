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
        if (particle.isStopped) //�p�[�e�B�N�����I������������
        {
            Destroy(this.gameObject);//�p�[�e�B�N���p�Q�[���I�u�W�F�N�g���폜
        }
    }
    //�Փ˂����������ꍇ�Ɏ��s�����
    void OnCollisionEnter(Collision collision)
    {
        //�ՓˑΏۂ�Player(Ethan)�̏ꍇ��particle��Play����
        if (collision.gameObject.tag == "Player")
            particle.Play();
    }
}

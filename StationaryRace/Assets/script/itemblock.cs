using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemblock : MonoBehaviour
{
    int rnd = 0;
    GameObject ItemNum; //�A�C�e���}�l�[�W���[�Ƀi���o�[�𑗂鏀��
    public AudioClip Dessound;              //CD�݂����Ȃ���
    AudioSource audioSource;               //CD�v���C���[�݂����Ȃ���
    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();
        ItemNum = GameObject.Find("ITEMManager");//�A�C�e���}�l�[�W���[��T��
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (collision.gameObject.tag == "Player")
        {
         AudioSource.PlayClipAtPoint(Dessound, transform.position);
            // 0.1�b��ɏ�����

         this.gameObject.SetActive(false);
         rnd = Random.Range(100, 111); // �� 100�`110�͈̔͂Ń����_���Ȑ����l���Ԃ�(int�^���ƌ��͏��O�����)
         ItemNum.GetComponent<ItemManager>().Item(rnd);//ItemManager�Ƃ����X�N���v�g��Item�֐����g��
            Invoke("Respawn", 3);
        }
    }
    void Respawn()
    {
      this.gameObject.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class itemblock : MonoBehaviour
{
    int ItemNum = 0;           //�A�C�e���}�l�[�W���[�ɐ��l��n���p�ϐ�.
    int USER_NUM = 1;          //���[�U�[�ԍ�
    GameObject ItemMana;       //�A�C�e���}�l�[�W���[�̃Q�[���I�u�W�F�N�g���擾���鏀��.
    GameObject Player;         //�v���C���[�̃Q�[���I�u�W�F�N�g���擾���鏀��. 
    Car ItemHave;         //�X�N���v�g���Q�Ƃ��鏀��.
    public AudioClip Dessound; //CD�݂����Ȃ���.
    AudioSource audioSource;   //CD�v���C���[�݂����Ȃ���.
    public GameObject SetBox_particle; //�A�C�e���{�b�N�X���j�󂳂ꂽ��p�[�e�B�N���𐶐�

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾.
        audioSource = GetComponent<AudioSource>();  //�I�[�f�B�I�\�[�X�̎擾.
        ItemMana = GameObject.Find("ITEMManager");  //�A�C�e���}�l�[�W���[���擾.
        Player = GameObject.Find("Car");            //�v���C���[�̃Q�[���I�u�W�F�N�g���擾.
        ItemHave = Player.GetComponent<Car>(); //�v���C���[�̃X�N���v�g���Q�Ƃ���.
    }

    // Update is called once per frame
    void Update()
    {
    }
    //�X�e�[�W�ɓ��������ۂɃt���O��؂�ւ���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            {
                this.GetComponent<Rigidbody>().useGravity = false;//�O���r�e�B���Ȃ���
                this.GetComponent<BoxCollider>().isTrigger = true;//isTrigger������
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")// �Փ˂��������Player�^�O���t���Ă���Ƃ�.
        {
            StrixReplicator Check = collider.transform.parent.GetComponent<StrixReplicator>();
            if (Check == null || !(Check.isLocal)) return;
            AudioSource.PlayClipAtPoint(Dessound, transform.position); //�A�C�e�����j�󂳂ꂽ�ۂɌ��ʉ���炷.

            this.gameObject.SetActive(false);                                           //�A�C�e���u���b�N�̃Q�[���I�u�W�F�N�g���\���ɂ���.
            Instantiate(SetBox_particle, this.transform.position, Quaternion.identity); //�p�[�e�B�N���𐶐�.

            if (ItemHave.itemhave == false)//�v���C���[���A�C�e���������Ă��Ȃ���΃A�C�e���}�l�[�W���[�ɐ��l��n��.
            {
                //USER_NUM = ItemHave.NUMBER_RETURN();                         //�ǂ̃v���C���[���A�C�e�����擾�������ԍ����Q��.
                ItemMana.GetComponent<ItemManager>().Item(); //ItemManager�Ƃ����X�N���v�g��Item�֐����g��.
                ItemHave.itemhave = true;                                         //�v���[���[�X�N���v�g�ŃA�C�e���t���O��true�ɂ���.
            }
            Invoke("Respawn", 3); //3�b��ɂ��̏�ɕ��������.
        }
       
    }

    void Respawn()//�A�C�e���{�b�N�X�����p�֐�.
    {
        Instantiate(SetBox_particle, this.transform.position, Quaternion.identity); //�p�[�e�B�N���𐶐�.
        this.gameObject.SetActive(true);
    }
}
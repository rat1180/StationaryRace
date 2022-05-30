using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ITEMConst;

public class GMSystem : MonoBehaviour
{
    /**************
     �Q�[���i�s�ϐ�
    ***************/

    //0:��~��� 1:�X�^�[�g�O 2:���[�X�� 3:���[�X�� 
    private int GameFlg;

    //�����N�z��(���͈��)
    private int[] Rank;

    //�R�[�X�ԍ�
    private int CoseNm;

    private int CPmax;

    /**************
     ���[�U�[�n�ϐ�
    ***************/

    //1���[�U�[�Ɋ��蓖�Ă���
    public struct USERINF
    {
        public GameObject USER;
        public int USERNm;
        public double CPTime;
        public int CPcnt;
        public int Rap;
    }

    //���[�U�[�z��i�ʐM�`�Ԃɂ���Ă͕ύX�j
    //USERINF[] Users;
    private USERINF User;

    //���[�U�[�l���i�ʐM�`�Ԃɂ���Ă͕ύX�j
    private int Players;

    /***************
     �A�C�e���n�ϐ�
    ****************/

    //�A�C�e���}�l�[�W���[
    private GameObject ItemManager;

    // Start is called before the first frame update
    void Start()
    {
        InitSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**************
     �N��������
    ***************/

    //���[�U�[�Ȃǂ̃Z�b�g
    public void InitSet()
    {
        //���[�X�O�̃V�[��������炤
        Players = 1;
        CoseNm = 0;

        //�X�^�[�g�O����
        GameFlg = 1;
        CPSet();

        //�����N�p�ϐ��̐���
        Rank = new int[Players];
        for(int i = 0; i < Players; i++)
        {
            Rank[i] = i;
        }

        //���[�U�[(�l�����J��Ԃ�)
        User.USER = transform.Find("User").gameObject;
        User.USERNm = 0;
        User.CPcnt = 0;
        User.CPTime = 0;
        User.Rap = 1;
        NmSend();
        User.USER.GetComponent<UserOperation>().RankSet();



        //�A�C�e��
        //ItemManager = transform.Find("ItemManager").gameObject;
    }

    //���[�X�X�^�[�g

    /// <summary>
    /// �`�F�b�N�|�C���g����U��
    /// �R�[�X��ς���Ƃ��͑���CP���X�g���폜���邱�ƁI�I
    /// </summary>
    void CPSet()
    {
        GameObject CPtmp;
        for (CPmax = 0;CPmax < this.transform.Find("CPList").childCount; CPmax++)
        {
            CPtmp = this.transform.Find("CPList").GetComponent<Transform>().transform.GetChild(CPmax).gameObject;
            CPtmp.GetComponent<CheckPoint>().CPset(CPmax);
        }
    }

    /***********
     ���[�U�[�n
    ************/

    /// <summary>
    /// ���[�U�[�ԍ���n��
    /// </summary>
    private void NmSend()
    {
        int Er = User.USER.GetComponent<UserOperation>().InitUser(User.USERNm,CPmax - 1);
        if(Er != 0)
        {
            GameFlg = 0;
        }
    }

    //���[�U�[�ԍ��ɉ��������ʂ�Ԃ�
    public int RankGet(int Nm)
    {
        for (int i = 0; i < Players; i++)
        {
            if (Rank[i] == Nm)
            {
                return i + 1;
            }
        }

        //�G���[
        return -1;
    }

    //���ʔ���


}

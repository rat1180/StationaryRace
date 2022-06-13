using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ITEMConst;

public class GMSystem : MonoBehaviour
{
    #region �ϐ��錾
    /*************
     ��`�p
    ***************/
    const int TRUE = 1;
    const int FALSE = 0;

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

    private int Rapmax;

    //���Ԍv���p�ϐ�
    public double RaceTime;
    private int TimerFlg;

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
    public USERTIME[] Users;
    private USERINF User;

    //���[�U�[�l���i�ʐM�`�Ԃɂ���Ă͕ύX�j
    private int Players;

    //�����[�U�[�Ƃ̒ʐM�p�Ɉ����\����
    public struct USERTIME
    {
        public double CPTime;
        public int CPcnt;
        public int Rap;
        public int UserNm;
    }

    /***************
     �A�C�e���n�ϐ�
    ****************/

    //�A�C�e���}�l�[�W���[
    private GameObject ItemManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InitSet();
        StartRace();
        //Invoke("CarSpawn", 5);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    #region �N��������
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
        Rapmax = 1;
        CPSet();

        //�����N�p�ϐ��Ƒ����[�U�[�p�z��̐���
        Rank = new int[Players];
        Users = new USERTIME[Players];
        for(int i = 0; i < Players; i++)
        {
            Rank[i] = i;
            if (i != User.USERNm)
            {
                Users[i].UserNm = i;
            }
            else
            {
                //�����̈ʒu�Ȃ̂ŏ�����Ȃ�
                Users[i].UserNm = -1;
            }
        }

        //���[�U�[(����)
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
    public void StartRace()
    {
        GameFlg = 2;
        RaceTime = 0;
        TimerFlg = TRUE;
    }

    /// <summary>
    /// �Q�[���J�n���Ɉړ�������
    /// </summary>
    public void CarSpawn()
    {
        GameObject SPlist = this.transform.Find("SpawnList").gameObject;
        Vector3 SP = SPlist.transform.GetChild(User.USERNm).gameObject.GetComponent<Transform>().position;
        User.USER.GetComponent<UserOperation>().SPCar(SP);
    }

    /// <summary>
    /// �`�F�b�N�|�C���g����U��
    /// �R�[�X��ς���Ƃ��͑���CP���X�g���폜or�e�q����O�����ƁI�I
    /// </summary>
    void CPSet()
    {
        GameObject CPtmp;
        GameObject CPlist = this.transform.Find("CPList").gameObject;
        for (CPmax = 0;CPmax < CPlist.transform.childCount; CPmax++)
        {
            CPtmp = CPlist.transform.GetChild(CPmax).gameObject;
            CPtmp.GetComponent<CheckPoint>().CPset(CPmax);
        }
    }

    #endregion

    #region ���[�U�[�n����

    /***********
     ���[�U�[�n
    ************/

    /// <summary>
    /// ���[�U�[�ԍ���n��
    /// </summary>
    private void NmSend()
    {
        int Er = User.USER.GetComponent<UserOperation>().InitUser(User.USERNm, CPmax - 1, Rapmax) ;
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

    //CP�ʉ߂ɂ�鏈��(�����[�U�[����̏�񂾂������)
    public void CPpass(USERTIME rUSER)
    {
        for(int i = 0; i < Players; i++)
        {
            if(Users[i].UserNm == rUSER.UserNm)
            {
                Users[i] = rUSER;
            }
        }
    }

    //�������ʉ߂����Ƃ��ɌĂяo���i�ʉ߂Ɠ����j
    public void MyCPpass(int MyCPcnt,int MyRap)
    {
        User.CPTime = TimeGet();
        User.CPcnt = MyCPcnt;
        User.Rap = MyRap;

        if(MyRap == Rapmax)
        {
            Debug.Log("�S�[���^�C��:" + (User.CPTime).ToString("lf.3"));
        }
    }

    //���ʔ���

    #endregion

    /************
     �V�X�e���n
    *************/

    //���Ԃ��v������
    private void Timer()
    {
        if(TimerFlg == TRUE)
        {
            RaceTime += Time.deltaTime;
        }
    }

    //�o�ߎ��Ԃ�Ԃ�
    public double TimeGet()
    {
        return RaceTime;
    }

}

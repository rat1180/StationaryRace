using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ITEMConst;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;

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

    //�R�[�X�ԍ�
    private int CoseNm;

    private int CPmax;

    private int Rapmax;

    //���Ԍv���p�ϐ�
    public double RaceTime;
    private bool TimerFlg;

    //�Q�[���I���
    public GameObject GAMEOVER;

    
    GameObject CPlist;

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
        public int Rank;
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

    //�����[�U�[�̏��̕ۑ���
    public GameObject SystemINF = null;
    public GameObject SystemINF_POP;

    /***************
     �A�C�e���n�ϐ�
    ****************/

    //�A�C�e���}�l�[�W���[
    private GameObject ItemManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //�������ɋN��
        //InitSet();
        
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
        Players = 3; //4-1
        CoseNm = 0;

        //�X�^�[�g�O����
        GameFlg = 1;
        Rapmax = 1;
        CPlist = this.transform.Find("CPList").gameObject;
        CPSet();


        //���[�U�[(����)
        User.USER = transform.Find("User").gameObject;
        User.USERNm = USERnmGet();
        Debug.Log(User.USERNm);
        User.CPcnt = 0;
        User.CPTime = 0;
        User.Rap = 3;
        User.Rank = 1;
        NmSend();
        //User.USER.GetComponent<UserOperation>().RankSet();

        //�����N�p�ϐ��Ƒ����[�U�[�p�z��̐���
        //�����菇�ɂ���ďꏊ��ς���
        Users = new USERTIME[Players];

        //�A�C�e��
        //ItemManager = transform.Find("ItemManager").gameObject;

        //GAMEOVER = GameObject.Find("TimeText");
        //GAMEOVER.SetActive(false);
    }

    //���[�X�X�^�[�g
    public void StartRace()
    {
        GameFlg = 2;
        RaceTime = 0;
        TimerFlg = true;
    }

    /// <summary>
    /// �Q�[���J�n���Ɉړ�������
    /// </summary>
    public void CarSpawn()
    {
        
        GameObject SPlist = this.transform.Find("SpawnList").gameObject;
        Vector3 SPp = SPlist.transform.GetChild(User.USERNm).gameObject.GetComponent<Transform>().position;
        Quaternion SPr = SPlist.transform.GetChild(User.USERNm).gameObject.GetComponent<Transform>().rotation;
        User.USER.GetComponent<UserOperation>().SPCar(SPp, SPr);
    }

    /// <summary>
    /// �`�F�b�N�|�C���g����U��
    /// �R�[�X��ς���Ƃ��͑���CP���X�g���폜or�e�q����O�����ƁI�I
    /// </summary>
    void CPSet()
    {
        GameObject CPtmp;
        for (CPmax = 0; CPmax < CPlist.transform.childCount; CPmax++)
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
        int Er = User.USER.GetComponent<UserOperation>().InitUser(User.USERNm, CPmax - 1, Rapmax);
        if (Er != 0)
        {
            GameFlg = 0;
        }
    }

    //���[�U�[�ԍ��ɉ��������ʂ�Ԃ�
    public int RankGet()
    {
        if(User.Rank >= 1 || User.Rank <= 4)
        {
            return User.Rank;
        }

        //�G���[
        return -1;
    }

    //CP�ʉ߂ɂ�鏈��(�����[�U�[����̏�񂾂������)
    public void CPpass(int rUSERNm, double rUSERTime, int rUSERCPcnt, int rUSERRap)
    {
        if (rUSERNm != User.USERNm)
        {
            for (int i = 0; i < Players; i++)
            {
                if (Users[i].UserNm == rUSERNm)
                {
                    Users[i].CPTime = rUSERTime;
                    Users[i].CPcnt = rUSERCPcnt;
                    Users[i].Rap = rUSERRap;
                }
            }
        }
        Ranking();
    }

    //�������ʉ߂����Ƃ��ɌĂяo���i�ʉ߂Ɠ����j
    public void MyCPpass(int MyCPcnt, int MyRap)
    {
        User.CPTime = TimeGet();
        CPlist.transform.GetChild(User.CPcnt).gameObject.GetComponent<MeshRenderer>().enabled = false;
        User.CPcnt = MyCPcnt;
        CPlist.transform.GetChild(User.CPcnt + 1).gameObject.GetComponent<MeshRenderer>().enabled = true;
        User.Rap = MyRap;

        if (MyRap == Rapmax)
        {
            TimerFlg = false;
            Debug.Log("�S�[���^�C��:" + (User.CPTime).ToString("f3"));
            GAMEOVER.SetActive(true);
            string str1 = "�S�[��!!" + (User.CPTime).ToString("f3");
            string str2 = "\n����" + User.Rank;
            GAMEOVER.GetComponent<Text>().text = str1 + str2;
            //GAMEOVER.GetComponent<Result>().Decide_Timer(User.CPTime);
        }

        SystemINF.GetComponent<SystemINF>().USERCP(User.USERNm, User.CPTime, User.CPcnt, User.Rap);
    }

    //���ʔ���
    public void Ranking()
    {
        User.Rank = 1;
        for (int j = 0; j < Players; j++)
        {
            if(User.Rap < Users[j].Rap)
            {
                User.Rank++;
            }
            else if(User.CPcnt < Users[j].CPcnt)
            {
                User.Rank++;
            }
            else if(User.CPTime < Users[j].CPTime)
            {
                User.Rank++;
            }

        }
    } 

    #endregion

    /************
     �V�X�e���n
    *************/

    //���Ԃ��v������
    private void Timer()
    {
        if(TimerFlg == true)
        {
            RaceTime += Time.deltaTime;
        }
    }

    //�o�ߎ��Ԃ�Ԃ�
    public double TimeGet()
    {
        return RaceTime;
    }

    //�ԍ��̎擾
    public int USERnmGet()
    {
        //�����[�U�[���̊m�F
        SystemINF = GameObject.Find("SystemINF(Clone)");

        //���[���I�[�i�[�ؖ�
        if (SystemINF == null)
        {
            //�I�[�i�[�̂ݐ���
            SystemINF = Instantiate(SystemINF_POP);
            SystemINF.GetComponent<SystemINF>().USERcntRESET();
            Debug.Log("����");
        }

        int Usernm = SystemINF.GetComponent<SystemINF>().USERcntSET(1);
        return Usernm;
    }

    //�Q�����邽�я�������
    public void PlayerJoin()
    {
        int Usernm = SystemINF.GetComponent<SystemINF>().USERcntSET(0);
        if (Usernm == User.USERNm) return;
        for(int i = 0; i < Players; i++)
        {
            if(Users[i].UserNm == null)
            {
                Users[i].UserNm = Usernm;
                break;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjUpAudio : MonoBehaviour
{
    public AudioSource a;   //AudioSource�^�̕ϐ�a��錾 �g�p����AudioSource�R���|�[�l���g���A�^�b�`�K�v

    //AudioClip�^�̕ϐ���錾 �g�p����AudioClip���A�^�b�`�K�v
    public AudioClip Impact;

    public LastShortCut LSC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LSC.BreakFlg == true)
        {
            a.PlayOneShot(Impact); // ���ʉ���炷
            Invoke("DeleteMs", 8);
        }
    }
    void DeleteMs()
    {
        Destroy(this.gameObject);
    }
}

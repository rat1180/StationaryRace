using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjUpAudio : MonoBehaviour
{
    public AudioSource a;   //AudioSource型の変数aを宣言 使用するAudioSourceコンポーネントをアタッチ必要

    //AudioClip型の変数を宣言 使用するAudioClipをアタッチ必要
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
            a.PlayOneShot(Impact); // 効果音を鳴らす
            Invoke("DeleteMs", 8);
        }
    }
    void DeleteMs()
    {
        Destroy(this.gameObject);
    }
}

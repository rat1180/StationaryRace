using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBt : MonoBehaviour
{
    public AudioClip Push; // 効果音
    AudioSource audioSource;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
	}
    public void ReturnPushBt()
    {
        Invoke("SceneTrip", 2);
        audioSource.PlayOneShot(Push); // 効果音を鳴らす
    }
    public void SceneTrip()
    {
        //現在のシーンのインデックス番号を取得
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++nowSceneIndexNumber);
    }
}

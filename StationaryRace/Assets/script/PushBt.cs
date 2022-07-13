using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBt : MonoBehaviour
{
    public AudioClip Push; // ���ʉ�
    AudioSource audioSource;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
	}
    public void ReturnPushBt()
    {
        Invoke("SceneTrip", 2);
        audioSource.PlayOneShot(Push); // ���ʉ���炷
    }
    public void SceneTrip()
    {
        //���݂̃V�[���̃C���f�b�N�X�ԍ����擾
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++nowSceneIndexNumber);
    }
}

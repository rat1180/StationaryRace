using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBt : MonoBehaviour
{
    public AudioClip Push; // Œø‰Ê‰¹
    AudioSource audioSource;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
	}
    public void ReturnPushBt()
    {
        Invoke("SceneTrip", 2);
        audioSource.PlayOneShot(Push); // Œø‰Ê‰¹‚ð–Â‚ç‚·
    }
    public void SceneTrip()
    {
        SceneManager.LoadScene("stage");
    }
}

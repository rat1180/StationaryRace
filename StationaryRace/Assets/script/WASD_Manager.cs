using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Manager : MonoBehaviour
{
	public GameObject W_key;
	public GameObject A_key;
	public GameObject S_key;
	public GameObject D_key;
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		W_key.SetActive(false);
		A_key.SetActive(false);
		S_key.SetActive(false);
		D_key.SetActive(false);
		// ÉLÅ[à⁄ìÆ
		if (Input.GetKey(KeyCode.W))
		{
			W_key.SetActive(true);
		}
		if (Input.GetKey(KeyCode.S))
		{
			S_key.SetActive(true);
		}
		if (Input.GetKey(KeyCode.D))
		{
			D_key.SetActive(true);
		}
		if (Input.GetKey(KeyCode.A))
		{
			A_key.SetActive(true);
		}
	}
}

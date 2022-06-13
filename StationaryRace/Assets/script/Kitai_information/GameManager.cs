using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Inoperable(float i)
    {
        GameObject inputObj = GameObject.Find("InputManager");
        MainKitai mainKitai = inputObj.GetComponent<MainKitai>();
        mainKitai.enabled = false; // �X�N���v�g�𖳌���
        yield return new WaitForSeconds(i); // �����̕b�������҂�
        mainKitai.enabled = true; // �X�N���v�g��L����
        yield break;
    }

    public void CallInoperable(float i)
    {
        StartCoroutine("Inoperable", i); // ���̃X�N���v�g����Ăяo���p
    }
}

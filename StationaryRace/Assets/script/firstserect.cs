using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstserect : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Canvas/Button").GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick()
    {
        Debug.Log("�����ꂽ!");  // ���O���o��
    }
}

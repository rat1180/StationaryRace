using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SoftGear.Strix.Unity.Runtime;

public class TextController : StrixBehaviour
{
    public TextMeshPro nameText;
    public string PName; //���O�̓���

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        if (isLocal)
        {
            PName = PushBt.PlayerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerName();
        transform.LookAt(Camera.main.transform);  // Camera�ɍ��킹��Name�e�L�X�g����]
    }

    public void PlayerName()
    {
        nameText.text = PName; //���O�̕\��
    }
}

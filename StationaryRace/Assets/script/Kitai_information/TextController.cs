using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SoftGear.Strix.Unity.Runtime;

public class TextController : StrixBehaviour
{
    public TextMeshPro nameText;
    [StrixSyncField]
    public string PName; //���O�̓���

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(-1, 1, 1);
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
    
    public void waitConect()
    {
        if (isLocal)
        {
            PName = StrixNetwork.instance.selfRoomMember.GetName();
            if(PName == "")
            {
                PName = "Player";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SoftGear.Strix.Unity.Runtime;

public class TextController : StrixBehaviour
{
    public TextMeshPro nameText;
    public string PName; //名前の入力

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
        transform.LookAt(Camera.main.transform);  // Cameraに合わせてNameテキストを回転
    }

    public void PlayerName()
    {
        nameText.text = PName; //名前の表示
    }
}

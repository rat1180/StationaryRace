using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshPro nameText;
    private string PName = "siitake"; //–¼‘O‚Ì“ü—Í

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerName();
        transform.LookAt(Camera.main.transform);
    }

    public void PlayerName()
    {
        nameText.text = PName; //–¼‘O‚Ì•\Ž¦
    }
}

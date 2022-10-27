using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SoftGear.Strix.Unity.Runtime;

public class TextController : MonoBehaviour
{
    public TextMeshPro nameText;
    public string PName; //名前の入力

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {


        NameGet();
        PlayerName();
        
            
        transform.LookAt(Camera.main.transform);  // Cameraに合わせてNameテキストを回転
    }

    public void PlayerName()
    {
        nameText.text = PName; //名前の表示
    }
    
    public void NameGet()
    {
        GameObject Car = transform.parent.transform.parent.transform.parent.gameObject;
        PName = Car.GetComponent<Car>().Name;
        if (PName == "")
        {
            PName = "Player";
        }
    }
}

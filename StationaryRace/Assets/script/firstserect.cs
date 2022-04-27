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
        //ボタンが選択された状態になる
        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
    }
}

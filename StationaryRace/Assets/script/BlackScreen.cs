using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    Image fadealpha;               //フェードパネルのイメージ取得変数
    public Text ChttText;
    private float alpha;           //パネルのalpha値取得変数

    private bool fadeout;          //フェードアウトのフラグ変数

    // Start is called before the first frame update
    void Start()
    {
        fadealpha = GetComponent<Image>();          //パネルのイメージ取得
       

        alpha = fadealpha.color.a;                  //パネルのalpha値を取得
        fadeout = true;                             //シーン読み込み時にフェードインさせる
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            FadeOut();
            
        }
    }
    void FadeOut()
    {
        alpha += 0.001f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        
        if (alpha >= 0.8)
        {
            fadeout = false;
            Invoke("FlagOn", 2);
        }
    }
    void FlagOn()
    {
        Destroy(this.gameObject);
        Destroy(ChttText);
    }
}

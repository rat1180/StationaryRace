using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    public Text ChttText;
    private float alpha;           //�p�l����alpha�l�擾�ϐ�

    private bool fadeout;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        fadealpha = GetComponent<Image>();          //�p�l���̃C���[�W�擾
       

        alpha = fadealpha.color.a;                  //�p�l����alpha�l���擾
        fadeout = true;                             //�V�[���ǂݍ��ݎ��Ƀt�F�[�h�C��������
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

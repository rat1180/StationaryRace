using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class titletenmetu : MonoBehaviour
{
    private float num = Mathf.PI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * TextMeshPro�̋@�\���g�����߂�TextMeshProUGUI���I�u�W�F�N�g�������Ă���
         */
        TextMeshProUGUI tmPro = gameObject.GetComponent<TextMeshProUGUI>();
        Material material = tmPro.fontMaterial;
        /*
         *----------------------------------------------------------- 
         * Outline��Thickness�̐��l��0�`0.4�ɕω�����悤�ɐݒ�
         * ���l�̕ω��͎O�p�֐���Sin�𗘗p
         * ���l�����̒l�ɂȂ�Ƃ��������Ȃ�̂ŁA��Βl��ݒ�
         *-----------------------------------------------------------
         */
        material.SetFloat("_OutlineWidth", Mathf.Abs(Mathf.Sin(num)) * 2 / 5);
        num += Time.deltaTime * 2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;//UI���g���Ƃ��ǉ�

public class INDIA_INK : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("FadeOut", 5);
    }
    //�t�F�[�h�A�E�g
    void FaedOut()
    {

    }
}

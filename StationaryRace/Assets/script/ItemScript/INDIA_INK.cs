using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

using UnityEngine.UI;//UIを使うとき追加

public class INDIA_INK : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //フェードイン
    public void Animation()
    {
        
        animator.SetTrigger("FadeIn");
    }
}

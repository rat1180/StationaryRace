using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Inoperable(float i)
    {
        GameObject inputObj = GameObject.Find("InputManager");
        MainKitai mainKitai = inputObj.GetComponent<MainKitai>();
        mainKitai.enabled = false; // スクリプトを無効化
        yield return new WaitForSeconds(i); // 引数の秒数だけ待つ
        mainKitai.enabled = true; // スクリプトを有効化
        yield break;
    }

    public void CallInoperable(float i)
    {
        StartCoroutine("Inoperable", i); // 他のスクリプトから呼び出す用
    }
}

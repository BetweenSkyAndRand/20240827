using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scean : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //マウスがクリックされたときに画面が戦死する（シーンが遷移される）
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

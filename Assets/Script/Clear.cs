using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scean : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //�}�E�X���N���b�N���ꂽ�Ƃ��ɉ�ʂ��펀����i�V�[�����J�ڂ����j
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

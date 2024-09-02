using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerContoroller : MonoBehaviour
{
    //�d��
    Rigidbody2D rigidbody2D;
    //�W�����v����Ƃ��̗�
    float jumpForce = 500.0f;
    //�������̗�
    float walkForce = 30.0f;
    float MaxWaklSpead=2.0f;
    //�A�j���[�V����
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //�t���[���J�E���g
        Application.targetFrameRate = 60;
        //Rigidbody���R���|�[�l���g
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v����
        if(Input.GetKeyDown(KeyCode.Space)&&this.rigidbody2D.velocity.y==0)
        {
            //�A�j���[�V�����ύX
            this.animator.SetTrigger("JumpTrriger");
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
        }
        int key = 0;
        //���E�Ɉړ�
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = 1;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = -1;
        }
        //�v���C���[���x
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);
        //�X�s�[�h����
        if(speedx<this.MaxWaklSpead)
        {
            this.rigidbody2D.AddForce(transform.right * key * this.walkForce);
        }
        //���������Ŕ��]������
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if(this.transform.position.y==0)
        {
        this.animator.speed = speedx / 0.75f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        if (transform.position.y<-10||transform.position.x<-3||transform.position.x>3)
        {
            SceneManager.LoadScene("GameScene");
        }
        //��ʏ�ɏo�Ȃ��悤�ɂ���
        else if(transform.position.y>25)
        {
            this.transform.position = new Vector3(transform.position.x, 17, transform.position.z);
        }
        //if(transform.position.x==)

    }
    //�S�[���ɓ��B
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Goal");
        SceneManager.LoadScene("GameClear");
    }
}

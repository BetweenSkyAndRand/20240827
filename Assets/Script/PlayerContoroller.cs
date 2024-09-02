using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerContoroller : MonoBehaviour
{
    //重力
    Rigidbody2D rigidbody2D;
    //ジャンプするときの力
    float jumpForce = 500.0f;
    //歩く時の力
    float walkForce = 30.0f;
    float MaxWaklSpead=2.0f;
    //アニメーション
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //フレームカウント
        Application.targetFrameRate = 60;
        //Rigidbodyをコンポーネント
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプする
        if(Input.GetKeyDown(KeyCode.Space)&&this.rigidbody2D.velocity.y==0)
        {
            //アニメーション変更
            this.animator.SetTrigger("JumpTrriger");
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
        }
        int key = 0;
        //左右に移動
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = 1;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = -1;
        }
        //プレイヤー速度
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);
        //スピード制限
        if(speedx<this.MaxWaklSpead)
        {
            this.rigidbody2D.AddForce(transform.right * key * this.walkForce);
        }
        //動く方向で反転させる
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
        //画面上に出ないようにする
        else if(transform.position.y>25)
        {
            this.transform.position = new Vector3(transform.position.x, 17, transform.position.z);
        }
        //if(transform.position.x==)

    }
    //ゴールに到達
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Goal");
        SceneManager.LoadScene("GameClear");
    }
}

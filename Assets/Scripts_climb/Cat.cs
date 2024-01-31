using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] float jumpForce = 500f;
    [SerializeField] float moveForce = 10f;
    [SerializeField] float speedLimit = 2.8f;
    [SerializeField] private GameDirector gameDirector;
    private bool isJumping=false;
    private void Start()
    {
        //GameDirector를 컴포넌트로 가져옴
        gameDirector = FindAnyObjectByType<GameDirector>(); 
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()//물리현상을 처리할 경우 Update대신 써야함
    {
        //점프상태일때는 키입력을 막음
        if (isJumping) return;        
        //점프 구현
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);//로컬좌표
            isJumping = true;
            //rb.AddForce(Vector3.up * force);//월드좌표
        }

        float dirX = 0;//기준점(좌표)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            transform.localScale = new Vector3(dirX, 1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            transform.localScale = new Vector3(dirX, 1, 1);
        }
        //Debug.Log(dir);
        //화면 밖으로 나가지 않도록 제한
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.6f, 2.6f),
            transform.position.y, transform.position.z);

        //속도제한
        if (Mathf.Abs(rb.velocity.x) > speedLimit) return;

        //속도에 따른 이동
        rb.AddForce(transform.right * dirX * moveForce);

        //이동속도에 따라서 애니메이션 반영
        anim.speed = Mathf.Abs(rb.velocity.x / 2);
        //Animator의 speed프로퍼티는 음수면 안된다

        //텍스트로 출력
        gameDirector.UpdateVelocityText(rb.velocity);
        Debug.Log(isJumping);
    }

    //충돌(통과)판정 - istrigger 켜짐
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision + "의 콜라이더와 충돌시작");
        //장면전환
        SceneManager.LoadScene("ClimbCloudClear");//이름으로 로드
        //SceneManager.LoadScene(1);//빌드번호로 로드
    }
    //바닥과의 충돌 판정
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//점프상태해제        
    }
    //tree이진트리 - 이진탐색 트리 구현 
}

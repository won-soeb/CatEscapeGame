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
    private GameDirector gameDirector;
    private bool isJumping = false;//점프여부
    private void Awake()
    {
        //Cat(자신)의 다른 컴포넌트를 가져온다.
        rb = GetComponent<Rigidbody2D>();//Rigidbody2D컴포넌트를 가져옴
        anim = GetComponent<Animator>();//Animator컴포넌트를 가져옴
    }
    private void Start()
    {
        //GameDirector를 컴포넌트로 가져옴
        gameDirector = FindAnyObjectByType<GameDirector>();
        //왜 이 코드를 Start로 분리했는가?
        //유니티는 게임오브젝트가 인스턴스화 된 직후 Awake를 호출한다(유니티 라이프 사이클참고)
        //문제는 각 인스턴스들의 생성과 Awake의 호출순서를 알 수 없다는 것이다.
        //그래서 자신이 아닌 외부의 컴포넌트를 Awake단계에서 찾으려 하면 찾으려는 컴포넌트의 인스턴스가 만들어지지 않았을 경우.
        //nullReferenceException이 발생할 수 있다.
        //따라서 모든 Awake의 호출이 끝난 뒤 '모든 인스턴스의 생성'을 보장하는 Start로 분리한 것이다.
    }
    private void FixedUpdate()//물리현상을 처리할 경우 Update대신 써야함
    {
        //점프상태일때는 키입력을 막음
        if (isJumping) return;
        //점프 구현
        if (Input.GetKey(KeyCode.Space))
        //GetKeyDown은 제대로 동작하지 않는다!!
        //GetKeyDown은 한번만 호출되는 특성상 시간마다 일정하게 호출되는 FixedUpdate보다 우선순위가 낮아 호출을 무시당할수 있다.
        {
            rb.AddForce(transform.up * jumpForce);//로컬좌표
            //rb.AddForce(Vector3.up * moveForce);//월드좌표
            isJumping = true;//점프상태 활성화
            anim.SetBool("Jump", isJumping);//점프 애니메이션 재생
        }

        float dirX = 0;//기준점(좌표)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            transform.localScale = new Vector3(dirX, 1, 1);//캐릭터 이미지를 뒤집는다
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
    }

    //충돌(통과)판정 - istrigger 켜짐
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //장면전환
        SceneManager.LoadScene("ClimbCloudClear");//이름으로 로드
        //SceneManager.LoadScene(1);//씬 빌드 번호로 로드
    }
    //바닥과의 충돌 판정
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//점프상태해제
        anim.SetBool("Jump", isJumping);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float jumpForce = 500f;
    [SerializeField] float moveForce = 10f;
    [SerializeField] private GameDirector gameDirector;
    private void Start()
    {
        //GameDirector를 컴포넌트로 가져옴
        gameDirector = FindAnyObjectByType<GameDirector>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()//물리현상을 처리할 경우 Update대신 써야함
    {
        //점프 구현
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);//로컬좌표
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

        //속도제한
        if (Mathf.Abs(rb.velocity.x) < 2.8f)
        {
            rb.AddForce(transform.right * dirX * moveForce);
        }
        
        gameDirector.UpdateVelocityText(rb.velocity);//텍스트로 출력
    }
}

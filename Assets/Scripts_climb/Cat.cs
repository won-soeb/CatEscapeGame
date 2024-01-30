using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float force = 500f;
    [SerializeField] float speed = 0.01f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()//물리현상을 처리할 경우 Update대신 써야함
    {
        //점프 구현
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force);//로컬좌표
            //rb.AddForce(Vector3.up * force);//월드좌표
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * force);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * force);
        }
    }
}

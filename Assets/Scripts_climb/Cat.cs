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
    void FixedUpdate()//���������� ó���� ��� Update��� �����
    {
        //���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force);//������ǥ
            //rb.AddForce(Vector3.up * force);//������ǥ
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

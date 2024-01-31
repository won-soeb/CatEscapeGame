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
        //GameDirector�� ������Ʈ�� ������
        gameDirector = FindAnyObjectByType<GameDirector>(); 
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()//���������� ó���� ��� Update��� �����
    {
        //���������϶��� Ű�Է��� ����
        if (isJumping) return;        
        //���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);//������ǥ
            isJumping = true;
            //rb.AddForce(Vector3.up * force);//������ǥ
        }

        float dirX = 0;//������(��ǥ)
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
        //ȭ�� ������ ������ �ʵ��� ����
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.6f, 2.6f),
            transform.position.y, transform.position.z);

        //�ӵ�����
        if (Mathf.Abs(rb.velocity.x) > speedLimit) return;

        //�ӵ��� ���� �̵�
        rb.AddForce(transform.right * dirX * moveForce);

        //�̵��ӵ��� ���� �ִϸ��̼� �ݿ�
        anim.speed = Mathf.Abs(rb.velocity.x / 2);
        //Animator�� speed������Ƽ�� ������ �ȵȴ�

        //�ؽ�Ʈ�� ���
        gameDirector.UpdateVelocityText(rb.velocity);
        Debug.Log(isJumping);
    }

    //�浹(���)���� - istrigger ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision + "�� �ݶ��̴��� �浹����");
        //�����ȯ
        SceneManager.LoadScene("ClimbCloudClear");//�̸����� �ε�
        //SceneManager.LoadScene(1);//�����ȣ�� �ε�
    }
    //�ٴڰ��� �浹 ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//������������        
    }
    //tree����Ʈ�� - ����Ž�� Ʈ�� ���� 
}

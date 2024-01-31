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
    private bool isJumping = false;//��������
    private void Awake()
    {
        //Cat(�ڽ�)�� �ٸ� ������Ʈ�� �����´�.
        rb = GetComponent<Rigidbody2D>();//Rigidbody2D������Ʈ�� ������
        anim = GetComponent<Animator>();//Animator������Ʈ�� ������
    }
    private void Start()
    {
        //GameDirector�� ������Ʈ�� ������
        gameDirector = FindAnyObjectByType<GameDirector>();
        //�� �� �ڵ带 Start�� �и��ߴ°�?
        //����Ƽ�� ���ӿ�����Ʈ�� �ν��Ͻ�ȭ �� ���� Awake�� ȣ���Ѵ�(����Ƽ ������ ����Ŭ����)
        //������ �� �ν��Ͻ����� ������ Awake�� ȣ������� �� �� ���ٴ� ���̴�.
        //�׷��� �ڽ��� �ƴ� �ܺ��� ������Ʈ�� Awake�ܰ迡�� ã���� �ϸ� ã������ ������Ʈ�� �ν��Ͻ��� ��������� �ʾ��� ���.
        //nullReferenceException�� �߻��� �� �ִ�.
        //���� ��� Awake�� ȣ���� ���� �� '��� �ν��Ͻ��� ����'�� �����ϴ� Start�� �и��� ���̴�.
    }
    private void FixedUpdate()//���������� ó���� ��� Update��� �����
    {
        //���������϶��� Ű�Է��� ����
        if (isJumping) return;
        //���� ����
        if (Input.GetKey(KeyCode.Space))
        //GetKeyDown�� ����� �������� �ʴ´�!!
        //GetKeyDown�� �ѹ��� ȣ��Ǵ� Ư���� �ð����� �����ϰ� ȣ��Ǵ� FixedUpdate���� �켱������ ���� ȣ���� ���ô��Ҽ� �ִ�.
        {
            rb.AddForce(transform.up * jumpForce);//������ǥ
            //rb.AddForce(Vector3.up * moveForce);//������ǥ
            isJumping = true;//�������� Ȱ��ȭ
            anim.SetBool("Jump", isJumping);//���� �ִϸ��̼� ���
        }

        float dirX = 0;//������(��ǥ)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            transform.localScale = new Vector3(dirX, 1, 1);//ĳ���� �̹����� �����´�
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
    }

    //�浹(���)���� - istrigger ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�����ȯ
        SceneManager.LoadScene("ClimbCloudClear");//�̸����� �ε�
        //SceneManager.LoadScene(1);//�� ���� ��ȣ�� �ε�
    }
    //�ٴڰ��� �浹 ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//������������
        anim.SetBool("Jump", isJumping);
    }
}

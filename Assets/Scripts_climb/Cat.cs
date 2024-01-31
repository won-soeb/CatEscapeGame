using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] float jumpForce = 500f;
    [SerializeField] float moveForce = 10f;
    [SerializeField] float speedLimit = 2.8f;
    [SerializeField] private GameDirector gameDirector;
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
        //���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);//������ǥ
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

        //�ӵ�����
        if (Mathf.Abs(rb.velocity.x) > speedLimit) return;
        
        //�ӵ��� ���� �̵�
        rb.AddForce(transform.right * dirX * moveForce);
        
        //�̵��ӵ��� ���� �ִϸ��̼� �ݿ�
        anim.speed = Mathf.Abs(rb.velocity.x);
        //Animator�� speed������Ƽ�� ������ �ȵȴ�
        
        //�ؽ�Ʈ�� ���
        gameDirector.UpdateVelocityText(rb.velocity);
    }
}

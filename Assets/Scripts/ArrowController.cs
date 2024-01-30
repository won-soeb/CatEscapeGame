using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float downSpeed = 15f;
    [SerializeField] private float radius = 1f;
    //�������� �����Ǵ� ������Ʈ�� �����Ҵ��� ����
    [SerializeField] private GameManager gameManager;

    private GameObject playerGo;

    private void Start()
    {
        playerGo = GameObject.Find("player");//������Ʈ �̸����� ã��
        gameManager = FindAnyObjectByType<GameManager>();//������Ʈ �̸����� ã��
    }
    void Update()
    {
        //�浹ó�� ����(������ OnXXX~�޼ҵ��� ������� �ʴ´�)
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        Vector2 p1 = transform.position;
        Vector2 p2 = playerGo.transform.position;
        Vector2 dir = p1 - p2;
        float distance = dir.magnitude;//�Ÿ�(������ ũ��)
        //float distance = Vector2.Distance(p1, p2);//�Ÿ��� ���� �Ŷ�� �̰͵� ����

        float r1 = radius;
        float r2 = playerGo.GetComponent<PlayerController>().radius;
        float sumR = r1 + r2;//ȭ��� �÷��̾��� �����(��)�� �׷� �������� ���̸� ���Ѵ�
        if (distance < sumR)//ȭ��� �÷��̾�� �Ÿ� < ȭ��� �÷��̾��� �����(��)�� �������� ��
        {
            Destroy(gameObject);
            //Debug.LogFormat("�浹: {0}, {1}", distance, sumR);
            gameManager.DecreaseHp();
        }

        if (transform.position.y < -3)
        {
            //Debug.LogError("�浹");//ȭ���� ����� �浹�ߴ��� Ȯ���Ѵ�
            Destroy(gameObject);//Arrow������Ʈ(ȭ��) �ı�
            //Destroy(this);//�̰� �ش� ������Ʈ(ArrowController)�� �������. Arrow������Ʈ�� �ı��Ǵ°� �ƴ� 
        }
    }
    //�̺�Ʈ �Լ�
    //private void OnDrawGizmos() //����� �׷��� radiusũ���� ���� Ȯ���غ���
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, radius);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    public float radius = 1;

    void Update()
    {
        if (GameManager.isGameOver)
            return;//���ӿ����Ǹ� Ű�Է� ����

        //Ű���� �Է��� �޴� �ڵ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("�����̵�");
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("�������̵�");
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        //�÷��̾� ĳ���Ͱ� ȭ�� ���� ����� �ʵ��� ��ġ�� �����Ѵ�.(x�� -8 ~ +8�̳��θ� ������ �� ����)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y, transform.position.z);
    }
    ////�̺�Ʈ �Լ�
    //private void OnDrawGizmos()//����� �׷��� radiusũ���� ���� Ȯ���غ���
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, radius);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOffset : MonoBehaviour
{
    public Cat target;//����ٴ� ���(�����)
    private float startPos;//������ų y��ǥ��
    private void Awake()
    {
        startPos = transform.position.y;//ī�޶� �ٴڽ����� ������Ų��.
    }
    void LateUpdate()
    {
        if (target.transform.position.y <= startPos)
        {
            //����̰� startPos�� ���� ������ ī�޶��� ������ �������� �ʴ´�
            transform.position = new Vector3(0, 1, -10);
        }
        else
        {
            //����̰� startPos�� �Ѿ�� ī�޶� ����̸� ����ٴѴ�
            transform.position = new Vector3(0, target.transform.position.y, -10);
        }
    }
}

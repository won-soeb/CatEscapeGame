using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOffset : MonoBehaviour
{
    public Cat target;
    public float startOffset = -0.2f;

    void LateUpdate()
    {
        if (target.transform.position.y <= transform.position.y)
        {
            //??ī�޶� �������� ����.���ǹ�-Ư�� ���� ���Ͽ��� �ٷ� �ʱ�ȭ�� �Ǵ� ����
            transform.position = new Vector3(0, 1, -10);
        }
        else
        {
            transform.position = new Vector3(0, target.transform.position.y + 1, -10);
        }
    }
}

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
            //??카메라 움직임이 끊김.조건문-특정 높이 이하에서 바로 초기화가 되는 문제
            transform.position = new Vector3(0, 1, -10);
        }
        else
        {
            transform.position = new Vector3(0, target.transform.position.y + 1, -10);
        }
    }
}

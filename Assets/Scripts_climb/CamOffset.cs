using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOffset : MonoBehaviour
{
    public Cat target;//따라다닐 대상(고양이)
    private float startPos;//고정시킬 y좌표값
    private void Awake()
    {
        startPos = transform.position.y;//카메라를 바닥시점에 고정시킨다.
    }
    void LateUpdate()
    {
        if (target.transform.position.y <= startPos)
        {
            //고양이가 startPos를 넘지 않으면 카메라의 시점을 움직이지 않는다
            transform.position = new Vector3(0, 1, -10);
        }
        else
        {
            //고양이가 startPos를 넘어가면 카메라가 고양이를 따라다닌다
            transform.position = new Vector3(0, target.transform.position.y, -10);
        }
    }
}

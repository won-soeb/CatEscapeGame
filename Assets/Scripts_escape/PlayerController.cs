using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Button LButton;
    [SerializeField] private Button RButton;
    [SerializeField] private float speed = 10;
    public float radius = 1;

    private void Start()
    {
        //버튼에 이벤트를 할당하는 다른 방법(유니티 에디터에서 버튼에 함수를 직접 넣지 않는 방법)
        LButton.onClick.AddListener(() => { Debug.Log("왼쪽버튼 클릭"); });
        RButton.onClick.AddListener(() => { Debug.Log("오른쪽버튼 클릭"); });
    }
    void Update()
    {
        if (GameManager.isGameOver)
            return;//게임오버되면 키입력 방지

        //키보드 입력을 받는 코드
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("왼쪽이동");
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("오른쪽이동");
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        //플레이어 캐릭터가 화면 밖을 벗어나지 않도록 위치를 제한한다.(x축 -8 ~ +8이내로만 움직일 수 있음)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y, transform.position.z);
    }
    ////이벤트 함수
    //private void OnDrawGizmos()//기즈모를 그려서 radius크기의 원을 확인해본다
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, radius);
    //}
    private void RButtonClick()
    {
        
    }

    private void LButtonClick()
    {

    }
}

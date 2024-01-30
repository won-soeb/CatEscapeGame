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
}

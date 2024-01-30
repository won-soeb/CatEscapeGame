using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float downSpeed = 15f;
    [SerializeField] private float radius = 1f;
    //동적으로 생성되는 오브젝트는 직접할당을 못함
    [SerializeField] private GameManager gameManager;

    private GameObject playerGo;

    private void Start()
    {
        playerGo = GameObject.Find("player");//오브젝트 이름으로 찾기
        gameManager = FindAnyObjectByType<GameManager>();//컴포넌트 이름으로 찾기
    }
    void Update()
    {
        //충돌처리 로직(지금은 OnXXX~메소드을 사용하지 않는다)
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        Vector2 p1 = transform.position;
        Vector2 p2 = playerGo.transform.position;
        Vector2 dir = p1 - p2;
        float distance = dir.magnitude;//거리(벡터의 크기)
        //float distance = Vector2.Distance(p1, p2);//거리만 구할 거라면 이것도 가능

        float r1 = radius;
        float r2 = playerGo.GetComponent<PlayerController>().radius;
        float sumR = r1 + r2;//화살과 플레이어의 기즈모(원)를 그려 반지름의 길이를 합한다
        if (distance < sumR)//화살과 플레이어간의 거리 < 화살과 플레이어의 기즈모(원)의 반지름의 합
        {
            Destroy(gameObject);
            //Debug.LogFormat("충돌: {0}, {1}", distance, sumR);
            gameManager.DecreaseHp();
        }

        if (transform.position.y < -3)
        {
            //Debug.LogError("충돌");//화살이 제대로 충돌했는지 확인한다
            Destroy(gameObject);//Arrow오브젝트(화살) 파괴
            //Destroy(this);//이건 해당 컴포넌트(ArrowController)만 사라진다. Arrow오브젝트가 파괴되는게 아님 
        }
    }
    //이벤트 함수
    //private void OnDrawGizmos() //기즈모를 그려서 radius크기의 원을 확인해본다
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, radius);
    //}
}

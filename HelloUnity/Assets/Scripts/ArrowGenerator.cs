using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //프리팹 에셋으로 인스턴스를 만든다
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float rate;//화살생성 주기
    private float delta;//경과시간
    [HideInInspector] public List<GameObject> arrowList;//활성화된 화살을 보관할 리스트

    void Update()
    {
        if (GameManager.isGameOver)
            return;//게임오버되면 화살생성 방지

        delta += Time.deltaTime;//시간경과
        //Debug.Log(delta);
        if (delta > rate)
        {
            GameObject go = Instantiate(arrowPrefab);//생성위치는 프리팹 에셋에 설정된 위치
            float randX = Random.Range(-9, 10); //임의의 위치(-9 ~ +9)
            go.transform.position = new Vector3(randX, go.transform.position.y, go.transform.position.z);//화살이 생성될 때 임의의 위치로 설정
            arrowList.Add(go);//활성화된 화살을 리스트에 담는다
            delta = 0;//시간 초기화
        }
    }
}

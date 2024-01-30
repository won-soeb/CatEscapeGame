using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //������ �������� �ν��Ͻ��� �����
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float rate;//ȭ����� �ֱ�
    private float delta;//����ð�
    [HideInInspector] public List<GameObject> arrowList;//Ȱ��ȭ�� ȭ���� ������ ����Ʈ

    void Update()
    {
        if (GameManager.isGameOver)
            return;//���ӿ����Ǹ� ȭ����� ����

        delta += Time.deltaTime;//�ð����
        //Debug.Log(delta);
        if (delta > rate)
        {
            GameObject go = Instantiate(arrowPrefab);//������ġ�� ������ ���¿� ������ ��ġ
            float randX = Random.Range(-9, 10); //������ ��ġ(-9 ~ +9)
            go.transform.position = new Vector3(randX, go.transform.position.y, go.transform.position.z);//ȭ���� ������ �� ������ ��ġ�� ����
            arrowList.Add(go);//Ȱ��ȭ�� ȭ���� ����Ʈ�� ��´�
            delta = 0;//�ð� �ʱ�ȭ
        }
    }
}

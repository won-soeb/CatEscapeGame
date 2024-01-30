using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private Image hpGauge;
    [SerializeField] private Text hpText;

    [SerializeField] private float damage = 1;//ȭ���� �����
    [SerializeField] private float maxHp = 10;//�ִ�ü��
    private float hp;//����ü��

    public static bool isGameOver = false;//���ӿ��� ���� ����
    [HideInInspector] public ArrowGenerator arrowGenerator;//Ȱ��ȭ�� ȭ���(����Ʈ),ȭ���� �������� �ҷ���

    private void Awake()
    {
        hp = maxHp;
        hpText.text = string.Format("{0} / {1}", hp, maxHp);//�ؽ�Ʈ�� ������ ü���� ���
    }
    public void DecreaseHp()//ü�°���
    {
        hpGauge.fillAmount -= damage / maxHp;
        //�������� ����� hp : ȭ���� �����/�ִ�ü�¿� ����ؼ� ü�¹ٸ� ���ҽ�Ų��
        hp -= damage;
        //�ؽ�Ʈ�� ����� hp : ȭ���� �������ŭ ���ڸ� ���ҽ�Ų��
        hpText.text = string.Format("{0} / {1}", hp, maxHp);//��ȭ�� ü�°��� �ݿ�

        if (hpGauge.fillAmount <= 0)//ü���� 0���ϸ�
        {
            isGameOver = true;//���ӿ���
            restartButton.SetActive(true);//��ư Ȱ��ȭ            
            //Ȱ��ȭ�� ȭ�� ��� �����
            foreach (GameObject items in arrowGenerator.arrowList)
            {
                //�������̱� ������ �ݺ������� ������
                //����Ʈ�� ��ұ� ������ ������ �� �� ����. �׷��� foreach�� �����
                Destroy(items);
            }
        }
    }
    public void Restart()//��õ� ��ư
    {
        isGameOver = false;
        SceneManager.LoadScene("SampleScene");
    }
}
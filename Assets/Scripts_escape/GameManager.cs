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

    [SerializeField] private float damage = 1;//화살의 대미지
    [SerializeField] private float maxHp = 10;//최대체력
    private float hp;//현재체력

    public static bool isGameOver = false;//게임오버 상태 여부
    [HideInInspector] public ArrowGenerator arrowGenerator;//활성화된 화살들(리스트),화살의 데미지를 불러옴

    private void Awake()
    {
        hp = maxHp;
        hpText.text = string.Format("{0} / {1}", hp, maxHp);//텍스트에 설정된 체력을 출력
    }
    public void DecreaseHp()//체력감소
    {
        hpGauge.fillAmount -= damage / maxHp;
        //게이지에 출력할 hp : 화살의 대미지/최대체력에 비례해서 체력바를 감소시킨다
        hp -= damage;
        //텍스트에 출력할 hp : 화살의 대미지만큼 숫자를 감소시킨다
        hpText.text = string.Format("{0} / {1}", hp, maxHp);//변화할 체력값을 반영

        if (hpGauge.fillAmount <= 0)//체력이 0이하면
        {
            isGameOver = true;//게임오버
            restartButton.SetActive(true);//버튼 활성화            
            //활성화된 화살 모두 지우기
            foreach (GameObject items in arrowGenerator.arrowList)
            {
                //여러개이기 때문에 반복문으로 돌린다
                //리스트에 담았기 때문에 개수를 알 수 없다. 그래서 foreach를 사용함
                Destroy(items);
            }
        }
    }
    public void Restart()//재시도 버튼
    {
        isGameOver = false;
        SceneManager.LoadScene("SampleScene");
    }
}
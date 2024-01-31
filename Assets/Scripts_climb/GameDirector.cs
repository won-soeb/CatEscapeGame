using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private Text velocityText;//Text UI
    public void UpdateVelocityText(Vector2 velocity)
    {
        velocityText.text = velocity.ToString();//���
    }
    private void Update()
    {
        //ClimbCloudClear ������ Ŭ���ϸ�
        if (SceneManager.GetActiveScene().name == "ClimbCloudClear"
            && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("ClimbCloud");//�̸����� �ε�
        }
    }
}

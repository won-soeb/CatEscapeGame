using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private Text velocityText;
    public void UpdateVelocityText(Vector2 velocity)
    {
        velocityText.text = velocity.ToString();
    }
}

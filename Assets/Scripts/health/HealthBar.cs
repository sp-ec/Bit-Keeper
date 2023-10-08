using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public static GameObject healthBarObject;
    public Slider slider;
    public float health;
    
    void Awake() {
        healthBarObject = gameObject;
    }

    void Start() {
        slider = GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }

    public void damaged(int amount) {
        slider.value -= amount;
        if (slider.value == 0) {
            // trigger Game Over Script
            GameOver.gameOver = true;
        }
    }
    
}

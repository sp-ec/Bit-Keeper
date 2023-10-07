using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public float health;

    void Start() {
        slider = GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }

    public void damaged(int amount) {
        slider.value -= amount;
    }
    
}

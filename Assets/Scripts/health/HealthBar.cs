using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    Slider slider;
    float health;

    // Start is called before the first frame update

    public HealthBar(Slider slider, float health) {
        this.slider = slider;
        this.health = health;
        slider.maxValue = health;
        slider.value = health;
    }

    public void damaged(int amount) {
        slider.value -= amount;
    }
    
}

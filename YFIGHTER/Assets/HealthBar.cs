using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health){
        slider.value = health;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

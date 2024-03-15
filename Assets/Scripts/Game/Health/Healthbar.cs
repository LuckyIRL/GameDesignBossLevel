using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider _healthSlider;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        if (_healthSlider == null)
        {
            Debug.LogError("Slider component not found on the GameObject!");
        }
        else
        {
            Debug.Log("Slider component found!");
        }
    }

    public void SetMaxHealth(int maxHealth) 
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        _healthSlider.value = health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider _healthSlider;
    public float health;
    public float maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
        _healthSlider.value = maxHealth;

        //_healthSlider = GetComponent<Slider>();
        if (_healthSlider == null)
        {
            Debug.LogError("Slider component not found on the GameObject!");
        }
        else
        {
            Debug.Log("Slider component found!");
        }
    }

    public void Update()
    {
        _healthSlider.value = health;
        //  Debug.Log("Health!"+_healthSlider.value);

    }
}

   
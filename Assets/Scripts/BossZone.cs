using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossZone : MonoBehaviour
{
    public UnityEvent boss_zone_entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boss_zone_entered.Invoke(); 
        }
    }
}

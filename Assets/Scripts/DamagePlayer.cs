using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    PlayerBehaviour playerBehaviour;
    public Collider damageCollider;
    public int damageAmount = 10;

    void Start()
    {
        playerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    private void OnTriggerEnter(Collider damageCollider)
    {
        if (damageCollider.CompareTag("Player"))
        {
            playerBehaviour.TakeDamage(damageAmount);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionScript3D : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger, interacted;

    private bool insideTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            insideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            insideTrigger = false;
        }
    }

    void Update()
    {
        if (insideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            interacted.Invoke();
        }
    }
}

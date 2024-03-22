using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    // Create unity events for trigger actions
    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger; // Create unity events for trigger actions

    // On Trigger enter
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enteredTrigger.Invoke();
        }
    }

    // On Trigger stay
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            stayInTrigger.Invoke();
        }
    }

    // On Trigger exit
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            exitedTrigger.Invoke();
        }
    }

}
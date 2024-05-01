using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gameManager;
    public Transform respawnPoint;
    public GameObject checkPointOn;
    public GameObject checkPointOff;
    Collider coll;

    void Start()
    {
        gameManager = GameManager.gameManager;
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkPointOff.SetActive(false);
            gameManager.UpdateCheckpoint(respawnPoint.position);
            checkPointOn.SetActive(true);
            coll.enabled = false;
        }
    }
}

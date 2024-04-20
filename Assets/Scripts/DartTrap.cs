using UnityEngine;

public class DartTrap : MonoBehaviour
{
    public GameObject dartPrefab;
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 2f;

    private bool trapActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trapActive = true;
            InvokeRepeating("SpawnDart", 0f, spawnInterval);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trapActive = false;
            CancelInvoke("SpawnDart");
        }
    }

    void SpawnDart()
    {
        if (trapActive)
        {
            // Randomly select a spawn point index
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform selectedSpawnPoint = spawnPoints[randomIndex];

            // Spawn the dart at the selected spawn point
            Instantiate(dartPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }
    }
}

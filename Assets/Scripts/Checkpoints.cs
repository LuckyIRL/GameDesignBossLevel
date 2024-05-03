using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;

    PlayerBehaviour player_script;

    private void Start()
    {
        player_script = GetComponent<PlayerBehaviour>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player_script.is_dead)
        {
            player.transform.position = vectorPoint;
            player_script.is_dead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            vectorPoint = player.transform.position;
            Destroy(other.gameObject);
        }
    }
}

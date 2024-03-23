using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonShooting : MonoBehaviour
{
    public Vector2 turn;
    public GameObject cannonBall;
    public Transform firePoint;
    private bool cannonActive;
    public GameObject playerCamera;
    public GameObject player;
    public GameObject cannonCamera;
    public GameObject exit_panel;
    

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        cannonActive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cannonActive == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(cannonBall, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * force * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ExitCannon();
            }
        }       
    }

    public void ActivateCannon()
    {
        cannonActive = true;          
    }

    public void ExitCannon()
    {
        player.SetActive(true);
        playerCamera.SetActive(true);
        cannonCamera.SetActive(false);
        exit_panel.SetActive(false);
        cannonActive = false;
    }
}

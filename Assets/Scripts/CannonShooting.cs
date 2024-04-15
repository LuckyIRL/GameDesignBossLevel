using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonShooting : MonoBehaviour
{
    public Vector2 turn;
    public GameObject cannonBall;
    public Transform firePoint;
    [HideInInspector] public bool cannonActive;
    public GameObject playerCamera;
    public GameObject player;
    public GameObject cannonCamera;
    public GameObject exit_panel;
    public GameObject playerSeat;
    public PlayerBehaviour playerController;
    public float ammo;
    public TextMeshProUGUI ammo_UI;
    private float overheat;
    public float overheat_limit;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        overheat = 0;
        ammo = 0;
        cannonActive = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (cannonActive == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
            if (Input.GetMouseButtonDown(0) && ammo >= 1)
            {
                fire();                
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ExitCannon();
            }
        }  
        
        if (overheat >= overheat_limit)
        {
            ExitCannon();
            self_destruct();

        }
    }


    private void fire()
    {
        GameObject bullet = Instantiate(cannonBall, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * force * Time.deltaTime;
        ammo -= 1;
        ammo_UI.text = ammo.ToString();
    }
    public void ActivateCannon()
    {
        cannonActive = true;
        player.transform.position = playerSeat.transform.position;
        player.SetActive(false);
        playerCamera.SetActive(false);
        cannonCamera.SetActive(true);
        exit_panel.SetActive(true);
    }

    public void ExitCannon()
    {
        player.SetActive(true);
        playerCamera.SetActive(true);
        cannonCamera.SetActive(false);
        exit_panel.SetActive(false);
        cannonActive = false;
    }

    public void Add_Ammo()
    {
        ammo += 1;
        ammo_UI.text = ammo.ToString();
    }

    public void self_destruct()
    {
        Destroy(gameObject);
    }

    public void add_overheat()
    {
        overheat += 1;
    }
    
}

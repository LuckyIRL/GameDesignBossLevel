using System.Collections;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashCooldown = 2f;
    private bool canDash = true;

    void Update()
    {
        if (canDash && Input.GetKeyDown(KeyCode.LeftControl)) // Check for left CTRL key press
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        Vector3 dashDirection = transform.forward; // Example: Dash in the direction the player is facing
        Vector3 dashTarget = transform.position + dashDirection * dashDistance;

        // Move the player quickly to the dash target
        while (transform.position != dashTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, dashTarget, dashDistance * Time.deltaTime);
            yield return null;
        }

        // Apply cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}

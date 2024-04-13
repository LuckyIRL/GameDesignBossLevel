using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void OpenDoor()
    {
        // Rotate the door 90 degrees around the Y-axis
        transform.Rotate(0, 90, 0);
    }
}

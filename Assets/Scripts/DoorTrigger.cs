using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public AnimationClip leftDoorAnimationClip;
    public AnimationClip rightDoorAnimationClip;

    public GameObject leftDoor;
    public GameObject rightDoor;

    private Animation leftDoorAnimation;
    private Animation rightDoorAnimation;

    void Start()
    {
        // Get the Animation components from the door GameObjects
        leftDoorAnimation = leftDoor.GetComponent<Animation>();
        rightDoorAnimation = rightDoor.GetComponent<Animation>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the door trigger");
            if (leftDoorAnimation != null && rightDoorAnimation != null)
            {
                // Play the animation clips for both doors
                leftDoorAnimation.clip = leftDoorAnimationClip;
                rightDoorAnimation.clip = rightDoorAnimationClip;

                leftDoorAnimation.Play();
                rightDoorAnimation.Play();
            }
        }
    }
}

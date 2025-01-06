using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the object to follow
    public Vector3 CameraOffset;
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = transform.position; // Current camera position
            newPosition.y = target.position.y+CameraOffset.y; // Follow the target's Y position
            newPosition.z = target.position.z+CameraOffset.z; // Follow the target's Z position
            transform.position = newPosition; // Update camera position
        }
    }
}

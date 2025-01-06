using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    private Transform boat;

    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Boat").transform;
    }

    void LateUpdate()
    {
        if(boat == null)
        {
            return;
        }
        
        FaceToBoat();
    }

    public void FaceToBoat()
    {
        // Rotate the tower to face the boat
        Vector3 direction = (boat.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}

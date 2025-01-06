using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootSpeedBarierObjectHandler : MonoBehaviour
{
    [SerializeField] private ShootSpeedUpgradeBarier shootSpeedUpgradeBarier;
    [SerializeField] private GameObject anotherBarier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boat"))
        {
            Debug.Log("Collided with boat");
            shootSpeedUpgradeBarier.IncreaseBoatShootSpeed();
            Destroy(anotherBarier);
            Destroy(this.gameObject);
        }
    }
}

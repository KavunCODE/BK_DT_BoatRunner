using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelEnder : MonoBehaviour
{
    [SerializeField] private BoatController mainCharacterBoatController;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BossBoat"))
        {
            EndBossLevel(other);
        }
    }   

    void EndBossLevel(Collider other)
    {
        mainCharacterBoatController.ChangeIsStopped(true);
        mainCharacterBoatController.SetShooting(false);
    }
}

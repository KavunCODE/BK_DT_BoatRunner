using UnityEngine;
using UnityEngine.UI;
using System;

// Define a ScriptableObject to hold boat characteristics
[CreateAssetMenu(fileName = "BoatCharacteristics", menuName = "Custom/Boat Characteristics")]
public class BoatCharacteristics : ScriptableObject
{
    [Header("Player Info")]
    [Space(10)]

    public string playerName;
    public int    playerLevel = 1;

    [Space(10)]
    [Header("Boat&Gun Type")]
    [Space(10)]

    public GameObject Boat;
    public GameObject GunHead;

    [Space(10)]
    [Header("Boat Characteristics")]
    [Space(10)]

    public int boatLevel = 1;
    public event Action OnBoatLevelUp;
    public int gunLevel = 1;
    public float damageDealt = 0; 
    public float speed = 3f;
    public float shootDelay = 1.5f;
    public event Action OnShootingDelayChanged;
    public float amountOfDamage = 25f;
    // Add any other characteristics you want to upgrade

    public float ShootDelay 
    {
        get { return shootDelay; }
        set
        {
            // Update the shoot delay
            shootDelay = value;
            
            // Trigger the event if there are subscribers
            if (OnShootingDelayChanged != null)
            {
                OnShootingDelayChanged.Invoke();
            }
        }
    }

    public int BoatLevel 
    {
        get { return boatLevel; }
        set
        {
            // Update the shoot delay
            boatLevel = value;
            
            // Trigger the event if there are subscribers
            if (OnBoatLevelUp != null)
            {
                OnBoatLevelUp.Invoke();
            }
        }
    }
}

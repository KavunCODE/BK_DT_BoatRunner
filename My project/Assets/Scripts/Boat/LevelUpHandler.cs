using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundAndFX;

public class LevelUpHandler : MonoBehaviour
{
    [SerializeField] private BoatCharacteristics boatCharacteristics;
    [SerializeField] private GameObject prefabToSpawn;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);

    public void LevelUp()
    {
        // Set spawn position
        spawnPosition = this.transform.position;

        // Destroy the existing boat
        DestroyBoat();

        // Instantiate a new boat prefab as a child of this GameObject
        GameObject newBoat = Instantiate(prefabToSpawn, spawnPosition + new Vector3(0f, 0.03f,0f), spawnRotation, transform);
        ServiceLocator.Current.Get<FxSystem>().PlayEffect("LevelUp", spawnPosition);
        ServiceLocator.Current.Get<SoundSystem>().PlaySound("LevelUpBoat");

        // Optionally, you can rename the instantiated object
        newBoat.name = "Boat";
    }

    void DestroyBoat()
    {
        // Find and destroy the existing boat
        GameObject boatObject = GameObject.Find("Boat");
        if (boatObject != null)
        {
            Destroy(boatObject);
        }
        else
        {
            Debug.LogWarning("Boat object not found.");
        }
    }
}

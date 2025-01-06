using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLevelUpdateBarier : MonoBehaviour
{
    private LevelUpHandler levelUpHandler;
    [SerializeField] private GameObject anotherBarier;
    [SerializeField] private BoatCharacteristics boatCharacteristics;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boat"))
        {
            levelUpHandler = other.GetComponent<LevelUpHandler>();
            BoatLevelUP();
        }
    }

    void BoatLevelUP()
    {
        boatCharacteristics.boatLevel ++;
        levelUpHandler.LevelUp();
        Destroy(anotherBarier);
        Destroy(this.gameObject);
    }
}

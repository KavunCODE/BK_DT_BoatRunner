using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossController : MonoBehaviour
{
    [SerializeField] private BoxCollider pirateBoatCollider;
    [SerializeField] private PirateBodyOutlineController pirateBodyOutlineController;

    public float initialBossHealth = 20f;
    private float currentBossHealth;
    private event Action OnBoatHit;
    
    void Start()
    {
        pirateBoatCollider.enabled = false;
        currentBossHealth = initialBossHealth;
        pirateBodyOutlineController.OnAllGunsDestroyed += ActivateDamagablePirateBody;
    }

    void OnDestroy()
    {
        pirateBodyOutlineController.OnAllGunsDestroyed -= ActivateDamagablePirateBody;
        OnBoatHit -= GetDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered with: " + other.name); // Log the name of the collider
        if(other.CompareTag("Bullet"))
        {
            Debug.Log("Boat is getting Damage!");
            OnBoatHit?.Invoke();
        }
    }

    void ActivateDamagablePirateBody()
    {
        pirateBoatCollider.enabled = true;
        OnBoatHit += GetDamage;
    }

    void GetDamage()
    {
        this.currentBossHealth -= 1f;
        this.pirateBodyOutlineController.ChangeBodyOutlineColor(currentBossHealth/20 - (0.05f));

        if(currentBossHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

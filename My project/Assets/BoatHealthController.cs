using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SoundAndFX;

public class BoatHealthController : MonoBehaviour
{
    private float sandBoxDMG;
    private float towerBulletDamage;
    private bool canTakeDamage = true;
    private Coroutine cooldownCoroutine;

    private float boatHealth = 100f;
    public event Action<float> OnBoatDead; // Adjusted to accept float parameter
    public event Action<float> OnGetDamage; // Adjusted to accept float parameter

    void Start()
    {
        sandBoxDMG = ServiceLocator.Current.Get<DamageTable>().sandBoxDMG;
        towerBulletDamage = ServiceLocator.Current.Get<DamageTable>().towerBulletDamage;

        OnBoatDead += HandleBoatDead;
        OnGetDamage += GetDamage;
    }

    void OnDestroy()
    {
        OnBoatDead -= HandleBoatDead;
        OnGetDamage -= GetDamage;
    }

    void OnTriggerEnter(Collider other)
    {    
        if (!canTakeDamage)
            return;

        float damage = 0f;
        if (other.CompareTag("SandBox"))
        {
            damage = sandBoxDMG;
        }
        else if (other.CompareTag("TowerBullet"))
        {
            damage = towerBulletDamage;
        }

        if (damage > 0f)
        {
            // Apply damage to the boat
            OnGetDamage?.Invoke(damage);
            
            // Start cooldown coroutine
            if (cooldownCoroutine != null)
            {
                StopCoroutine(cooldownCoroutine);
            }
            cooldownCoroutine = StartCoroutine(DamageCooldown());
        }
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.5f); // Adjust cooldown duration as needed
        canTakeDamage = true;
    }

    public void GetDamage(float damage)
    {
        boatHealth -= damage;

        if (boatHealth <= 0f)
        {
            // Invoke the BoatDead event with the final damage amount
            OnBoatDead?.Invoke(damage);
        }
        Debug.Log(boatHealth);
    }

    private void HandleBoatDead(float damage)
    {
        ServiceLocator.Current.Get<FxSystem>().PlayEffect("Explosion", this.transform.position);
        Destroy(this.gameObject);
    }
}

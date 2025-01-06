using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PirateBodyOutlineController : MonoBehaviour
{
    public Outline bodyOutline;
    private int destroyedGunsCounter;
    private int totalGunsCount;
    public event Action OnAllGunsDestroyed;

    void Start()
    {
        bodyOutline = GetComponent<Outline>();
        totalGunsCount = FindObjectsOfType<BossTowerGunController>().Length;
        
        // Subscribe to gun destroyed events for all guns
        foreach (var gun in FindObjectsOfType<BossTowerGunController>())
        {
            gun.OnGunDestroyed += HandleGunDestroyed;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to avoid memory leaks
        foreach (var gun in FindObjectsOfType<BossTowerGunController>())
        {
            gun.OnGunDestroyed -= HandleGunDestroyed;
        }
    }

    private void HandleGunDestroyed()
    {
        destroyedGunsCounter++;

        // Check if all guns are destroyed
        if (destroyedGunsCounter >= totalGunsCount)
        {
            // Activate outline component on body of pirate ship
            bodyOutline.enabled = true;
            OnAllGunsDestroyed?.Invoke();
        }
    }

    public void ChangeBodyOutlineColor(float damage)
    {
        bodyOutline.SetHealthPercentage(damage);
    }
}

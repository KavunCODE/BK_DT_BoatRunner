using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossTowerGunController : TowerGunController
{
    // Override the distance to boat to shoot for the boss tower
    public override float distanceToBoatToShoot { get; } = 15f;

    public event Action OnGunDestroyed; // Event for individual gun destruction

    // Override OnDestroy method to raise event when gun is destroyed
    protected void OnDestroy()
    {
        OnGunDestroyed?.Invoke(); // Raise gun destroyed event
    }
}

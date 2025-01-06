using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossTowerGunDestroyer : MonoBehaviour
{
    private event Action OnBoatDestroy;

    void Start()
    {
        OnBoatDestroy += DestroyBossTowerGun;
    }

    public void UnsubscribeFromBoatDestroyEvent()
    {
        OnBoatDestroy -= DestroyBossTowerGun;
    }

    void DestroyBossTowerGun()
    {
        UnsubscribeFromBoatDestroyEvent();
        Destroy(this.gameObject);
    }
}

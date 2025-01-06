using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHead : MonoBehaviour
{
    /// <summary>
    /// List of Guns "Bullet spawners"
    /// </summary>

    public List<GunScript> GunScripts = new List<GunScript>();

    /// <summary>
    /// Stops/Starts shooting boat guns
    /// </summary>

    public void SetShooting(bool _shooting)
    {
        foreach(var gunScript in GunScripts)
        {
            gunScript.SetShooting(_shooting);
        }
    }
}

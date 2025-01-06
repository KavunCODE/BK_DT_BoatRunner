using System.Collections;
using UnityEngine;
using SoundAndFX;

public class GunScript : MonoBehaviour
{
    [SerializeField] private BoatCharacteristics boatCharacteristics;
    public GameObject prefabToInstantiate;
    public Transform spawnPoint;
    private bool Shooting = true; 
    private float delay;

    void Start()
    {
        GetCurrentDelay();
        boatCharacteristics.OnShootingDelayChanged += GetCurrentDelay;
    }

    void OnDestroy()
    {
        boatCharacteristics.OnShootingDelayChanged -= GetCurrentDelay;
    }
    
    void FixedUpdate()
    {
        if(!Shooting)
        {
            return;
        }

        if (prefabToInstantiate != null && spawnPoint != null && Shooting == true)
        {
            Shooting = false;
            Instantiate(prefabToInstantiate, spawnPoint.position, spawnPoint.rotation);
            ServiceLocator.Current.Get<SoundSystem>().PlaySound("GunShot");
            StartCoroutine(ShootingDelay());
        }
        else
        {
        }
    }

    private IEnumerator ShootingDelay()
    {
        yield return new WaitForSeconds(delay);
        Shooting = true;
    }

    private void GetCurrentDelay()
    {
        delay = boatCharacteristics.shootDelay;
    }

    public void SetShooting(bool _shooting)
    {
        StopAllCoroutines(); //interrupts shooting delay coroutine;
        Shooting = _shooting;
    }
}


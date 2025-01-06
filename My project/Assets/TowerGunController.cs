using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundAndFX;

public class TowerGunController : MonoBehaviour, ITowerGun
{
    [SerializeField] protected GameObject bulletPrefab;
    public float BulletSpeed { get; } = 1f;
    public virtual float distanceToBoatToShoot { get; } = 10f; // Changed to virtual

    protected bool shooting = true;
    protected float delay = 2f;
    protected Transform boat;

    protected void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Boat")?.transform;
        if (boat == null)
        {
            Debug.LogError("Boat not found!");
            enabled = false; // Disable the component if boat is not found
        }
    }

    protected void FixedUpdate()
    {
        if (bulletPrefab != null && shooting && boat != null)
        {
            FaceToBoat();
            float distanceToBoat = Vector3.Distance(transform.position, boat.position);
            if (distanceToBoat <= distanceToBoatToShoot)
            {
                Shoot();
            }
        }
    }

    protected IEnumerator ShootingDelay()
    {
        yield return new WaitForSeconds(delay);
        shooting = true;
    }

    public virtual void Shoot()
    {
        shooting = false;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        StartCoroutine(ShootingDelay());
    }

    public void FaceToBoat()
    {
        Vector3 direction = (boat.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}


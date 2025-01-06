using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundAndFX;

public class BossTowerGunCollisionHandler : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private BossTowerGunController bossTowerGunController;
    [SerializeField] private GameObject Smoke;

    private float bossTowerGunHealth = 100f;
    private float maxHealth = 100f;

    void Start()
    {
        outline = transform.Find("Head").gameObject.GetComponent<Outline>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            DealDamageToTowerGun();
            DestroyBullet(other);
        }
    }

    void DealDamageToTowerGun()
    {
        float damage = ServiceLocator.Current.Get<DamageTable>().boatBulletDamage;
        bossTowerGunHealth -= damage;
        ServiceLocator.Current.Get<SoundSystem>().PlaySound("BulletHit");
        UpdateOutlineColor();
        CheckIfKilled();
        CheckIfDamagedEnoughToSmoke();
    }

    void CheckIfKilled()
    {
        if(bossTowerGunHealth <= 0f)
        {
            ServiceLocator.Current.Get<FxSystem>().PlayEffect("Explosion", this.transform.position);
            ServiceLocator.Current.Get<SoundSystem>().PlaySound("DestroySandBox");
            Destroy(this.gameObject);
        }
    }

    void CheckIfDamagedEnoughToSmoke()
    {
        if(bossTowerGunHealth < 50f)
        {
            Smoke.SetActive(true);
        }
    }

    void UpdateOutlineColor()
    {
        // Calculate the health percentage
        float healthPercentage = Mathf.Clamp01(bossTowerGunHealth / maxHealth);

        // Set the outline color based on health percentage
        outline.SetHealthPercentage(healthPercentage);
    }

    void DestroyBullet(Collider other)
    {
        Destroy(other.gameObject);
    }
}

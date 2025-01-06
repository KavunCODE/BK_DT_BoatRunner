using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerBulletSpawner : MonoBehaviour
{
    Rigidbody rb;
    Transform transform;
    GameObject target;
    private float towerBulletDamage;
    
    void Start()
    {
        towerBulletDamage = ServiceLocator.Current.Get<DamageTable>().towerBulletDamage; //get bulletDamage
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("BOAT");
        this.transform.DOMove(target.transform.position, 3f).OnComplete(DestroyBullet);

        void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boat"))
        {
            Destroy(this.gameObject);
        }
    }
}

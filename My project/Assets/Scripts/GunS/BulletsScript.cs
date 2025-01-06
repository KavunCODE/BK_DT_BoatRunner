using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletsScript : MonoBehaviour
{
    Rigidbody rb;
    Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        this.transform.DOMoveZ(transform.position.z + 20f, 2f).OnComplete(DestroyBullet);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SandBox"))
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

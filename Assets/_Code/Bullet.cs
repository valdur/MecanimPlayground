using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float damage;
    Rigidbody rb;

    internal void Setup(float damage, float muzzleSpeed) {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * muzzleSpeed;
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision collision) {
        var hlth = collision.gameObject.GetComponent<Health>();
        if (hlth)
            hlth.DealDamage(damage);
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public Transform muzzle;
    public Transform leftHandTarget;
    public Transform rightHandTarget;

    public float damage;
    public float muzzleSpeed;
    public float fireRate; // shots per second

    public Bullet bulletPrefab;

    private float nextAllowedFireTime;

    public void Fire() {
        if (CanFire()) {
            var ins = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            nextAllowedFireTime = Time.time + 1 / fireRate;
            ins.Setup(damage, muzzleSpeed);
        }

    }

    public bool CanFire() {
        return (Time.time > nextAllowedFireTime);
    }
}

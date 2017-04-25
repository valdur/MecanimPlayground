using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHp = 100;
    float hp;
    public bool destroyOnDeath;

    public event Action deadEvent = delegate { };
    public event Action hitEvent = delegate { };

    protected bool dead;

    private void Start() {
        hp = maxHp;
    }

    public void DealDamage(float damage) {
        if (dead)
            return;
        hp -= damage;
        if (hp <= 0f) {
            Die();
        } else {
            hitEvent();
        }
    }

    private void Die() {
        dead = true;
        deadEvent();
        if (destroyOnDeath) {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour {

    Animator mecanim;
    Health health;

    // Use this for initialization
    void Start() {
        mecanim = GetComponent<Animator>();
        health = GetComponent<Health>();

        health.hitEvent += HitHandler;
        health.deadEvent += DeadHandler;
    }

    private void DeadHandler() {
        mecanim.SetBool("Dead", true);
    }

    private void HitHandler() {
        mecanim.SetTrigger("Hit");
    }
}

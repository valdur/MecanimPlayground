using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour {

    Animator mecanim;
    bool dead;

    // Use this for initialization
    void Start() {
        mecanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            mecanim.SetTrigger("Hit");
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            dead = !dead;
            mecanim.SetBool("Dead", dead);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAimer : MonoBehaviour {

    public Transform pivot;
    public WeaponHolder target;

    private void Start() {
        if (!target) {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player)
                target = player.GetComponent<WeaponHolder>();
        }
    }

    void Update() {
        if (target)
            target.Aim(pivot.localEulerAngles.x);
    }
}
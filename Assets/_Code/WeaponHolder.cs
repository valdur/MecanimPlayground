using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

    public Transform weaponSocket;
    Animator mecanim;

    public WeaponController weapon;

    void Start() {
        mecanim = GetComponent<Animator>();
    }

    internal void Aim(float pitch) {
        weaponSocket.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    private void Update() {
        if (Input.GetButton("Fire1"))
            weapon.TryFire();
    }

    private void OnAnimatorIK(int layerIndex) {

        mecanim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        mecanim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        mecanim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandTarget.position);
        mecanim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandTarget.position);



    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

    public WeaponController weapon;
    public Transform weaponSocket;
    Animator mecanim;

    void Start() {
        mecanim = GetComponent<Animator>();
    }

    internal void Aim(float pitch) {
        weaponSocket.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    private void OnAnimatorIK(int layerIndex) {
        mecanim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandTarget.position);
        mecanim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        mecanim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandTarget.position);
        mecanim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
    }
}

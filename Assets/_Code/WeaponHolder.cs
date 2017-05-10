using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

    public Transform weaponSocket;
    Animator mecanim;

    WeaponController spawnedWeapon;

    public WeaponController[] weapons;

    public bool useInput;

    void Start() {
        mecanim = GetComponent<Animator>();

        var hlth = GetComponent<Health>();
        if (hlth)
            hlth.deadEvent += () => ChangeWeapon(-1);
    }

    internal void Aim(float pitch) {
        weaponSocket.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    public bool CanFire() {
        return spawnedWeapon ? spawnedWeapon.CanFire() : false;
    }

    public void Fire() {
        if (spawnedWeapon)
            spawnedWeapon.Fire();
    }

    public void ChangeWeapon(int weaponIndex = -1) {
        if (weaponIndex == -1) {
            ChangeWeapon(null);
        } else
            if (weaponIndex >= 0 && weaponIndex < weapons.Length) {
            ChangeWeapon(weapons[weaponIndex]);
        }
    }

    void ChangeWeapon(WeaponController pfb) {

        if (spawnedWeapon != null) {
            Destroy(spawnedWeapon.gameObject);
            spawnedWeapon = null;
        }
        if (pfb != null) {
            spawnedWeapon = Instantiate(pfb, weaponSocket);
            spawnedWeapon.transform.localPosition = Vector3.zero;
            spawnedWeapon.transform.localRotation = Quaternion.identity;
        }

    }

    private void OnAnimatorIK(int layerIndex) {

        var lh = spawnedWeapon && spawnedWeapon.leftHandTarget;
        var rh = spawnedWeapon && spawnedWeapon.rightHandTarget;

        mecanim.SetIKPositionWeight(AvatarIKGoal.LeftHand, lh ? 1f : 0f);

        mecanim.SetIKPositionWeight(AvatarIKGoal.RightHand, rh ? 1f : 0f);

        if (lh)
            mecanim.SetIKPosition(AvatarIKGoal.LeftHand, spawnedWeapon.leftHandTarget.position);
        if (rh)
            mecanim.SetIKPosition(AvatarIKGoal.RightHand, spawnedWeapon.rightHandTarget.position);



    }
}

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
    }

    internal void Aim(float pitch) {
        weaponSocket.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    private void Update() {
        if (useInput) {
            if (Input.GetButton("Fire1"))
                if (spawnedWeapon)
                    spawnedWeapon.TryFire();
            if (Input.GetKeyDown(KeyCode.Alpha0))
                ChangeWeapon(null);
            for (int i = 0; i < Mathf.Min(weapons.Length, 9); i++) {
                if (Input.GetKey(KeyCode.Alpha1 + i))
                    ChangeWeapon(weapons[i]);
            }
        }
    }

    void ChangeWeapon(WeaponController pfb) {

        if (spawnedWeapon != null) {
            Destroy(spawnedWeapon.gameObject);
        }

        spawnedWeapon = Instantiate(pfb, weaponSocket);
        spawnedWeapon.transform.localPosition = Vector3.zero;
        spawnedWeapon.transform.localRotation = Quaternion.identity;
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

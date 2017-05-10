using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class PlayerController : MonoBehaviour {

    WeaponHolder holder;

    // Use this for initialization
    void Start() {
        holder = GetComponent<WeaponHolder>();
    }

    // Update is called once per frame
    void Update() {
        UpdateWeapon();
    }

    private void UpdateWeapon() {
        if (Input.GetButton("Fire1"))
            holder.Fire();
        if (Input.GetKeyDown(KeyCode.Alpha0))
            holder.ChangeWeapon(-1);
        for (int i = 0; i < 9; i++) {
            if (Input.GetKey(KeyCode.Alpha1 + i))
                holder.ChangeWeapon(i);
        }
    }
}

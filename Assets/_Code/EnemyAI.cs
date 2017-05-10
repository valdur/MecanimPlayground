using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

[RequireComponent(typeof(WeaponHolder))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class EnemyAI : MonoBehaviour {


    public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for

    private WeaponHolder holder;
    public float shootRange;

    private void Start() {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        holder = GetComponent<WeaponHolder>();

        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.stoppingDistance = shootRange;

        holder.ChangeWeapon(0);

        if (!target) {
            var targetGO = GameObject.FindGameObjectWithTag("Player");
            if (targetGO)
                target = targetGO.transform;
        }

    }


    private void Update() {
        if (target == null)
            return;

        agent.SetDestination(target.position);
        character.Move(agent.desiredVelocity, false, false);

        if (agent.remainingDistance < shootRange) {
            Aim();
            holder.Fire();
        }
    }

    private void Aim() {
        var dist = target.position - transform.position;
        var look = Quaternion.LookRotation(dist, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, 3f * Time.deltaTime);

    }

    public void SetTarget(Transform target) {
        this.target = target;
    }
}
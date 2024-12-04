using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target;

    public float radius = 10f;
    public Vector3 originalePosition;
    public float maxDistance = 50f;

    public DamageZone damageZone;
    public Animator animator;

    public Health health;

    public enum CharaterState
    {
        Normal,
        Attack,
        Die
    }
    public CharaterState curremtState;

    private void Start()
    {
        originalePosition = transform.position;
    }
    void Update()
    {
        if (health.currentHP <= 0)
        {
            ChangeState(CharaterState.Die);
        }
        if (target != null)
        {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        }

        if (curremtState == CharaterState.Die)
        {
            return;
        }

        var distanceToOriginal = Vector3.Distance(originalePosition, transform.position);

        var distance = Vector3.Distance(target.position, transform.position);
        if (distance <= radius && distanceToOriginal <= maxDistance)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
            distance = Vector3.Distance(target.position, transform.position);
            if (distance < 2f)
            {
                ChangeState(CharaterState.Attack);
            }
        }

        if (distance > radius || distanceToOriginal > maxDistance)
        {
            navMeshAgent.SetDestination(originalePosition);
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
            distance = Vector3.Distance(target.position, transform.position);
            if (distance < 1f)
            {
                animator.SetFloat("Speed", 0);
            }
            ChangeState(CharaterState.Normal);
        }
    }

    private void ChangeState(CharaterState newState)
    {

        switch (curremtState)
        {
            case CharaterState.Normal:
                break;
            case CharaterState.Attack:
                break;
        }
        switch (newState)
        {
            case CharaterState.Normal:
                damageZone.EndAttack();
                break;
            case CharaterState.Attack:
                animator.SetTrigger("Attack");
                damageZone.BeginAttack();
                break;
            case CharaterState.Die:
                animator.SetTrigger("Die");
                Destroy(gameObject, 5f);
                break;
        }
        curremtState = newState;
    }


    public void Wander()
    {
        var randomDirection = Random.insideUnitSphere * radius;
        randomDirection += originalePosition;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
        var finalPotion = hit.position;
        navMeshAgent.SetDestination(finalPotion);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 2f;
    public Vector3 movementVelocity;
    public PlayerInput playerInput;
    public DamageZone damageZone;
    public Health health;
    public Animator animator;
    public float gravity = -9.81f;


    public enum CharaterState
    {
        Normal,
        Attack,
        Die
    }
    public CharaterState currentState;


    private void FixedUpdate()
    {
        if (health.currentHP <= 0)
        {
            ChangeState(CharaterState.Die);
            return;
        }
        
        switch (currentState)
        {
            case CharaterState.Normal:
                CalculateMoment();
                break;
            case CharaterState.Attack:
                break;
        }

        if (characterController.isGrounded)
        {
            movementVelocity.y = 0;
        }
        else
        {
            movementVelocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(movementVelocity);
    }

    void CalculateMoment()
    {
        if (playerInput.attackInput)
        {
            ChangeState(CharaterState.Attack);
            animator.SetFloat("Speed", 0);
            return;
        }
        movementVelocity.Set(playerInput.horizontalInput, 0, playerInput.verticalInput);
        movementVelocity.Normalize();
        movementVelocity = Quaternion.Euler(0, -45, 0) * movementVelocity;
        movementVelocity *= speed * Time.deltaTime;

        animator.SetFloat("Speed", movementVelocity.magnitude);

        if (movementVelocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movementVelocity);
        }
    }

    private void ChangeState(CharaterState newState)
    {
        playerInput.attackInput = false;
        switch (currentState)
        {
            case CharaterState.Normal:
                break;
            case CharaterState.Attack:
                break;
        }
        switch (newState)
        {
            case CharaterState.Normal:
                break;
            case CharaterState.Attack:
                animator.SetTrigger("Attack");
                break;
            case CharaterState.Die:
                animator.SetTrigger("Die");
                break;
        }
        currentState = newState;
    }

    public void OnAttack01End()
    {
        ChangeState(CharaterState.Normal);
    }

    public void BeginAttack()
    {
        damageZone.BeginAttack();
    }

    public void EndAttack()
    {
        damageZone.EndAttack();
    }
}

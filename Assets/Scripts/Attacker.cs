﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 3f)]
    float currentSpeed = 0f;    
    GameObject currentTarget;
    Animator animator;

    [SerializeField] AudioClip deathSound;


    private void Awake()
    {
        FindObjectOfType<LevelController>().attackerSpawned();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().attackerKilled();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }    

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }
   
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) 
        {
           return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);     
              
        }
        
    }


}

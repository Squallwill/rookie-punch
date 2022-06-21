using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;

    public Transform attackpoint;
    public LayerMask enemyLayers;

    public float attackrange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public GameObject Resetbtt;

    public healthbar hpj;

    private void Start()
    {
        
            currentHealth = maxHealth;
        hpj.setHealthMax(maxHealth);


    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Rightattack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Leftattack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                upperattack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Rightattack()
    {
        animator.SetTrigger("right");

        Collider2D[] damage = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);

        foreach(Collider2D enemy in damage)
        {
            Debug.Log("damgesus");
            enemy.GetComponent<Enemy>().TakeDamagej(attackDamage);
            
        }
    }
    void Leftattack()
    {
        animator.SetTrigger("left");

        Collider2D[] damage = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);

        foreach (Collider2D enemy in damage)
        {
            Debug.Log("hit");
            enemy.GetComponent<Enemy>().TakeDamagej(attackDamage);

        }
    }

    void upperattack()
    {
        animator.SetTrigger("upper");

        Collider2D[] damage = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);

        foreach (Collider2D enemy in damage)
        {
            Debug.Log("damgesus");
            enemy.GetComponent<Enemy>().TakeDamagej(attackDamage);

        }
    }
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("hit");

        currentHealth -= damage;

        Debug.Log("damgesus");

        hpj.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            KO();
        }

    }
    public void KO()
    {
        animator.SetBool("KO", true);

        Resetbtt.SetActive(true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

}

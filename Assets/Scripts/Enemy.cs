using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    public Transform attackpoint;
    public LayerMask player;

    public float attackrange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public GameObject winning;

    public healthbar hpf;

    void Start()

    {
        currentHealth = maxHealth;
        hpf.setHealthMax(maxHealth);
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Rightattack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Leftattack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                upperattack();
                nextAttackTime = Time.time + 1.5f / attackRate;
            }
        }
    }
    public void TakeDamagej(int damage)
    {
        animator.SetTrigger("hit");

        currentHealth -= damage;

        Debug.Log("damgesus");

        hpf.setHealth(currentHealth);

        if (currentHealth <=0)
        {
            KO();
        }
        
    }
    public void KO ()
    {
        animator.SetBool("KO", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        winning.SetActive(true);

    }
   
    void Rightattack()
    {
        animator.SetTrigger("right");

        Collider2D[] damage = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, player);

        foreach (Collider2D enemy in damage)
        {
            Debug.Log("damgesus");
            enemy.GetComponent<player>().TakeDamage(attackDamage);

        }
    }
    void Leftattack()
    {
        animator.SetTrigger("left");

        Collider2D[] damage = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, player);

        foreach (Collider2D enemy in damage)
        {
            Debug.Log("damgesus");
            enemy.GetComponent<player>().TakeDamage(attackDamage);

        }
    }

    void upperattack()
    {
        animator.SetTrigger("upper");

        Collider2D[] damage = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, player);

        foreach (Collider2D player in damage)
        {
            Debug.Log("damgesus");
            player.GetComponent<player>().TakeDamage(attackDamage);

        }
    }
}

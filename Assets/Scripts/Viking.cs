using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : MonoBehaviour
{
    public Animator animator;
    public int maxHealt = 100;
    int currentHealth;
    private BoxCollider2D boxCollider;


    void Start()
    {
        currentHealth = maxHealt;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        boxCollider.size = new Vector2(0.7f, 0.7f);
        this.enabled = false;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : MonoBehaviour
{
    public Animator animator;
    public int maxHealt = 100;
    int currentHealth;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;


    void Start()
    {
        currentHealth = maxHealt;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 50)
        {
            animator.SetTrigger("Enrage");
        }


        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        boxCollider.size = new Vector2(0.7f, 0.7f);
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        this.enabled = false;

    }
}
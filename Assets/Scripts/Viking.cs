using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Viking : MonoBehaviour
{
    public Animator animator;
    public int maxHealt = 100;
    int currentHealth;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    public bool Invulnerable = false;
    public bool firstEnrage = true;

    void Start()
    {
        currentHealth = maxHealt;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void TakeDamage(int damage)
    {
        if (Invulnerable)
        {
            return;
        }

        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 10 && firstEnrage)
        {
            firstEnrage = false;
            animator.SetTrigger("Enrage");
        }


        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public IEnumerator Wait3()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Waiting for 3 seconds...");
        yield return new WaitForSeconds(3);
        Debug.Log("Loading WinScene...");
        SceneManager.LoadScene("WinScene");
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        boxCollider.size = new Vector2(0.7f, 0.7f);
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        this.enabled = false;
        SceneManager.LoadScene("WinScene");
        //Wait3();

    }
}

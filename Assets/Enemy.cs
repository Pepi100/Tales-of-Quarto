using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealt = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealt;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;    

        //Play hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("enemy died");
        //Die animation
        //Disable enemy
    }
}

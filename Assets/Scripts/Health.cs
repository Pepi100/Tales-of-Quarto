using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private float _maxHealth = 10;
    [SerializeField] 
    private float _currentHealth;
    [SerializeField]
    public UIHealthBar healthBar;
    public Animator animator;
    /*
    [SerializeField] private GameObject bloodParticle;

    [SerializeField] private Renderer renderer;
    [SerializeField] private float flashTime = 0.2f;
    */

    private void Start()
    {
        _currentHealth = 0.5f;
        //healthBar.SetHealth(_currentHealth);
    }

    public void Reduce(int damage)
    {
        _currentHealth -= damage / _maxHealth;
        //healthBar.SetHealth(_currentHealth);
        Debug.Log("HIT new health = " + _currentHealth.ToString());
        //CreateHitFeedback();
        if (_currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            
            Die();
        }
    }

    public void AddHealth(int healthBoost)
    {
        int health = Mathf.RoundToInt(_currentHealth * _maxHealth);
        int newHealth = health + healthBoost;
        if(newHealth > _maxHealth)
        {
            _currentHealth = 1;
        }
        else
        {
            _currentHealth = newHealth / _maxHealth;
        }
        //healthBar.SetHealth(_currentHealth);
        Debug.Log("RECOVER new health = " + _currentHealth.ToString());
    }

    /*
    private void CreateHitFeedback()
    {
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        StartCoroutine(FlashFeedback());
    }

    private IEnumerator FlashFeedback()
    {
        renderer.material.SetInt("_Flash", 1);
        yield return new WaitForSeconds(flashTime);
        renderer.material.SetInt("_Flash", 0);
    }
    */

    private void Die()
    {
        Debug.Log("Died");
        //SceneManager.LoadScene("Boss Fight");
    }
}


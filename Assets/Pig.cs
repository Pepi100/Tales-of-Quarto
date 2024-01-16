using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{

    [SerializeField]
    private GameObject _pickUpDrop;

    public Animator animator;
    public int maxHealt = 100;
    int currentHealth;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
   
    public Transform player;
    Vector2 myPos;
    Vector2 target;

    private AchievementController _achivController;

    void Start()
    {
        currentHealth = maxHealt;
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _achivController = GameObject.FindWithTag("AchievementController").GetComponent<AchievementController>();


    }
    void Update()
    {
        myPos = transform.position;
        target = new Vector2(player.position.x, player.position.y);
        float distance = Vector2.Distance(myPos, target);
        if (distance < 6.0f)
        {
            animator.SetBool("IsClose", true);
        }
        else
        {
            animator.SetBool("IsClose", false);
        }
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
        Vector3 position = transform.position;
        GameObject go = Instantiate(_pickUpDrop);
        go.transform.position = position;

        _achivController.SetMobKill(true);


        animator.SetBool("IsDead", true);
        boxCollider.size = new Vector2(0.7f, 0.7f);
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        this.enabled = false;
        Destroy(gameObject);



    }
}

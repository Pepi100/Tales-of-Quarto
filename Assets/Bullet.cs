using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int bulletdamage = 10;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {;
        Viking viking = hitInfo.GetComponent<Viking>();
        if (viking != null)
        {
            viking.TakeDamage(bulletdamage);
        }

        Destroy(gameObject);
    }

}

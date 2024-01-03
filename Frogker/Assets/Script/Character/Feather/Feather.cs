using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    //Variables
    float speed = 10f;
    public Rigidbody2D rb;
    int damage = 5;


    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        EnemyBasic enemy = collision.GetComponent<EnemyBasic>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    #region Variables
    public Rigidbody2D rb;
    int damage = 5;

    #endregion

    #region Start move down and collison to eliminate on his own
    void Start()
    {
        rb.gravityScale = 4f;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        PlayerStats player = collision.GetComponent<PlayerStats>();
        if (collision.CompareTag("Player"))
        {
            //Debug.Log(collision.name);
            player.TakeDamagePlayer(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 3)
        {
            
            Destroy(gameObject);
        }
    }
    #endregion
}

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
        rb.gravityScale = 4;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        PlayerStats player = gameObject.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.TakeDamagePlayer(damage);
        }
        Destroy(gameObject);
    }
    #endregion
}

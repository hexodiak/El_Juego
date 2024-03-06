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
        //Debug.Log(collision.name);
        PlayerStats player = gameObject.GetComponent<PlayerStats>();
        if (collision.tag == "Player")
        {
            //player.TakeDamagePlayer(damage);
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beak : MonoBehaviour
{
    #region Variables
    public Animator animator;

    int damage = 5;
    #endregion

    #region Start and Collision detection

    private void Start()
    {
        animator.SetTrigger("BeakLong");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStats player = gameObject.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.TakeDamagePlayer(damage);
        }
        if (collision.gameObject.layer == 6)//touches wall
        {
            Destroy(gameObject);
        }
        
    }


    #endregion
}

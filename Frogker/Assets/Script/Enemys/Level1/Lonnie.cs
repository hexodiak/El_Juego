using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonnie : MonoBehaviour
{
    #region Variables

    //Unity
    public Rigidbody2D rb;
    PlayerStats playerStats;
    public Animator animator;

    public Transform Point1;
    public Transform Point2;
    public Transform Point3;

    public Transform beakPoint;
    public GameObject beak;
    #endregion

    #region Start and Update to start attacks
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)//toca al jugador
        {
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            playerStats.TakeDamagePlayer(5);
            animator.SetTrigger("Idle");
        }
        if (collision.gameObject.layer == 3)//toca pared
        {
            animator.SetTrigger("Idle");
        }
        if (collision.gameObject.layer == 6)//toca piso
        {
            animator.SetTrigger("Idle");
        }

    }

    #endregion

    #region Method of lines of attacks

    public void BeakAttack()
    {
        Instantiate(beak, beakPoint.position, beakPoint.rotation);
    }


    #endregion


}

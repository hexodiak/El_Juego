using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonnie : MonoBehaviour
{
    #region Variables

    [Header("Unity")]
    public Rigidbody2D rb;
    PlayerStats playerStats;
    public Animator animator;

    
    [Header("Lonnie's points to bounce its used in the state machine")]
    public Transform Point1;
    public Transform Point2;
    public Transform Point3;


    [Header("Droping points of wood")] 
    public Transform Wood1;
    public Transform Wood2;
    public Transform Wood3;
    public GameObject wood;//gameobject of falling wood


    [Header("Growing beak")]
    public Transform beakPoint;//where beak starts
    public GameObject beak;//long beak
    
    #endregion

    #region Start attacks and collison to reset order of attacks
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
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
        //Instantiate the beak to grow from one side to another
        Instantiate(beak, beakPoint.position, beakPoint.rotation);

        //Instantiate the wood in the droping positions
        Instantiate(wood, Wood1.position, Wood1.rotation);
        Instantiate(wood, Wood2.position, Wood2.rotation);
        Instantiate(wood, Wood3.position, Wood3.rotation);
    }


    #endregion


}

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


    [Header("Growing spike from floor")]
    public Transform startSecondAttackPosition1;//where Lonnie has to go to start second attack
    //public Transform startSecondAttackPosition2;//where Lonnie has to go to start second attack
    public Transform spikePoint1;//where spike starts position one
    public Transform spikePoint2;//where spike starts position two
    public Transform spikePoint3;//where spike starts position three
    public GameObject spike;//long spike itself
    
    #endregion

    #region Start attacks and collison to reset order of attacks
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameobject.layer == 8)//toca al jugador
        //{

        //    animator.settrigger("idle");
        //}
        //if (collision.gameobject.layer == 3)//touches floor
        //{
        //    animator.settrigger("idle");
        //}
        //if (collision.gameobject.layer == 6)//touches wall
        //{
        //    animator.settrigger("idle");
        //}

    }

    #endregion

    #region Method of lines of attacks

    public void BeakAttack()
    {
        //Instantiate the spikes to grow from the floor
        Instantiate(spike, spikePoint1.position, spikePoint1.rotation);
        Instantiate(spike, spikePoint2.position, spikePoint2.rotation);
        Instantiate(spike, spikePoint3.position, spikePoint3.rotation);

        //Instantiate the wood in the droping positions
        Instantiate(wood, Wood1.position, Wood1.rotation);
        Instantiate(wood, Wood2.position, Wood2.rotation);
        Instantiate(wood, Wood3.position, Wood3.rotation);
    }


    #endregion


}

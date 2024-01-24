using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonnie_Attack : StateMachineBehaviour
{
    //Attack
    
    Transform SpawnPoint1;
    Transform player;

    Rigidbody2D rb;
    private float speed = 7f;
    Vector3 lastPlayerPosition;

    Collision2D c;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpawnPoint1 = GameObject.FindGameObjectWithTag("SpawnPoint1").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerPosition = player.position;
        rb = animator.GetComponent<Rigidbody2D>();


    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.position = Vector3.MoveTowards(rb.position, lastPlayerPosition, speed * Time.deltaTime);
        rb.gravityScale = 0.1f;

        

    }



    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");

    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonnieMovement : StateMachineBehaviour
{

    //Idle


    Transform SpawnPoint1;
    Transform player;
    Lonnie lonnie;

    Rigidbody2D rb;
    private float speed = 4f;
    private int num = 1;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpawnPoint1 = GameObject.FindGameObjectWithTag("SpawnPoint1").transform;
        rb = animator.GetComponent<Rigidbody2D>();

        

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        rb.position = Vector3.MoveTowards(rb.position, SpawnPoint1.position, speed * Time.deltaTime);
        rb.gravityScale = 0;

        if (rb.position.x == SpawnPoint1.position.x)//condicion para empezar la primera parte del ataque
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }

    
}

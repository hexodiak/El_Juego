using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonnie_Attack : StateMachineBehaviour
{
    //Attack
    
    
    Transform player;
    EnemyBasic enemyBasic;

    Rigidbody2D rb;
    private float speed = 7f;
    Vector3 lastPlayerPosition;

    Collision2D c;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerPosition = player.position;
        rb = animator.GetComponent<Rigidbody2D>();
        enemyBasic = animator.GetComponent<EnemyBasic>();


    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyBasic.LookAtPlayer();

        rb.position = Vector3.MoveTowards(rb.position, lastPlayerPosition, speed * Time.deltaTime);
        if (rb.position.x == lastPlayerPosition.x)//condicion para empezar la primera parte del ataque
        {
            rb.gravityScale = 1f;
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakSecond : StateMachineBehaviour
{
    Lonnie lonnie;
    EnemyBasic enemyBasic;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lonnie = animator.GetComponent<Lonnie>();
        enemyBasic = animator.GetComponent<EnemyBasic>();
        enemyBasic.LookAtPlayer();
        lonnie.BeakAttack();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }


}

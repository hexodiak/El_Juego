using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonnie_Choose : StateMachineBehaviour
{
    //Idle to choose the next attack, first or second

    private int num;//to let know which attack goes next
    private int side;//to let know which attack goes next


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        num = Random.Range(0, 2);
        //num = 1;

        if (num == 0)
        {
            //side = num;
            animator.SetTrigger("Run");
        }
        if (num == 1)
        {
            side = num;
        }


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (side == 0)
        {
            //animator.SetTrigger("Run");
        }
        if (side == 1)
        {
            //Debug.Log("Beak se eligio");
            animator.SetTrigger("Beak");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }

    
}



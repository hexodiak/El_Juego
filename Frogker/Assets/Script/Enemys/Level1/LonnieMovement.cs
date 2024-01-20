using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonnieMovement : StateMachineBehaviour
{
    Transform SpawnPoint1;
    Transform player;

    Rigidbody2D rb;
    private float speed = 2.5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpawnPoint1 = GameObject.FindGameObjectWithTag("SpawnPoint1").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Vector2 target = new Vector2(SpawnPoint1.position.x, rb.position.y);
        //Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.gravityScale = 0;
        //rb.MovePosition(newPosition);
        rb.position = Vector3.MoveTowards(rb.position, SpawnPoint1.transform.position, speed * Time.deltaTime);
        if (rb.position.x == SpawnPoint1.transform.position.x)
        {
            rb.position = Vector3.MoveTowards(rb.position, player.transform.position, speed * Time.deltaTime);
        }
        //rb.AddForce(newPosition);


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}

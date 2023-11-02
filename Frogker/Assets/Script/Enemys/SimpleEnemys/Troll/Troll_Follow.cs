using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Follow : StateMachineBehaviour
{
	

	public float speed = 2.5f;
	public float attackRange = 3f;

	Transform player;
	Rigidbody2D rb;
	Troll_Enemy troll_Enemy;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		troll_Enemy = animator.GetComponent<Troll_Enemy>();

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		

		Vector2 target = new Vector2(player.position.x, rb.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		rb.MovePosition(newPos);

		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			animator.SetTrigger("TrollAttack");
			troll_Enemy.waitThreeSeconds();
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("TrollAttack");
	}
}


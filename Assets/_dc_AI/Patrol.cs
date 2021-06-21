using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour
{
    public AI_Behaviour ai_Behaviour;
    public Vector3 wayPoint;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai_Behaviour = animator.GetComponentInParent<AI_Behaviour>();
        ai_Behaviour.AI.isStopped = false;
        ai_Behaviour.aiState = AIState.patrol;
        wayPoint = new Vector3(Random.Range(-30, 30), 1.08f, Random.Range(-30, 30)); // pick initial patrol location
        ai_Behaviour.AI.destination = wayPoint;
        Debug.Log(wayPoint);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // change patrol waypoint after one has been reached
        ai_Behaviour.AI.destination = wayPoint;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
          // stop patrolling
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

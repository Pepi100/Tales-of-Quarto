using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig_Attack : StateMachineBehaviour
{
    PigAttack pig;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pig = animator.GetComponent<PigAttack>();
        pig.Attack();
    }

}

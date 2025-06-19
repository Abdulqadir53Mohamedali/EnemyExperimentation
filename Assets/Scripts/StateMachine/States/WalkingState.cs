using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;


namespace EnemyExperimentation
{
    public class WalkingState : BaseState
    {



        public WalkingState(PlayerController player, Animator animator) : base(player, animator) { }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void OnEnter()
        {
            animator.CrossFade(WalkingHash, crossFadeDuration);
        }
        public override void FixedUpdate()
        {
            player.Walking();
        }
 
    }


}



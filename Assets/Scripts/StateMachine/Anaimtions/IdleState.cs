using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;


namespace EnemyExperimentation
{
    public class IdleState : BaseState
    {



        public IdleState(PlayerController player, Animator animator) : base(player, animator) { }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void OnEnter()
        {
            Debug.Log("Idle");
            animator.CrossFade(IdleHash, crossFadeDuration);

        }
        public override void FixedUpdate()
        {




            //animator.CrossFade(WalkingHash, crossFadeDuration);

            //player.Walking();
            //animator.CrossFade(WalkingHash, crossFadeDuration);

        }

    }


}



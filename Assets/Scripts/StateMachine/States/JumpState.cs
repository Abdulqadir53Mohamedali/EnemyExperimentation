using UnityEngine;


namespace EnemyExperimentation
{
    public class JumpState : BaseState
    {


        public JumpState(PlayerController player, Animator animator) : base(player, animator) { }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void OnEnter()
        {
            animator.CrossFade(JumpHash, crossFadeDuration);
        }
        public override void FixedUpdate()
        {
            player.HandleJump();
        }
    }
}


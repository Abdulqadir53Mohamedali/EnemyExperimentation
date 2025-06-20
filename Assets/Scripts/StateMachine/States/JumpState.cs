using UnityEngine;


namespace EnemyExperimentation
{
    public class JumpState : BaseState
    {


        public JumpState(PlayerController player, Animator animator) : base(player, animator) { }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void OnEnter()
        {
            //player.m_jumpRequested = false;

            animator.CrossFade(JumpHash, crossFadeDuration);
            player.HandleJump();


            //player.m_jumpRequested = false;

        }
        public override void FixedUpdate()
        {
            //player.HandleJump();
            //player.Walking();
        }

        public override void OnExit()
        {
            //Debug.Log(player.m_jumpRequested);

        }
    }
}


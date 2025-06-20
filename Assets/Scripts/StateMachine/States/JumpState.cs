using UnityEngine;


namespace EnemyExperimentation
{
    public class JumpState : BaseState
    {
        const float minAirTime = 0.5f;
        float enterTime;

        public JumpState(PlayerController player, Animator animator) : base(player, animator) { }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void OnEnter()
        {
            //player.m_jumpRequested = false;
            enterTime = Time.time;        

            animator.CrossFade(JumpHash, crossFadeDuration);
            player.HandleJump();


            //player.m_jumpRequested = false;

        }
        public override void FixedUpdate()
        {
            //player.HandleJump();
            player.Walking();
            if (player.m_isGrounded && Time.time - enterTime > minAirTime)
            {
                player.stateMachine.SetState(player.WalkingState);
            }         
            if (player.m_isGrounded && Time.time - enterTime > minAirTime && player.m_movementInput.sqrMagnitude == 0)
            {
                player.stateMachine.SetState(player.IdleState);
            }


        }

        public override void OnExit()
        {
            //Debug.Log(player.m_jumpRequested);

        }
    }
}


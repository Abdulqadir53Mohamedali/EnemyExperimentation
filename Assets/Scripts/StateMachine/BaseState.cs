using UnityEngine;

namespace EnemyExperimentation
{
    public abstract class BaseState : IState
    {
        protected readonly PlayerController player;
        protected readonly Animator animator;

        // hashes used to represent an aniamtion in the animator

        protected static readonly int WalkingHash = Animator.StringToHash(name: "Walking");
        protected static readonly int JumpHash = Animator.StringToHash(name: "Jump");

        // constant , time it takes to transition to an animation

        protected const float crossFadeDuration = 0.1f;

        protected BaseState(PlayerController player, Animator animator)
        {
            this.player = player;
            this.animator = animator;   
        }
        
        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }
    }
}


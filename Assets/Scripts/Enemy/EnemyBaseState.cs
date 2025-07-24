using UnityEngine;
using UnityEngine.Rendering;

namespace EnemyExperimentation
{

    public abstract class EnemyBaseState : IState
    {
        protected readonly Enemy enemy;
        protected readonly Animator animator;

        protected const float crossFadeDuration = 0.1f;

        protected static readonly int PatrollingHash = Animator.StringToHash(name: "Patrolling");
        protected static readonly int ChaseHash = Animator.StringToHash(name: "ChasingPlayer");
        protected static readonly int IdleHash = Animator.StringToHash(name: "Idle");
        protected static readonly int AttackHash = Animator.StringToHash(name: "Attack");
        protected EnemyBaseState(Enemy enemy, Animator animator)
        {
            this.enemy = enemy;
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


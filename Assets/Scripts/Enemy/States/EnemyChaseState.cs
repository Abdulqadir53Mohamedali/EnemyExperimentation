using UnityEngine;
using UnityEngine.AI;

namespace EnemyExperimentation
{
    public class EnemyChaseState : EnemyBaseState
    {
        readonly NavMeshAgent agent;
        readonly Transform player;
        public EnemyChaseState(Enemy enemy, Animator animator, NavMeshAgent agent, Transform player) : base(enemy, animator)
        {
            this.agent = agent;
            this.player = player;


        }


        public override void OnEnter()
        {
            Debug.Log("Wondering");
            animator.CrossFade(ChaseHash, crossFadeDuration);
        }


        public override void Update()
        {
            agent.SetDestination(player.position);
        }
    }

}

using UnityEngine;
using UnityEngine.AI;



namespace EnemyExperimentation{
    public class EnemyAttackState : EnemyBaseState
    {

        readonly NavMeshAgent agent;
        readonly Transform player;

        public EnemyAttackState(Enemy enemy, Animator animator,NavMeshAgent agent, Transform player) : base(enemy, animator)
        {
            this.agent = agent;
            this.player = player;   
        }


        public override void OnEnter()
        {
            Debug.Log("ATtack");
            animator.CrossFade(AttackHash, crossFadeDuration);
        }

        public override void Update()
        {
            agent.SetDestination(player.position);
            enemy.Attack();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created

    

    }
    

}

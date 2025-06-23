using UnityEngine;
using UnityEngine.AI;


namespace EnemyExperimentation
{
    public class EnemyWonderState : EnemyBaseState
    {
        readonly NavMeshAgent agent;
        readonly Vector3 startPoint;
        readonly float wonderRadius;

        public EnemyWonderState(Enemy enemy,Animator animator, NavMeshAgent agent,float wonderRadius) : base(enemy, animator) 
        {
            this.agent = agent;
            this.wonderRadius = wonderRadius;
            this.startPoint = enemy.transform.position; 

        }


        public override void OnEnter()
        {
            Debug.Log("Wondering");
            animator.CrossFade(PatrollingHash,crossFadeDuration);
        }


        public override void Update()
        {
            if (HasReachedDestination())
            {
                var randomDirection = Random.insideUnitSphere * wonderRadius;
                randomDirection += startPoint;

                NavMeshHit hit;

                NavMesh.SamplePosition(randomDirection, out hit, wonderRadius, 1);
                var finalPosition = hit.position;

                agent.SetDestination(finalPosition);
            }
        } 

        bool HasReachedDestination()
        {
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
        }
    }
}


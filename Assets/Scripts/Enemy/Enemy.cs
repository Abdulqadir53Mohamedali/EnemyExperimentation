using System.Threading;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyExperimentation
{
    using Utilities;

    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(PlayerDetector))]
    public class Enemy : Entity 
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] PlayerDetector playerDetector; 
        [SerializeField] Animator animator;

        [SerializeField] float wanderRadius = 10f;
        StateMachine stateMachine;



        [SerializeField] float timeBetweenAttacks;
        CountDownTimer attackTimer;

        //void OnValidate() => this.ValidateRefs();


        protected override void Start()
        {
            //base.Start();
            stateMachine = new StateMachine();
            attackTimer = new CountDownTimer(timeBetweenAttacks);

            var wonderState = new EnemyWonderState(enemy: this, animator, agent, wanderRadius);
            var chaseState = new EnemyChaseState(this, animator, agent,playerDetector.Player);
            var attackState = new EnemyAttackState(this,animator,agent,playerDetector.Player);


            At(wonderState, chaseState, new FuncPredicate(() => playerDetector.CanDetectPlayer()));
            At(chaseState, wonderState, new FuncPredicate(() => !playerDetector.CanDetectPlayer()));
            At(chaseState,attackState, new FuncPredicate(() => playerDetector.CanAttackPlayer()));
            At(attackState,chaseState, new FuncPredicate(() => !playerDetector.CanAttackPlayer()));

            //Any(wonderState, new FuncPredicate(() => true));
            stateMachine.SetState(wonderState);
        }

        void At(IState from , IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState from , IPredicate condition) => stateMachine.AddAnyTransition(from, condition);

        private void Update()
        {
            stateMachine.Update();
            attackTimer.Tick(Time.deltaTime);
        }


        private void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }
        public void Attack()
        {
            if (attackTimer.IsRunning)
            {
                return;
            }
            attackTimer.Start();
            Debug.Log("ATtacking");
        }



    }
 
}


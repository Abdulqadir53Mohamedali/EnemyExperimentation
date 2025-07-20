using System.Threading;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyExperimentation
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : Entity 
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] Animator animator;

        [SerializeField] float wanderRadius = 10f;
        StateMachine stateMachine;



        //void OnValidate() => this.ValidateRefs();


        protected override void Start()
        {
            base.Start();
            stateMachine = new StateMachine();


            var wonderState = new EnemyWonderState(enemy: this, animator, agent, wanderRadius);
            var chaseState = new EnemyChaseState(this, animator, agent, player);


            Any(wonderState, new FuncPredicate(() => true));
            stateMachine.SetState(wonderState);
        }

        void At(IState from , IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState from , IPredicate condition) => stateMachine.AddAnyTransition(from, condition);

        private void Update()
        {
            stateMachine.Update();
        }

        private void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }



    }
 
}


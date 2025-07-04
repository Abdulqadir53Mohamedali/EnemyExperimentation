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

        StateMachine stateMachine;



        //void OnValidate() => this.ValidateRefs();


        protected override void Start()
        {
            base.Start();
            stateMachine = new StateMachine();


            var WonderState = new EnemyWonderState(enemy: this, animator, agent, 5f);


            Any(WonderState, new FuncPredicate(() => true));
            stateMachine.SetState(WonderState);
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


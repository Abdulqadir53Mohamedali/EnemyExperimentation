using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR;

namespace EnemyExperimentation
{
    public class StateMachine
    {
        // A state node represents a state and all of its transtions 
        StateNode current;

        // 
        Dictionary<Type, StateNode> nodes = new();

        // Any transition is  a transition that does not need a from state
        HashSet<ITransition> anyTransition = new();


        public void Update()
        {
            var transition = GetTransition();

            // As long as there is soemthing to transition , thne we are going to change 
                // the state to whatever the To state was in thta particular transition
            if(transition != null)
            {
                ChangeState(transition.To);
            }

            //  run update of current state 
            current.State?.Update();

        }

        // if doing physics stuff in transition then we make use of fixedUpdate
            // I am currently doing to follow along with video
        public void FixedUpdate()
        {
            current.State?.FixedUpdate();
        }

        // to be able to set state of state mnachine from outside state machine
        public void SetState(IState state)
        {
            // find in dictionary and set that as the current state 
            current = nodes[state.GetType()];
            // Then running state OnEnter method
            current.State.OnEnter();

        }

        void ChangeState(IState state)
        {


            var previousState = current.State;
            var nextState = nodes[state.GetType()].State;

            if (state == current.State && state.GetType() != typeof(JumpState))
            {
                return;
            }
            // if state attempts to transition in to itself then it bails out 
            //if (state == current.State)
            //{
            //    return;
            //}



            previousState?.OnExit();
            nextState?.OnEnter();

            // ensures current state is set to actual StateNode which is stored in the dicitonary
            current = nodes[state.GetType()];
        }



        ITransition GetTransition()
        {
            // if any transition no matter form hwere evaluates to true then use that 

            foreach (var transition in anyTransition)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }

            };

            foreach (var transition in current.Transitions)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }
            }

            return null;    
        }

        public void AddTransition(IState from , IState to, IPredicate condition)
        {

            // create a from node , adding transtion which goes to next state
                // based ont the condition passed in

            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }

        public void AddAnyTransition(IState to, IPredicate condition)
        {
            anyTransition.Add(item:new Transition(GetOrAddNode(to).State,condition));
        }

        StateNode GetOrAddNode(IState state)
        {
            // takes in state , attmepts to find in dictionary 
            var node = nodes.GetValueOrDefault(key:state.GetType());

            // if returns default which is null , it will create a new stateNode using that state 

            if(node == null)
            {
                node = new StateNode(state);
                nodes.Add(state.GetType(), node);
            }

            return node;
        }
        // contains state and hashset of all possible transitions outside of its state in to others
        class StateNode
        {
            public IState State { get; }
            public HashSet<ITransition> Transitions { get; }


            // accepot that  state and initilise a empty hashset
            public StateNode(IState state)
            {

                State = state;
                Transitions = new HashSet<ITransition>();
            }

            // To add as many tranisitions as necessary 
            // state we are going to and the condition upon whihc we will movwe 
            public void AddTransition(IState to, IPredicate condition)
            {
                Transitions.Add(item: new Transition(to, condition));
            }
        }
    }
}


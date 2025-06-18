using UnityEngine;

namespace FSM
{
    public interface IState 
    {
        void OnEnter();
        void OnExit();
        void FixedUpdate();
        void Update();
    }


}


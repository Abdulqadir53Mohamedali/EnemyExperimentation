using UnityEngine;

namespace EnemyExperimentation
{
    public interface IState 
    {
        void OnEnter();
        void OnExit();
        void FixedUpdate();
        void Update();
    }


}


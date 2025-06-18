using UnityEngine;
 

namespace FSM
{
    // which state we are moving to based on which condition 
    public interface ITransition
    {
        IState To { get; }
        IPredicate Condition { get; }
    }
}


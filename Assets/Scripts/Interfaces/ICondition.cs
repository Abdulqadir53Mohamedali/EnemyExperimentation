using UnityEngine;

public interface ICondition 
{
    // Returns true when the transition condition is met
    bool Check(EnemyAI agent);
}

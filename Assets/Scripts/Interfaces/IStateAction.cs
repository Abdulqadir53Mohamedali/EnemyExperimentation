using UnityEngine;

/// <summary>
/// Defines one unit of AI behavior (enter/execute/exit) for an agent.
/// </summary>
public interface IStateAction
{
    // Called once when this action begins
    void Enter(EnemyAI agent);

    //Called every frame while this action is active
    void Execute(EnemyAI agent);

    //Called once when this action ends
    void Exit(EnemyAI agent);
}

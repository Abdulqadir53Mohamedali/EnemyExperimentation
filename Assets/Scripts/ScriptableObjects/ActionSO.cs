using UnityEngine;

[CreateAssetMenu(fileName = "ActionSO", menuName = "Scriptable Objects/ActionSO")]
public abstract class ActionSO : ScriptableObject, IStateAction
{
    public abstract void Enter(EnemyAI agent);
    public abstract void Execute(EnemyAI agent);
    public abstract void Exit(EnemyAI agent);

}

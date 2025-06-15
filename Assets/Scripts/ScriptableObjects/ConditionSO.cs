using UnityEngine;

[CreateAssetMenu(fileName = "ConditionSO", menuName = "Scriptable Objects/ConditionSO")]
public abstract class ConditionSO : ScriptableObject, ICondition
{
    public abstract bool Check(EnemyAI agent);
}

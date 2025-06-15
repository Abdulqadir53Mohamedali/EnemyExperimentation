using UnityEngine;

/// <summary>
/// Pairs a ConditionSO with the next StateSO to transition into when Check() is true.
/// </summary>
[CreateAssetMenu(fileName = "TransitionSO", menuName = "Scriptable Objects/TransitionSO")]
public class TransitionSO : ScriptableObject
{
    public ConditionSO condition;
    public StateSO nextState;

}

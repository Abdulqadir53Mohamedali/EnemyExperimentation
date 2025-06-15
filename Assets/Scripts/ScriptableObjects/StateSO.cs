using UnityEngine;

/// <summary>
/// Defines one AI state as lists of actions (onEnter, onExecute, onExit) and transitions.
/// </summary>
[CreateAssetMenu(fileName = "StateSO", menuName = "Scriptable Objects/StateSO")]
public class StateSO : ScriptableObject
{

    public ActionSO[] onEnterActions;
    public ActionSO[] onExecuteActions;
    public ActionSO[] onExitActions;
    public TransitionSO[] transitions;  
}

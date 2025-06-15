using UnityEngine;

/// <summary>
/// Drives the current State<T>: calls Enter, Execute, Exit appropriately.
/// </summary>
public class StateMachine<T>
{
    /// <summary>The active state.</summary>
    public State<T> CurrentState { get; private set; }

    /// <summary>Initialize with the starting state (calls its Enter).</summary>
    public void Initialize(State<T> startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    /// <summary>Switches to a new state (calls Exit on old, Enter on new).</summary>
    public void ChangeState(State<T> newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    /// <summary>Call this every frame to run the active state’s Execute().</summary>
    public void Update()
    {
        if (CurrentState != null)
            CurrentState.Execute();
    }
}

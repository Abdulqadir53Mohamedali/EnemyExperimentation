using UnityEngine;

/// <summary>
/// The generic base class for runtime states. T is the “agent” type, e.g. EnemyAI.
/// </summary>
public abstract class State<T>
{
    /// <summary>The owner of this state.</summary>
    protected T agent;

    /// <summary>Constructs a new state for the given agent.</summary>
    public State(T agent) { this.agent = agent; }

    /// <summary>Called once when the state is entered.</summary>
    public virtual void Enter() { }

    /// <summary>Called every frame while the state is active.</summary>
    public abstract void Execute();

    /// <summary>Called once when the state is exited.</summary>
    public virtual void Exit() { }
}

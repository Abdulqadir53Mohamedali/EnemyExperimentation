using UnityEngine;


/// <summary>
/// Wraps a StateSO asset into a runtime State<EnemyAI> for the FSM engine.
/// </summary>
public class SOStateWrapper : State<EnemyAI>
{
    private StateSO data;

    public SOStateWrapper(EnemyAI agent, StateSO data) : base(agent)
    {
        this.data = data;
    }

    public override void Enter()
    {
        foreach(var action in data.onEnterActions)
        {
            action.Enter(agent);
        }
    }

    public override void Execute()
    {
        foreach(var action in data.onExecuteActions)
        {
            action.Execute(agent);
        }

        foreach(var transition in data.transitions)
        {
            if (transition.condition.Check(agent))
            {
                var next = agent.GetWrappedState(transition.nextState);
                agent.stateMachine.ChangeState(next);
                break;
            }
        }
    }

    public override void Exit()
    {
        foreach(var action in data.onExitActions)
        {
            action.Exit(agent);
        }
    }
}

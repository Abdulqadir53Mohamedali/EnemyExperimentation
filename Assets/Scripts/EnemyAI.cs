using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// Main AI MonoBehaviour: holds the FSM, factory cache, and helper methods.
/// </summary>
public class EnemyAI : MonoBehaviour
{

    public StateSO startingState;

    public Animator Animator { get; private set; }

    internal StateMachine<EnemyAI> stateMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Dictionary<StateSO, State<EnemyAI>> cache;

    void Awake()
    {
        // Grab Animator and set up FSM + cache
        Animator = GetComponent<Animator>();
        cache = new Dictionary<StateSO, State<EnemyAI>>();
        stateMachine = new StateMachine<EnemyAI>();

        // Create and initialize the starting state
        var startWrapper = WrapState(startingState);
        stateMachine.Initialize(startWrapper);
    }

    void Update()
    {
        // Advance the FSM each frame
        stateMachine.Update();
    }

    // Returns the SOStateWrapper for the given StateSO, creating & caching if needed.
    internal State<EnemyAI> GetWrappedState(StateSO so) => WrapState(so);



    private State<EnemyAI> WrapState(StateSO so)
    {
        // Return existing wrapper if we’ve built it before
        if (cache.TryGetValue(so, out var existing))
            return existing;

        // Otherwise create, cache and return a new wrapper
        var wrapper = new SOStateWrapper(this, so);
        cache[so] = wrapper;
        return wrapper;
    }
    void Start()
    {

    }

}

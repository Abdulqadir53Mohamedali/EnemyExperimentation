using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class BasicEnemy : MonoBehaviour
{

    public Transform m_target;
    private NavMeshAgent m_agent;
    [SerializeField] private float m_speed;

    public enum EnemyStates
    {
        Idle,
        Patrolling,
        Chasing,
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }    
    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // m_agent.SetDestination(m_target.transform/position)
}

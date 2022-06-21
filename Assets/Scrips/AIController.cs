using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class AIController : MonoBehaviour
{
    private CharacterController m_controller;

    [SerializeField] LayerMask m_whatIsGround;
    [SerializeField] LayerMask m_whatIsPlayer;
    [SerializeField] LayerMask m_whatIsObstacle;

    [SerializeField] private float m_sightRange;
    [SerializeField] private float m_attackRange;
    [SerializeField] private float m_walkPoitRange;
    [SerializeField] private float m_timeBetweenAttacks;

    private Transform m_player;
    private NavMeshAgent m_agent;
    
    private bool m_playerInSightRange;
    private bool m_playerInAttackRange;
    private bool m_walkPointSet;
    private bool m_alreadyAttacked;
    private bool m_notAttacked;

    private Vector3 m_walkPoint;    

    private void Start()
    {
        m_controller = GetComponent<CharacterController>();
        m_player = GameObject.FindWithTag("Player").gameObject.transform;
        m_agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        m_playerInSightRange = Physics.CheckSphere(transform.position, m_sightRange, m_whatIsPlayer);
        m_playerInAttackRange = Physics.CheckSphere(transform.position, m_attackRange, m_whatIsPlayer);

        if (!m_playerInSightRange && !m_playerInAttackRange)
        {
            Patroling();
        }

        if (m_playerInSightRange && !m_playerInAttackRange)
        {
            ChasePlayer();
        }

        if (m_playerInSightRange && m_playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!m_walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            m_agent.SetDestination(m_walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - m_walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            m_walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-m_walkPoitRange, m_walkPoitRange);
        float randomZ = Random.Range(-m_walkPoitRange, m_walkPoitRange);

        m_walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(m_walkPoint, -transform.up, 2f, m_whatIsGround))
        {
            m_walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        m_agent.SetDestination(m_player.position);
    }

    private void  AttackPlayer()
    {
        Vector3 distanceToPlayer = transform.position - m_player.position;
        if (distanceToPlayer.magnitude < 3f)
        {
            m_agent.SetDestination(transform.position);
        }
        else
        {
            m_agent.SetDestination(m_player.position);
        }

        if (Physics.Linecast(transform.position, m_player.position, m_whatIsObstacle))
        {
            m_notAttacked = true;
        }
        else
        {
            m_notAttacked = false;
        }

        transform.LookAt(m_player);


        if (!m_alreadyAttacked && !m_notAttacked)
        {
            m_controller.SetShooting();

            m_alreadyAttacked = true;
            Invoke(nameof(ResetAttack), m_timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        m_alreadyAttacked = false;
    }

}

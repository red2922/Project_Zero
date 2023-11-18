using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float attackCooldown;
    public bool alreadyAttacked;

    //Ranges
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        //Stop floating character
        agent.transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, LayerMask.GetMask("Player"));
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, LayerMask.GetMask("Player"));

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) MoveTowardsPlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, LayerMask.GetMask("Ground")))
            walkPointSet = true;
    }

    public void MoveTowardsPlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
           
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    
    //Deletes Enemy Object
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

//Shows attack range and sight range
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform player;
    NavMeshAgent agent;
    public LayerMask whatisground, whatisplayer;
    public Vector3 walkPoint;
    bool walkpointset;
    public float walkpointrange;
    public float timebetweenattacks;
    bool alreadyattacked;
    public float sightrange, attackrange;
    public GameObject projectile;
    public bool playerinsightrange, playerinattackrange;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }*/
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, whatisplayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, whatisplayer);
        if (!playerinsightrange && !playerinattackrange)
        {
            Patroling();
        }
        if (playerinsightrange && !playerinattackrange)
        {
            ChasePlayer();
        }
        if (playerinattackrange && playerinsightrange)
        {
            AttackPlayer();
        }
    }

    private void Awake()
    {
        player = GameObject.Find("exo_gray").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Patroling()
    {
        if (!walkpointset)
        {
            SearchWalkPoint();
        }
        if(walkpointset)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distancetowalkpoint = transform.position - walkPoint;
        if (distancetowalkpoint.magnitude < 1f)
        {
            walkpointset = false;
        }
    }
    private void SearchWalkPoint()
    {
        float randomz = Random.Range(-walkpointrange, walkpointrange);
        float randomx = Random.Range(-walkpointrange, walkpointrange);
        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatisground))
        {
            walkpointset = true;
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyattacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            alreadyattacked = true;
            Invoke(nameof(ResetAttack), timebetweenattacks);
        }
    }
    private void ResetAttack()
    {
        alreadyattacked = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

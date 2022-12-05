using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Enemy
{
    public class EnemyAi : MonoBehaviour
    {
        public float baseSpeed = 3f;
        public float chaseSpeed = 5f;

        public Transform player;

        public float enemySeePlayerDistance;
        public float enemyAttackPlayerDistance;

        protected List<Transform> wayPoints = new List<Transform>();

        protected NavMeshAgent agent;
        protected Animator anim;

        protected bool currentlyPatrolling = false;
        protected bool currentlyChasing = false;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();

            GameObject wps = GameObject.FindGameObjectWithTag("Waypoints");

            foreach (Transform t in wps.transform)
            {
                wayPoints.Add(t);
            }
        }

        private void Update()
        {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceToPlayer <= enemyAttackPlayerDistance)
            {
                AttackPlayer();

            }
            else if (distanceToPlayer <= enemySeePlayerDistance)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }
        }

        private void AttackPlayer()
        {
            agent.SetDestination(transform.position);

            anim.SetTrigger("Stab Attack");
            anim.SetBool("Run Forward", false);
            anim.SetBool("Walk Forward", false);

            agent.speed = baseSpeed;

            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }

        private void ChasePlayer()
        {
            if (!currentlyChasing)
            {
                agent.SetDestination(player.position);
                anim.SetBool("Run Forward", true);
                anim.SetBool("Walk Forward", false);

                agent.speed = chaseSpeed;
            }

            if (agent.remainingDistance <= 0)
            {
                currentlyChasing = false;
            }
        }

        private void Patrol()
        {
            if (!currentlyPatrolling)
            {
                agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

                anim.SetBool("Walk Forward", true);
                anim.SetBool("Run Forward", false);

                agent.speed = baseSpeed;
            }

            if (agent.remainingDistance <= 0)
            {
                currentlyPatrolling = false;
            }
        }
    }
}
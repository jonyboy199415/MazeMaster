using UnityEngine;
using System.Collections;


namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class Enemy_Navigation : MonoBehaviour {
		public GameObject player;
		public GameObject patrolDestination;
		public GameObject[] patrolPoints;
		int patrolNumber;
		bool canPatrol;
		bool aggro;
		public float attackRange;
		bool attack;
		public float damping;
		bool hunting;
		float time;
		bool timeStart;

		public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; } // the character we are controlling
		public Transform target;                                    // target to aim for

		// Use this for initialization
		void Start()
		{
			//agent = GetComponent<NavMeshAgent>();
			aggro = false;
			//anim = GetComponent<Animator>();
			patrolPoints= GameObject.FindGameObjectsWithTag("patrol");
			patrolNumber = Random.Range(0, patrolPoints.Length);
			hunting = false;
			time = 0.0f;
			timeStart = false;

			agent = GetComponentInChildren<NavMeshAgent> ();
			character = GetComponent<ThirdPersonCharacter> ();

			agent.updateRotation = false;
			agent.updatePosition = true;
		}
		// Update is called once per frame
		void Update()
		{
			if (target != null) {
				agent.SetDestination (target.position);
			}

			if (agent.remainingDistance > agent.stoppingDistance) {
				character.Move (agent.desiredVelocity, false, false);
			} else {
				character.Move (Vector3.zero, false, false);
			}

			if (aggro)
			{
				if (hunting == false)
				{
					lookAtPlayer();
					patrolNumber = Random.Range(0, patrolPoints.Length);
					agent.ResetPath();
				}
				else if(hunting)
				{ 
					huntPlayer();
				}
			}
			else
			{
				patrol();     
			}
			time = Time.deltaTime + time;
		}

		public void SetTarget(Transform target){
			this.target = target;
		}

		void checkAttack()
		{
			float dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < attackRange)
			{

				Attack();

			}
			else
			{
				attack = false;
			}
		}
		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player" && aggro == false)
			{
				player = other.gameObject;
				aggro = true;
			}

		}
		void patrol()
		{
			
			agent.speed = .5f;
			aggro = false;
			hunting = false;
			agent.SetDestination(patrolPoints[patrolNumber].transform.position);
			float patDist = Vector3.Distance(patrolPoints[patrolNumber].transform.position, transform.position);
			if(patDist<1)
			{
				patrolNumber = Random.Range(0, patrolPoints.Length);
			}

		}

		void lookAtPlayer()
		{

			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
			if(timeStart==false)
			{
				resetTime();
			}
			if (Physics.Raycast(transform.position,fwd, out hit,100))
			{
				if (hit.collider.gameObject.tag == "Player")
				{
					hunting = true;
					timeStart = false;         
				}
			}
			if (time > 5.0f && timeStart == true)
			{
				patrol();
				timeStart = false;
			}
		}
		void resetTime()
		{
			time = 0;
			timeStart = true;
		}
		void huntPlayer()
		{
			checkAttack();
			agent.SetDestination (player.transform.position);
			agent.speed = 0.5f;
			if (timeStart == false)
			{
				resetTime();
			}
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);

			if (Physics.Raycast(transform.position, fwd, out hit, 100))
			{
				//print (hit.collider.tag);
				if (hit.collider.tag == "Player")
				{
					hunting = true;
					timeStart = false;
				}
			}
			if (time > 5.0f && timeStart == true)
			{
				patrol();
				timeStart = false;
			}

		}
		public void Attack()
		{
			attack = true;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Patroller : MonoBehaviour {
	NavMeshAgent agent;

	bool patrolling;
	bool arrived;

	public Transform[] patrolTargets;
	public Transform target;
	public float lookRadius = 10f;
	
	private int destPoint;
	private float distance;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

//Follow player if player enters the enemy radius. 	
	void Update () {
		if(agent.pathPending)
		{
			return;
		}

		distance = Vector3.Distance(target.position, transform.position);
		if(distance <= lookRadius)
		{
			agent.SetDestination(target.position);
		}

		if(patrolling)
		{
			if(agent.remainingDistance < agent.stoppingDistance)
			{
				if(!arrived)
				{
					arrived = true;
					StartCoroutine("GoToNextPoint");
				}
			}
			else
			{
				arrived = false;
			}
		}
		else
		{
			StartCoroutine("GoToNextPoint");
		}
	}

//Finds next point to patroll.
	IEnumerator GoToNextPoint()
	{
		if(patrolTargets.Length == 0)
		{
			yield break;
		}
		patrolling = true;
		yield return new WaitForSeconds(2f);
		arrived = false;
		agent.destination = patrolTargets[destPoint].position;
		destPoint = Random.Range(0, patrolTargets.Length);
	}

//Draws a sphere for finding enemy radius.
	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);	
	}

}

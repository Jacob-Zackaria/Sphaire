using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Patroller : MonoBehaviour {
	NavMeshAgent agent;

	bool patrolling;

    [HideInInspector]
    public bool arrived;

	public Transform[] patrolTargets;
	public Transform target;

	[HideInInspector]
	public Transform destTransform;

	public float lookRadius = 10f;
	
	private int destPoint;
	private float distance;
	
	void Awake() {
		if(patrolTargets.Length == 0)
			return;

		destPoint = Random.Range(0, patrolTargets.Length);
		destTransform = patrolTargets[destPoint];
	}
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

//Follow player if player enters the enemy radius. 	
	void Update () {
		if(agent.pathPending)
		{
			return;
		}

		if(insideEnemyRadius())
		{
			agent.SetDestination(target.position);
			patrolling = false;

			if(agent.remainingDistance < agent.stoppingDistance)
			{
				arrived = true;
			}
			else
			{
				arrived = false;
			}
		}
		else if(patrolling)
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

		destPoint = Random.Range(0, patrolTargets.Length);
		destTransform = patrolTargets[destPoint];
		agent.destination = destTransform.position;
	}

//Draws a sphere for finding enemy radius.
	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);	
	}

	public bool insideEnemyRadius() {
		distance = Vector3.Distance(target.position, transform.position);
		return(distance <= lookRadius);
	}

}

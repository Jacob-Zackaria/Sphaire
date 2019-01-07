using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour {
	NavMeshAgent agent;
	bool patrolling;
	public Transform[] patrolTargets;
	private int destPoint;
	bool arrived;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
		if(agent.pathPending)
		{
			return;
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
}

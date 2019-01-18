using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Patroller : MonoBehaviour {
	NavMeshAgent agent;
	bool patrolling;
	public Transform[] patrolTargets;
	public Transform target;
	public Transform eye;
	public float enemyForce = 10f;
	Vector3 lastKnownPosition;
	public Slider playerHealthBar;
	public GameObject explosion;
	private int destPoint;
	private Animator anim;
	bool arrived;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		lastKnownPosition = transform.position;
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
		if(CanSeeTarget())
		{
			agent.SetDestination(target.transform.position);
			patrolling = false;
			if(agent.remainingDistance < agent.stoppingDistance)
			{
				anim.SetBool("enemyJump", true);
			}
			else
			{
				anim.SetBool("enemyJump", false);
			}
		} 
		else
		{
			anim.SetBool("enemyJump", false);
			if(!patrolling)
			{
				agent.SetDestination(lastKnownPosition);
				if(agent.remainingDistance < agent.stoppingDistance)
				{
					patrolling = true;
					StartCoroutine("GoToNextPoint");
				}
			}
		}
		//anim.SetFloat("Forward", agent.velocity.sqrMagnitude);
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

	bool CanSeeTarget()
	{
		bool canSee = false;	
		Ray ray = new Ray(eye.position, target.transform.position - eye.position);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.transform != target)
			{
				canSee = false;
			}
			else
			{
				lastKnownPosition = target.transform.position;
				canSee = true;
			}
		}
		return canSee;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player"))
		{
			playerHealthBar.value += 0.3f;
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}

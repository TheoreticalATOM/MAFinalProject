using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PigScript : MonoBehaviour {

	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;
	public float Hunger;
	public float tiredness;
	public float Health;
	public bool Alive;

	void Start () 
	{
		Hunger = 0;
		tiredness = 0;
		Health = Hunger + tiredness;
		Alive = true;
	}
	

	void Update () 
	{
		if (Alive == true)
		{
			Health = Hunger + tiredness;

			if(Hunger > 70)
			{
				//look for food
			}
			if(tiredness > 70)
			{
				//Try to Sleep
			}
			if(Health > 180)
			{
				Die();
			}
		}

	}

	void OnDrawGizmsSelcted()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
	public void Die()
	{
		Debug.Log("Pig Dead");
		Alive = false;
	}
}

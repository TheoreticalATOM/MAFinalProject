using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHealth : MonoBehaviour 
{
	public bool GrassAlive;
	public bool Terraformed;
	public GameObject  GrassMod;
	public GameObject snowMod;

	public int grassLife;
	public int Snowy;

	void Start () 
	{
		GrassMod = this.transform.GetChild(0).gameObject;
		snowMod = this.transform.GetChild(1).gameObject;
	}
	
	void Update () 
	{
		if (Terraformed == true)
		{
			grassLife = 100;
			GrassAlive = true;
			GrassMod.SetActive(true);
		}

		if (Terraformed == false)
		{
			if (GrassAlive == true)
			{
			GrassMod.SetActive(true);
			}

			if (GrassAlive == false)
			{
			GrassMod.SetActive(false);
			}

			if (grassLife >= 50)
			{
			GrassAlive = true;
			}

			if (grassLife <50)
			{
			GrassAlive = false;
			}

			if (Snowy >=50)
			{
				snowMod.SetActive(true);
			}
			if (Snowy <50)
			{
				snowMod.SetActive(false);
			}
		}
	}
 
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("TriggerEnter");
		if (other.CompareTag("TerraformSphere"))
		{
			Terraformed = true;
		}

		if (other.CompareTag("Snow"))
		{
			Snowy += 1;
		}
	}
		void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("TerraformSphere"))
		{
			Terraformed = true;
		}
	}

}

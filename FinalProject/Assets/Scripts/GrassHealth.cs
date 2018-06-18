using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHealth : MonoBehaviour 
{
	public bool GrassAlive;
	public bool Terraformed;
	public GameObject  GrassMod;

	public int grassLife;

	void Start () 
	{
		GrassMod = this.transform.GetChild(0).gameObject;
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
		}
	}
 
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("TriggerEnter");
		if (other.CompareTag("TerraformSphere"))
		{
			Terraformed = true;
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

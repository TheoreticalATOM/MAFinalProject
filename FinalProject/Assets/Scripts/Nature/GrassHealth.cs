using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHealth : MonoBehaviour 
{
	public SystemManager SystemStats;
	public bool GrassAlive;
	public bool Terraformed;
	public GameObject  GrassMod;
	public GameObject snowMod;

	public float grassLife;
	public float Snowy;
	public float watered;
	public float sunned;
	public float DrySpeed;
	public float WaterSpeed;
	public float SunSpeed;
	public float SnowSpeed;
	public float MeltSpeed;

	void Start () 
	{
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
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
			if(SystemStats.snowing == true)
			{
				snowMod.SetActive(true);
				GrassMod.SetActive(false);
			}
			if(SystemStats.sunny == true)
			{
				snowMod.SetActive(false);
				GrassMod.SetActive(true);
			}
			if(SystemStats.raining == true)
			{
				snowMod.SetActive(false);
				GrassMod.SetActive(true);
			}
			if(SystemStats.thunder == true)
			{
				snowMod.SetActive(false);
				GrassMod.SetActive(true);
			}			
		}

		if (Terraformed == false)
		{
			if(SystemStats.snowing == true)
			{
				snowMod.SetActive(true);
				//GrassMod.SetActive(false);
			}
			if(SystemStats.sunny == true)
			{
				snowMod.SetActive(false);
			//	GrassMod.SetActive(true);
			}
			if(SystemStats.raining == true)
			{
				snowMod.SetActive(false);
			//	GrassMod.SetActive(true);
			}
			if(SystemStats.thunder == true)
			{
				snowMod.SetActive(false);
			//	GrassMod.SetActive(true);
			}	
		}



	}
 
	void OnTriggerEnter(Collider other)
	{
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

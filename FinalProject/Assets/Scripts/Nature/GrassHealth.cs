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
			watered = 100;
			sunned = 100;
			if(SystemStats.snowing == true)
			{
				Snowy += SnowSpeed;
			}
			if(SystemStats.snowing == false)
			{
				Snowy -=SnowSpeed;
			}
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

			if(SystemStats.raining == true)
			{
				watered += WaterSpeed;
				if(Snowy > 0)
				{
					Snowy -= MeltSpeed;
				}
			}
			if(SystemStats.raining == false) 
			{
				watered -= DrySpeed;
			}
			if(SystemStats.sunny == true)
			{
				sunned += SunSpeed;
				if(Snowy > 0)
				{
					Snowy -= MeltSpeed;
				}
			}
			if(SystemStats.sunny == false)
			{
				sunned -= DrySpeed;
			}
			if(SystemStats.snowing == true)
			{
				Snowy += SnowSpeed;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

	public SystemManager SystemStats;
	public bool Terraformed;
	public bool TreeAlive;
	public GameObject TreeMod;
	public float watered;
	public float sunned;
	public float Snowy;
	public float SnowSpeed;
	public float MeltSpeed;
	public float WaterSpeed;
	public float SunSpeed;
	public float treeLife;

	void Start () 
	{
		TreeMod = this.transform.GetChild(0).gameObject;
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
		TreeMod.SetActive(false);

	}
	
	void Update () 
	{
		if (Terraformed == true)
		{
			TreeAlive = true;
			TreeMod.SetActive(true);
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
			if (TreeAlive == true)
			{
				TreeMod.SetActive(true);
			}
			if(treeLife >= 50)
			{
				TreeAlive = true;
			}
			if(Snowy >= 50)
			{
				//TODO: make snowtexture
			}
			if(Snowy <50)
			{
				//TODO: remove the snow texture i havent made yet
			}
			if(SystemStats.raining == true)
			{
				watered += WaterSpeed;
				if(Snowy > 0)
				{
					Snowy -= MeltSpeed;
				}
			}
			if(SystemStats.sunny == true)
			{
				sunned += SunSpeed;
				if(Snowy > 0)
				{
					Snowy -= MeltSpeed;
				}
			}

			if(SystemStats.snowing == true)
			{
				Snowy += SnowSpeed;
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

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

	public GameObject TreeModSnow;
	public Material StartTexture;
	public Material SnowTexture;


	void Start () 
	{
		TreeMod = this.transform.GetChild(0).gameObject;
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
		TreeMod.SetActive(false);
		StartTexture = TreeMod.GetComponent<MeshRenderer>().material;

	}
	
	void Update () 
	{
		if (Terraformed == true)
		{
			TreeAlive = true;
			TreeMod.SetActive(true);
			watered = 100;
			sunned = 100;

			if(SystemStats.raining == true)
			{
				TreeMod.GetComponent<MeshRenderer>().material = StartTexture;
			}
			if(SystemStats.sunny == true)
			{
				TreeMod.GetComponent<MeshRenderer>().material = StartTexture;
			}

			if(SystemStats.thunder == true)
			{
				TreeMod.GetComponent<MeshRenderer>().material = StartTexture;
			}

			if(SystemStats.snowing == true)
			{
				TreeMod.GetComponent<MeshRenderer>().material = SnowTexture;
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

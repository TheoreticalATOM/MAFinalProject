using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHeight : MonoBehaviour 
{
	public SystemManager SystemStats;
	public Vector3 MinHeight;
	public Vector3 MaxHeight;
	public GameObject Water;
	public float WaterPos;


	void Start () 
	{
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
		WaterPos = transform.position.y;
	}
	

	void Update () 
	{
		WaterPos = transform.position.y;

		if(SystemStats.raining == true && WaterPos < MaxHeight.y)
		{
			transform.position += Vector3.up * Time.deltaTime;
		}

		if(SystemStats.sunny == true && WaterPos >MinHeight.y)
		{
			transform.position -= Vector3.up * Time.deltaTime;
		}
	}
}

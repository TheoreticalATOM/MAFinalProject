using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour 
{
	public SystemManager SystemStats;
	public Light SunLight;

	void Start () 
	{
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
	}
	
	void Update () 
	{
		if (SystemStats.isNight == true)
		SunLight.color = Color.black;

		if (SystemStats.isNight == false)
		SunLight.color = Color.white;

		if (SystemStats.sunny == true)
		SunLight.intensity = 2;

		if (SystemStats.sunny == false)
		SunLight.intensity = 1;
	}
}

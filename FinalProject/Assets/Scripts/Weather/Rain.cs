using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour {

public SystemManager SystemStats;
public ParticleSystem PartRain;
	void Start () 
	{
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
	}
	

	void Update () 
	{
		if(SystemStats.raining == true)
		{
			PartRain.Play();
		}
		if(SystemStats.raining == false)
		{
			PartRain.Stop();
		}

		if(SystemStats.snowing == true)
		{
			Debug.Log("IsSnowing");
			//TODO: Snow Effects
		}

		if(SystemStats.thunder == true)
		{
			Debug.Log("IsThunder");
			//TODO: Thunder Effects
		}

		if(SystemStats.cold == true)
		{
			Debug.Log("isColdFog");
			//TODO: Fog Effect
		}
	}
}

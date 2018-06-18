using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour {

public SystemManager SystemStats;
	void Start () 
	{
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
	}
	

	void Update () 
	{
		if(SystemStats.raining == true)
		{
			Debug.Log("IsRaining");
			//TODO: Rain Effects
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

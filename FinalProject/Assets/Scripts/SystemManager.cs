using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

	public bool isNight;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(Input.GetKeyDown("n")) //NOTE: PLACEHOLDER CODE TO TOGGLE BETWEEN NIGHT AND DAY
		{
			isNight = !isNight;
		}
	}
}

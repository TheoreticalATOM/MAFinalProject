using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sleep : MonoBehaviour {
	private SystemManager SystemStats;
	public int skipSpeed;
	public bool isSkipping;

	void Start () 
	{
	SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();	
	}

	public void SleepToMorning ()
	{
		isSkipping = true;

		if (isSkipping == true)
		{
        Time.timeScale = skipSpeed; //NOTE: how quickly we skip to day.
		}
	}

	public void Update()
	{
		if(SystemStats.hour == 7)
		{
		isSkipping =false;
		Time.timeScale = 1;
		}
	}

}

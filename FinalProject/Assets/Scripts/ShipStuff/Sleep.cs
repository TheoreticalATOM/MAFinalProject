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

	void Update()
	{
		if (isSkipping == false)
		{
			Time.timeScale = 1;
		}
	}
	public void SleepToTime ()
	{
		isSkipping = true;
		StartCoroutine("SkipTime");
	}

	public void StopSleep()
	{
		isSkipping = false;
		SystemStats.SkipIcon.SetActive(false);
		SystemStats.PlayIcon.SetActive(true);	
		SystemStats.PauseIcon.SetActive(false);	
	}

	IEnumerator SkipTime()
	{
		SystemStats.SkipIcon.SetActive(true);
		SystemStats.PlayIcon.SetActive(false);	
		SystemStats.PauseIcon.SetActive(false);	

		while (isSkipping == true)
		{			
       		 Time.timeScale = skipSpeed; //NOTE: how quickly we skip to day.
			//if(SystemStats.hour == 7) //NOTE: Time to skip too.
			yield return null;
		}
	}

}

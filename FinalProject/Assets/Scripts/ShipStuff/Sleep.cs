using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sleep : MonoBehaviour {
	private SystemManager SystemStats;
	public GameObject shipPanel;
	public int skipSpeed;
	public bool isSkipping;
	public bool open = false;

	void Start () 
	{
	SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();	
	shipPanel.SetActive(false);
	}

	public void Update()
	{
		if(Input.GetKeyDown("t"))
		{
			open = !open;
		}
		if(open) //Open Panel
		{
			shipPanel.SetActive(true);
		}
		if(!open) //Close Panel
		{
			shipPanel.SetActive(false);
		}
	}

	public void SleepToMorning ()
	{
		isSkipping = true;

		if (isSkipping == true)
		{
        Time.timeScale = skipSpeed; //NOTE: how quickly we skip to day.
			if(SystemStats.hour == 7) //NOTE: Time to skip too.
			{
			isSkipping =false;
			Time.timeScale = 1;
			}
		}
	}

	public void SleepToMidnight()
	{
		isSkipping = true;

		if (isSkipping == true)
		{
        Time.timeScale = skipSpeed; 
			if(SystemStats.hour == 0)
			{
			isSkipping =false;
			Time.timeScale = 1;
			}
		}
	}

	public void SleepToMidDay()
	{
		isSkipping = true;

		if (isSkipping == true)
		{
        Time.timeScale = skipSpeed; 
			if(SystemStats.hour == 12)
			{
			isSkipping =false;
			Time.timeScale = 1;
			}
		}
	}

		public void SleepToNight()
	{
		isSkipping = true;

		if (isSkipping == true)
		{
        Time.timeScale = skipSpeed; 
			if(SystemStats.hour == 19)
			{
			isSkipping =false;
			Time.timeScale = 1;
			}
		}
	}

	public void Close()
	{
		shipPanel.SetActive(false);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevWindow : MonoBehaviour {

	public ResorceManager resourceStats;
	public bool open = false;
	public GameObject DevPanel;

	void Start () 
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
	}
	

	void Update () 
	{
		if(Input.GetKeyDown("tab"))
		{
			open = !open;
		}
		if(open) //Open Panel
		{
			DevPanel.SetActive(true);
		}
		if(!open) //Close Panel
		{
			DevPanel.SetActive(false);
		}
	}

	public void CheatCarbon()
	{
		resourceStats.CarbonStat += 100;
	}

	public void CheatPower()
	{
		resourceStats.CheatBat += 100;
	}

	public void CheatWater()
	{
		resourceStats.CheatTank += 100;
	}

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResorceManager : MonoBehaviour {
public BuildController BuildStats;
public TextMeshProUGUI CarbonStatText;
public TextMeshProUGUI PowerStatText;
public TextMeshProUGUI WaterStatText;


public int CarbonStat;
public float PowerStat;
public float WaterStat;

public int StartingCarbon;
public float ShipPower;
public float ShipWater;
public float PowerSpare;
public float PowerUsed;
public float Battery;

	void Start () 
	{
		BuildStats = GameObject.Find("MainCamera").GetComponent<BuildController>();
		ShipPower = 30;
		StartingCarbon = 30;
		ShipWater = 30;
		CarbonStat = StartingCarbon;
		PowerStat = ShipPower;
		WaterStat = ShipWater;
		PowerUsed = 0;
	}
	

	void Update () 
	{
		CarbonStatText.text = "" + CarbonStat;
		PowerStatText.text = "" + PowerSpare;
		WaterStatText.text = "" + WaterStat;

		//CarbonStat = StartingCarbon;
		PowerStat = ShipPower + Battery;
		WaterStat = ShipWater;
		PowerSpare = PowerStat - PowerUsed;

		if(Battery >= 100)
		{
			Battery = 100;
		}
	}
}

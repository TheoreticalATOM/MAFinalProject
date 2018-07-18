using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SystemManager : MonoBehaviour {

	public BuildController BuildStats;
	public ResorceManager resourceStats;
	public bool InShip;

	[Header("TIMESCALE 60 is default for a minute per hour")]
	public int TIMESCALE = 60;  //Always set back to 60

	[Header("Calander")]
	public bool isNight;
	public TextMeshProUGUI dayText;
	public TextMeshProUGUI dateText;
	public TextMeshProUGUI seasonText;
	public TextMeshProUGUI timeText;
	public double second, minute, hour, day, Season, year;

	[Header("Weather")]
	public bool sunny;
	public bool raining;
	public bool snowing;
	public bool thunder;
	public bool cold;
	public float temperature;
	public float moisture;

	[Header("Temperature Per Season")]
	public float SpringTempRangeMin;
	public float SpringTempRangeMax; 
	public float SummerTempRangeMin;
	public float SummerTempRangeMax; 
	public float AutumnTempRangeMin;
	public float AutumnTempRangeMax; 
	public float WinterTempRangeMin;
	public float WinterTempRangeMax; 
	[Header("Moisture Per Season")]
	public float SpringMoistRangeMin;
	public float SpringMoistRangeMax; 
	public float SummerMoistRangeMin;
	public float SummerMoistRangeMax; 
	public float AutumnMoistRangeMin;
	public float AutumnMoistRangeMax; 
	public float WinterMoistRangeMin;
	public float WinterMoistRangeMax; 

	void Start () 
	{
		BuildStats = GameObject.Find("MainCamera").GetComponent<BuildController>();
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();

		//SET THE CALANDER
		day = 1;
		Season = 1;
		year = 1;
		CalculateSeason();
		CalculateNight();
		CalculateWeather();
		CalculateTemp();
		Calculatemoisture();
	}
	
	void Update () 
	{
		CalculateTime();
	}

	void TextCall()
	{
		if(minute <10 && hour <10)
		{
		timeText.text =  "0" + hour + ":0" + minute;
		}
		else if (minute >=10 && hour <10)
		{
		timeText.text =  "0" + hour + ":" + minute;
		}
		else if (minute <=10 && hour >10)
		{
		timeText.text =   hour + ":0" + minute;
		}
		else if (minute >=10 && hour >10)
		{
		timeText.text =   hour + ":" + minute;
		}

	}

	void CalculateTime()
	{
		second += Time.deltaTime * TIMESCALE;

		if(second >= 60)
		{
			minute++;
			second = 0;
			TextCall();
		}
		else if (minute >= 60)
		{
			hour++;
			minute = 0;
			TextCall();
			CalculateNight();
			CalculateWeather();
			CalculateTemp();
			Calculatemoisture();
			SolarPanelCheck();
			TurbineCheck();
		}
		else if (hour >= 24)
		{
			day++;
			hour = 0;
			TextCall();
			CalculateDay();
		}
		else if (day >= 14)
		{
			CalculateSeason();
		}
		else if (Season >= 5)
		{
			Season = 1;
			year++;
		}
	}

	void CalculateDay()
	{
		if(day==1)
		{
			dayText.text = "MON";
			dateText.text = "01";
		}
		if(day==2)
		{
			dayText.text = "TUE";
			dateText.text = "02";
		}
		if(day==3)
		{
			dayText.text = "WED";
			dateText.text = "03";
		}
		if(day==4)
		{
			dayText.text = "THU";
			dateText.text = "04";
		}
		if(day==5)
		{
			dayText.text = "FRI";
			dateText.text = "05";
		}
		if(day==6)
		{
			dayText.text = "SAT";
			dateText.text = "06";
		}
		if(day==7)
		{
			dayText.text = "SUN";
			dateText.text = "07";
		}
		if(day==8)
		{
			dayText.text = "MON";
			dateText.text = "08";
		}
		if(day==9)
		{
			dayText.text = "TUE";
			dateText.text = "09";
		}
		if(day==10)
		{
			dayText.text = "WED";
			dateText.text = "10";
		}
		if(day==11)
		{
			dayText.text = "THU";
			dateText.text = "11";
		}
		if(day==12)
		{
			dayText.text = "FRI";
			dateText.text = "12";
		}
		if(day==13)
		{
			dayText.text = "SAT";
			dateText.text = "13";
		}
		if(day==14)
		{
			dayText.text = "SUN";
			dateText.text = "14";
		}
	}

	void CalculateSeason()
	{
		if(Season==1)
		{
			seasonText.text = "Spring";
		}
		if(Season==2)
		{
			seasonText.text = "Summer";
		}
		if(Season==3)
		{
			seasonText.text = "Autumn";
		}
		if(Season==4)
		{
			seasonText.text = "Winter";
		}
	}

	void CalculateNight()
	{
		if (hour >= 20)
		isNight = true;

		if (hour <= 5)
		isNight = true;

		if (hour>=6 && hour < 20)
		isNight = false;
	}

	void CalculateWeather()
	{
		if (temperature >= 50 && moisture <= 49) // Make it Sunny
		{
		sunny = true;
		raining = false;
		snowing = false;
		thunder = false;
		cold = false;
		}

		else if (temperature >= 50 && moisture >= 50) // Make it Thunder
		{
		sunny = false;
		raining = false;
		snowing = false;
		thunder = true;
		cold = false;
		}

		else if (temperature <= 0 && moisture >= 50) // Make it Snow
		{
		sunny = false;
		raining = false;
		snowing = true;
		thunder = false;
		cold = true;
		}

		else if (temperature >= 1 && temperature <= 49 && moisture >= 50) // Make it Rain , Not Cold Not Sunny 
		{
		sunny = false;
		raining = true;
		snowing = false;
		thunder = false;
		cold = false;
		}

		else if (temperature <=0 && moisture <= 49) // Cold No Snow
		{
		sunny = false;
		raining = false;
		snowing = false;
		thunder = false;
		cold = true;
		}

	}

	void CalculateTemp()
	{
		if(Season == 1)//Spring
		{
			temperature = Random.Range(SpringTempRangeMin, SpringTempRangeMax);
		}
		if(Season == 2)//Summer
		{
			temperature = Random.Range(SummerTempRangeMin, SummerTempRangeMax);
		}
		if(Season == 3)//Autumn
		{
			temperature = Random.Range(AutumnTempRangeMin, AutumnTempRangeMax);
		}
		if(Season == 4)//Winter
		{
			temperature = Random.Range(WinterTempRangeMin, WinterTempRangeMax);
		}
	}
		void Calculatemoisture()
	{
		if(Season == 1)//Spring
		{
			moisture = Random.Range(SpringMoistRangeMin, SpringMoistRangeMax);
		}
		if(Season == 2)//Summer
		{
			moisture = Random.Range(SummerMoistRangeMin, SummerMoistRangeMax);
		}
		if(Season == 3)//Autumn
		{
			moisture = Random.Range(AutumnMoistRangeMin, AutumnMoistRangeMax);
		}
		if(Season == 4)//Winter
		{
			moisture = Random.Range(WinterMoistRangeMin, WinterMoistRangeMax);
		}
	}

	void SolarPanelCheck()
	{
		if(BuildStats.SolarFarmBuilt == true)
		{
			resourceStats.Battery += 10;
		}
	}

	void TurbineCheck()
	{
		if(BuildStats.TurbineBuilt == true)
		{
			resourceStats.BatteryWind += 10;
		}
	}
}

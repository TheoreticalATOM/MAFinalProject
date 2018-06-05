using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SystemManager : MonoBehaviour {

	public bool isNight;
	//public int day;
//	public int season;
	//public int date;
//	public int time;

	public TextMeshProUGUI dayText;
	public TextMeshProUGUI dateText;
	public TextMeshProUGUI seasonText;
	public TextMeshProUGUI timeText;

	[Header("TIMESCALE 60 is default for a minute per hour")]
	public int TIMESCALE = 60;  //Always set back to 60

private double minute, hour, day, second, Season, year;
	void Start () 
	{
		//SET THE CALANDER
		day = 1;
		Season = 1;
		year = 1;
		CalculateSeason();
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
}

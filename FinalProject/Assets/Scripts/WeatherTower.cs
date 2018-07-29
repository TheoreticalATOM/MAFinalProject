using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeatherTower : MonoBehaviour {
	private SystemManager SystemStats;
	public TextMeshProUGUI temperature;
	public TextMeshProUGUI moisture;
	public TextMeshProUGUI weather;


	void Start () 
	{
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
	}
	
	void Update () 
	{
		temperature.text = "Temperature: " + SystemStats.temperature.ToString();
		moisture.text = "Moisture: " + SystemStats.moisture.ToString();
		weather.text = "Weather: " + SystemStats.currentWeather;
	}
}

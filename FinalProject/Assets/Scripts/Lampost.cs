using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampost : MonoBehaviour //If night turn light on
{
	public SystemManager NightCheck;
	public bool lightOn;

	public GameObject Lamplight;

	void Start () 
	{
		NightCheck = GameObject.Find("Manager").GetComponent<SystemManager>();
	}
	

	void Update () 
	{
		if(NightCheck.isNight == true)
		{
			lightOn = true;
		}

		if(NightCheck.isNight == false)
		{
			lightOn = false;
		}

		if(lightOn == true)
		{
		Lamplight.SetActive(true);

		}

		if(lightOn == false)
		{
		Lamplight.SetActive(false);
		}
	}
}

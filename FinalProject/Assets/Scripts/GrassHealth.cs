using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHealth : MonoBehaviour 
{
	public bool GrassAlive;
	public GameObject  GrassMod;

	public int grassLife;

	void Start () 
	{
		GrassMod = this.transform.GetChild(0).gameObject;
	}
	
	void Update () 
	{
		if (GrassAlive == true)
		{
			GrassMod.SetActive(true);
		}

		if (GrassAlive == false)
		{
			GrassMod.SetActive(false);
		}

		if (grassLife >= 50)
		{
			GrassAlive = true;
		}

		if (grassLife <50)
		{
			GrassAlive = false;
		}
	}
}

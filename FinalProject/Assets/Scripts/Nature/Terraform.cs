using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terraform : MonoBehaviour 
{
	//public float scallingFactor;
	public float TimeScale = 0.5f;
	public Vector3 InitialScale;
	public Vector3 FinalScale1;
	public Vector3 FinalScale2;
	public Vector3 FinalScale3;
	public Vector3 FinalScale4;
	public Vector3 FinalScale5;
	public int sphereLevel;

	public GameObject UpgradeButton; //Note: Both Buttons the same but different functions
	public GameObject CantUpgrade;
	public GameObject FullyUpgraded;

	public ResorceManager resourceStats;

	void Start ()
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
		sphereLevel = 0;
		FullyUpgraded.SetActive(false);
		CantUpgrade.SetActive(false);	
	}
	public void IncreaseSize()
	{
		if (sphereLevel == 0)
		{
			if(resourceStats.CarbonStat >= 0 && resourceStats.PowerSpare >= 0)
			{
				StartCoroutine("ScaleSphere1");
			}
		}

		if (sphereLevel == 1)
		{
			if(resourceStats.CarbonStat >= 25 && resourceStats.PowerSpare >= 30)
			{
				resourceStats.CarbonStat -= 25;
				resourceStats.PowerUsed += 30;
				StartCoroutine("ScaleSphere2");				
			}
		}

		if (sphereLevel == 2)
		{
			if(resourceStats.CarbonStat >= 40 && resourceStats.PowerSpare >= 60)
			{
				resourceStats.CarbonStat -= 40;
				resourceStats.PowerUsed += 60;
				StartCoroutine("ScaleSphere3");				
			}
		}

		if (sphereLevel == 3)
		{
			if(resourceStats.CarbonStat >= 80 && resourceStats.PowerSpare >= 100)
			{
				resourceStats.CarbonStat -= 80;
				resourceStats.PowerUsed += 100;
				StartCoroutine("ScaleSphere4");				
			}
		}

		if (sphereLevel == 4)
		{
			if(resourceStats.CarbonStat >= 100 && resourceStats.PowerSpare >= 120)
			{
				resourceStats.CarbonStat -= 100;
				resourceStats.PowerUsed += 120;
				StartCoroutine("ScaleSphere5");				
			}
		}
	}

	IEnumerator ScaleSphere1()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(InitialScale, FinalScale1, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale1;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	}


		IEnumerator ScaleSphere2()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale1, FinalScale2, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale2;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	}


		IEnumerator ScaleSphere3()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale2, FinalScale3, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale3;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	}


		IEnumerator ScaleSphere4()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale3, FinalScale4, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale4;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	}


		IEnumerator ScaleSphere5()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale4, FinalScale5, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale5;
	sphereLevel += 1;
	FullyUpgraded.SetActive(true);
	}





}

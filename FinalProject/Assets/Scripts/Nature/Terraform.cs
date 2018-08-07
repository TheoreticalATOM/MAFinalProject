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
	public Vector3 FinalScale6;
	public Vector3 FinalScale7;
	public Vector3 FinalScale8;
	public Vector3 FinalScale9;
	public Vector3 FinalScale10;
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
			if(resourceStats.CarbonStat >= 0 && resourceStats.PowerSpare >= 0 && resourceStats.WaterStat >= 0)
			{
				StartCoroutine("ScaleSphere1");
			}
		}

		if (sphereLevel == 1)
		{
			if(resourceStats.CarbonStat >= 25 && resourceStats.PowerSpare >= 30 && resourceStats.WaterStat >= 50)
			{
				resourceStats.CarbonStat -= 25;
				resourceStats.PowerUsed += 30;
				resourceStats.WaterStat -= 50;
				StartCoroutine("ScaleSphere2");				
			}
		}

		if (sphereLevel == 2)
		{
			if(resourceStats.CarbonStat >= 40 && resourceStats.PowerSpare >= 60 && resourceStats.WaterStat >= 80)
			{
				resourceStats.CarbonStat -= 40;
				resourceStats.PowerUsed += 60;
				resourceStats.WaterStat -= 80;
				StartCoroutine("ScaleSphere3");				
			}
		}

		if (sphereLevel == 3)
		{
			if(resourceStats.CarbonStat >= 60 && resourceStats.PowerSpare >= 80 && resourceStats.WaterStat >= 110)
			{
				resourceStats.CarbonStat -= 60;
				resourceStats.PowerUsed += 80;
				resourceStats.WaterStat -= 110;
				StartCoroutine("ScaleSphere4");				
			}
		}

		if (sphereLevel == 4)
		{
			if(resourceStats.CarbonStat >= 80 && resourceStats.PowerSpare >= 100 && resourceStats.WaterStat >= 150)
			{
				resourceStats.CarbonStat -= 80;
				resourceStats.PowerUsed += 100;
				resourceStats.WaterStat -= 150;
				StartCoroutine("ScaleSphere5");				
			}
		}
		if (sphereLevel == 5)
		{
			if(resourceStats.CarbonStat >= 100 && resourceStats.PowerSpare >= 120 && resourceStats.WaterStat >= 170)
			{
				resourceStats.CarbonStat -= 100;
				resourceStats.PowerUsed += 120;
				resourceStats.WaterStat -= 170;
				StartCoroutine("ScaleSphere6");				
			}
		}
		if (sphereLevel == 6)
		{
			if(resourceStats.CarbonStat >= 120 && resourceStats.PowerSpare >= 140 && resourceStats.WaterStat >= 200)
			{
				resourceStats.CarbonStat -= 120;
				resourceStats.PowerUsed += 140;
				resourceStats.WaterStat -= 200;
				StartCoroutine("ScaleSphere7");				
			}
		}
		if (sphereLevel == 7)
		{
			if(resourceStats.CarbonStat >= 140 && resourceStats.PowerSpare >= 160 && resourceStats.WaterStat >= 220)
			{
				resourceStats.CarbonStat -= 140;
				resourceStats.PowerUsed += 160;
				resourceStats.WaterStat -= 220;
				StartCoroutine("ScaleSphere8");				
			}
		}
		if (sphereLevel == 8)
		{
			if(resourceStats.CarbonStat >= 160 && resourceStats.PowerSpare >= 180 && resourceStats.WaterStat >= 250)
			{
				resourceStats.CarbonStat -= 160;
				resourceStats.PowerUsed += 180;
				resourceStats.WaterStat -= 250;
				StartCoroutine("ScaleSphere9");				
			}
		}
		if (sphereLevel == 9)
		{
			if(resourceStats.CarbonStat >= 180 && resourceStats.PowerSpare >= 200 && resourceStats.WaterStat >= 300)
			{
				resourceStats.CarbonStat -= 180;
				resourceStats.PowerUsed += 200;
				resourceStats.WaterStat -= 300;
				StartCoroutine("ScaleSphere10");				
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
	GameGrind.Journal.Increment("Dome Level 1", 1);
	GameGrind.Journal.Increment("Dome Level 2", 1);
	GameGrind.Journal.Increment("Dome Level 3", 1);
	GameGrind.Journal.Increment("Dome Level 4", 1);
	GameGrind.Journal.Increment("Dome Level 5", 1);
	GameGrind.Journal.Increment("Dome Level 6", 1);
	GameGrind.Journal.Increment("Dome Level 7", 1);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);

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
	GameGrind.Journal.Increment("Dome Level 2", 1);
	GameGrind.Journal.Increment("Dome Level 3", 1);
	GameGrind.Journal.Increment("Dome Level 4", 1);
	GameGrind.Journal.Increment("Dome Level 5", 1);
	GameGrind.Journal.Increment("Dome Level 6", 1);
	GameGrind.Journal.Increment("Dome Level 7", 1);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
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
	GameGrind.Journal.Increment("Dome Level 3", 1);
	GameGrind.Journal.Increment("Dome Level 4", 1);
	GameGrind.Journal.Increment("Dome Level 5", 1);
	GameGrind.Journal.Increment("Dome Level 6", 1);
	GameGrind.Journal.Increment("Dome Level 7", 1);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
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
	GameGrind.Journal.Increment("Dome Level 4", 1);
	GameGrind.Journal.Increment("Dome Level 5", 1);
	GameGrind.Journal.Increment("Dome Level 6", 1);
	GameGrind.Journal.Increment("Dome Level 7", 1);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
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
	UpgradeButton.SetActive(true);
	GameGrind.Journal.Increment("Dome Level 5", 1);
	GameGrind.Journal.Increment("Dome Level 6", 1);
	GameGrind.Journal.Increment("Dome Level 7", 1);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
	}

	IEnumerator ScaleSphere6()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale5, FinalScale6, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale6;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	GameGrind.Journal.Increment("Dome Level 6", 1);
	GameGrind.Journal.Increment("Dome Level 7", 1);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
	}
	IEnumerator ScaleSphere7()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale6, FinalScale7, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale7;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	GameGrind.Journal.Increment("Dome Level 7", 1);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
	}

	IEnumerator ScaleSphere8()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale7, FinalScale8, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale8;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	GameGrind.Journal.Increment("Dome Level 8", 1);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
	}
	IEnumerator ScaleSphere9()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale8, FinalScale9, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale9;
	sphereLevel += 1;
	UpgradeButton.SetActive(true);
	GameGrind.Journal.Increment("Dome Level 9", 1);
	GameGrind.Journal.Increment("Dome Level 10", 1);
	}
	IEnumerator ScaleSphere10()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(FinalScale9, FinalScale10, progress);
		progress += Time.deltaTime * TimeScale;
		UpgradeButton.SetActive(false);
		yield return null;
	}
	transform.localScale = FinalScale10;
	sphereLevel += 1;
	FullyUpgraded.SetActive(true);
	GameGrind.Journal.Increment("Dome Level 10", 1);
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildController : MonoBehaviour {
public ResorceManager resourceStats;

[Header("UI Panel")]
public GameObject BuildPanel;
public GameObject DockPanelStuff;
public GameObject WaterTankPanelStuff;
public GameObject RadioTowerPanelStuff;
public GameObject SolarFarmPanelStuff;
public GameObject TurbinePanelStuff;
public GameObject DropPodAnimalStuff;

[Header("Build Spots")]
public GameObject BuildSpotDock;
public GameObject BuildSpotTank;
public GameObject BuildSpotTower;
public GameObject BuildSpotSolar;
public GameObject BuildSpotTurbine;
public GameObject BuildSpotDropPodAnimal;

[Header("Building Models")]
public GameObject FishingDockMod;
public GameObject WaterTankMod;
public GameObject RadioTowerMod;
public GameObject SolarFarmMod;
public GameObject TurbineMod;
public GameObject AnimalDropPodMod;

[Header("Current Selected Building")]
public bool DockActive;
public bool TankActive;
public bool TowerActive;
public bool SolarFarmActive;
public bool TurbineActive;
public bool dropPodAnimalActive;

[Header("Is Building Built")]
public bool DockBuilt;
public bool TankBuilt;
public bool TowerBuilt;
public bool SolarFarmBuilt;
public bool TurbineBuilt;

[Header("Animal Drop Pod Stuff")]
public Vector3 Startposition;
public Vector3 EndPosition;
public float TimeScale;
public bool dropPodAnimilLanded; 
public GameObject DropPodAText;


	void Start () 
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
		BuildPanel.SetActive(false);
		DockPanelStuff.SetActive(false);
		WaterTankPanelStuff.SetActive(false);
		RadioTowerPanelStuff.SetActive(false);
		SolarFarmPanelStuff.SetActive(false);
		TurbinePanelStuff.SetActive(false);
		DropPodAnimalStuff.SetActive(false);

		DockActive = false;
		TankActive = false;
		TowerActive = false;
		SolarFarmActive = false;
		TurbineActive = false;
		dropPodAnimalActive = false;

		BuildSpotDock.SetActive(true);
		BuildSpotTank.SetActive(true);
		BuildSpotTower.SetActive(true);
		BuildSpotSolar.SetActive(true);
		BuildSpotTurbine.SetActive(true);
		BuildSpotDropPodAnimal.SetActive(true);

		FishingDockMod.SetActive(false);
		WaterTankMod.SetActive(false);
		RadioTowerMod.SetActive(false);
		SolarFarmMod.SetActive(false);
		TurbineMod.SetActive(false);
		AnimalDropPodMod.SetActive(false);

		dropPodAnimilLanded = false;
		DropPodAText.SetActive(false);
	}
	

	void Update () 
	{
        if (Input.GetMouseButtonDown(0)) 
			{
                 RaycastHit  hit;
                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
                  if (Physics.Raycast(ray, out hit))
				{
                    if (hit.transform.name == "BuildSpot_Dock" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(true);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(false);
						SolarFarmPanelStuff.SetActive(false);
						TurbinePanelStuff.SetActive(false);
						DropPodAnimalStuff.SetActive(false);
						DockActive = true;
						TankActive = false;
						TowerActive = false;
						SolarFarmActive = false;
						TurbineActive = false;
						dropPodAnimalActive = false;
					}
					if (hit.transform.name == "BuildSpot_WaterTank" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(true);
						RadioTowerPanelStuff.SetActive(false);
						SolarFarmPanelStuff.SetActive(false);
						TurbinePanelStuff.SetActive(false);
						DropPodAnimalStuff.SetActive(false);
						DockActive = false;
						TankActive = true;
						TowerActive = false;
						SolarFarmActive = false;
						TurbineActive = false;
						dropPodAnimalActive = false;
					}
					if (hit.transform.name == "BuildSpot_RadioTower" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(true);
						SolarFarmPanelStuff.SetActive(false);
						TurbinePanelStuff.SetActive(false);
						DropPodAnimalStuff.SetActive(false);
						DockActive = false;
						TankActive = false;
						TowerActive = true;
						SolarFarmActive = false;
						TurbineActive = false;
						dropPodAnimalActive = false;
					}
					if (hit.transform.name == "BuildSpot_SolarFarm" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(false);
						SolarFarmPanelStuff.SetActive(true);
						TurbinePanelStuff.SetActive(false);
						DropPodAnimalStuff.SetActive(false);
						DockActive = false;
						TankActive = false;
						TowerActive = false;
						SolarFarmActive = true;
						TurbineActive = false;
						dropPodAnimalActive = false;
					}
					if (hit.transform.name == "BuildSpot_WindTurbine" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(false);
						SolarFarmPanelStuff.SetActive(false);
						TurbinePanelStuff.SetActive(true);
						DropPodAnimalStuff.SetActive(false);
						DockActive = false;
						TankActive = false;
						TowerActive = false;
						SolarFarmActive = false;
						TurbineActive = true;
						dropPodAnimalActive = false;
					}
					if (hit.transform.name == "BuildSpot_DropPod_Animal" && TowerBuilt == true)
					{
						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(false);
						SolarFarmPanelStuff.SetActive(false);
						TurbinePanelStuff.SetActive(false);
						DropPodAnimalStuff.SetActive(true);
						DockActive = false;
						TankActive = false;
						TowerActive = false;
						SolarFarmActive = false;
						TurbineActive = false;
						dropPodAnimalActive = true;
					}

				}
			}

	}

	public void Close()
	{
		BuildPanel.SetActive(false);
		DockPanelStuff.SetActive(false);
		WaterTankPanelStuff.SetActive(false);
		RadioTowerPanelStuff.SetActive(false);
		SolarFarmPanelStuff.SetActive(false);
		TurbinePanelStuff.SetActive(false);
		DockActive = false;
		TankActive = false;
		TowerActive = false;
		SolarFarmActive = false;
		TurbineActive = false;
	}

	public void Build()
	{
		if(DockActive == true)
		{
			if(resourceStats.CarbonStat >= 10 && resourceStats.PowerSpare >= 5)
			{
				resourceStats.CarbonStat -= 10;
				resourceStats.PowerUsed += 5;
				FishingDockMod.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotDock.SetActive(false);
				DockBuilt = true;
			}
		}

		if(TankActive == true)
		{
			if(resourceStats.CarbonStat >= 20 && resourceStats.PowerSpare >= 5)
			{
				resourceStats.CarbonStat -= 20;
				resourceStats.PowerUsed += 5;
				WaterTankMod.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotTank.SetActive(false);
				TankBuilt = true;
			}
		}

		if(TowerActive == true)
		{
			if(resourceStats.CarbonStat >= 10 && resourceStats.PowerSpare >= 5)
			{
				resourceStats.CarbonStat -= 10;
				resourceStats.PowerUsed += 5;
				RadioTowerMod.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotTower.SetActive(false);
				TowerBuilt = true;
			}
		}

		if(SolarFarmActive == true)
		{
			if(resourceStats.CarbonStat >= 30 && resourceStats.PowerSpare >= 0)
			{
				resourceStats.CarbonStat -= 30;
				//resourceStats.PowerUsed += 5;
				SolarFarmMod.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotSolar.SetActive(false);
				SolarFarmBuilt = true;
			}
		}

		if(TurbineActive == true)
		{
			if(resourceStats.CarbonStat >= 30 && resourceStats.PowerSpare >= 0)
			{
				resourceStats.CarbonStat -= 30;
				//resourceStats.PowerUsed += 5;
				TurbineMod.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotTurbine.SetActive(false);
				TurbineBuilt = true;
			}
		}

		if(dropPodAnimalActive == true)
		{
			if(resourceStats.CarbonStat >= 0 && resourceStats.PowerSpare >= 0 && resourceStats.WaterStat >= 50)
			{
				resourceStats.WaterStat -= 50;
			/*	AnimalDropPodMod.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotDropPodAnimal.SetActive(false);
			*/
				StartCoroutine ("DropPodA");
			}
		}
	}

	IEnumerator DropPodA()
	{
		DropPodAText.SetActive(true);
		yield return new WaitForSeconds(1440);	

	float progress = 0;
	AnimalDropPodMod.SetActive(true);
	while(progress <=1)
	{
		AnimalDropPodMod.transform.position = Vector3.Lerp(Startposition, EndPosition, progress);
		progress += Time.deltaTime * TimeScale;

		yield return null;
	}
		dropPodAnimilLanded = true;
		BuildSpotDropPodAnimal.SetActive(false);
		DropPodAText.SetActive(false);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildController : MonoBehaviour {
public ResorceManager resourceStats;
public GameObject BuildPanel;
public GameObject DockPanelStuff;
public GameObject WaterTankPanelStuff;
public GameObject RadioTowerPanelStuff;
public GameObject SolarFarmPanelStuff;
public GameObject BuildSpotDock;
public GameObject BuildSpotTank;
public GameObject BuildSpotTower;
public GameObject BuildSpotSolar;
public GameObject FishingDockMod;
public GameObject WaterTankMod;
public GameObject RadioTowerMod;
public GameObject SolarFarmMod;
public bool DockActive;
public bool TankActive;
public bool TowerActive;
public bool SolarFarmActive;
public bool DockBuilt;
public bool TankBuilt;
public bool TowerBuilt;
public bool SolarFarmBuilt;


	void Start () 
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
		BuildPanel.SetActive(false);
		DockPanelStuff.SetActive(false);
		WaterTankPanelStuff.SetActive(false);
		RadioTowerPanelStuff.SetActive(false);
		SolarFarmPanelStuff.SetActive(false);
		DockActive = false;
		TankActive = false;
		TowerActive = false;
		SolarFarmActive = false;
		BuildSpotDock.SetActive(true);
		BuildSpotTank.SetActive(true);
		BuildSpotTower.SetActive(true);
		BuildSpotSolar.SetActive(true);
		FishingDockMod.SetActive(false);
		WaterTankMod.SetActive(false);
		RadioTowerMod.SetActive(false);
		SolarFarmMod.SetActive(false);
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
						DockActive = true;
						TankActive = false;
						TowerActive = false;
						SolarFarmActive = false;
					}
					if (hit.transform.name == "BuildSpot_WaterTank" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(true);
						RadioTowerPanelStuff.SetActive(false);
						SolarFarmPanelStuff.SetActive(false);
						DockActive = false;
						TankActive = true;
						TowerActive = false;
						SolarFarmActive = false;

					}
					if (hit.transform.name == "BuildSpot_RadioTower" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(true);
						SolarFarmPanelStuff.SetActive(false);
						DockActive = false;
						TankActive = false;
						TowerActive = true;
						SolarFarmActive = false;
					}
					if (hit.transform.name == "BuildSpot_SolarFarm" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(false);
						SolarFarmPanelStuff.SetActive(true);
						DockActive = false;
						TankActive = false;
						TowerActive = false;
						SolarFarmActive = true;
					}
				}
			}
		
		if(DockBuilt == true)
		{
			//Nothing Yet
		}

		if(TankBuilt == true)
		{
			//TODO: Make this go Up OverTime to a set amount then stop. untill used then go up again.
			resourceStats.WaterStat += 40;
		}
			
		if(TowerBuilt == true)
		{
			//Nothing Yet
		}

	}

	public void Close()
	{
		BuildPanel.SetActive(false);
		DockPanelStuff.SetActive(false);
		WaterTankPanelStuff.SetActive(false);
		RadioTowerPanelStuff.SetActive(false);
		DockActive = false;
		TankActive = false;
		TowerActive = false;
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
	}
}

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
public GameObject BuildSpotDock;
public GameObject BuildSpotTank;
public GameObject BuildSpotTower;
public GameObject FishingDock;
public GameObject WaterTank;
public GameObject RadioTower;
public bool DockActive;
public bool TankActive;
public bool TowerActive;
public bool DockBuilt;
public bool TankBuilt;
public bool TowerBuilt;


	void Start () 
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
		BuildPanel.SetActive(false);
		DockPanelStuff.SetActive(false);
		WaterTankPanelStuff.SetActive(false);
		RadioTowerPanelStuff.SetActive(false);
		DockActive = false;
		TankActive = false;
		TowerActive = false;
		BuildSpotDock.SetActive(true);
		BuildSpotTank.SetActive(true);
		BuildSpotTower.SetActive(true);
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
						DockActive = true;
						TankActive = false;
						TowerActive = false;
						DockBuilt = true;
					}
					if (hit.transform.name == "BuildSpot_WaterTank" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(true);
						RadioTowerPanelStuff.SetActive(false);
						DockActive = false;
						TankActive = true;
						TowerActive = false;
						TankBuilt = true;

					}
					if (hit.transform.name == "BuildSpot_RadioTower" )
					{
 						BuildPanel.SetActive(true);
						DockPanelStuff.SetActive(false);
						WaterTankPanelStuff.SetActive(false);
						RadioTowerPanelStuff.SetActive(true);
						DockActive = false;
						TankActive = false;
						TowerActive = true;
						TowerBuilt = true;
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
				FishingDock.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotDock.SetActive(false);
			}
		}

		if(TankActive == true)
		{
			if(resourceStats.CarbonStat >= 20 && resourceStats.PowerSpare >= 5)
			{
				resourceStats.CarbonStat -= 20;
				resourceStats.PowerUsed += 5;
				WaterTank.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotTank.SetActive(false);
			}
		}

		if(TowerActive == true)
		{
			if(resourceStats.CarbonStat >= 10 && resourceStats.PowerSpare >= 5)
			{
				resourceStats.CarbonStat -= 10;
				resourceStats.PowerUsed += 5;
				RadioTower.SetActive(true);
				BuildPanel.SetActive(false);
				BuildSpotTower.SetActive(false);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {

	public GameObject TerraformPanel;
	public GameObject ShipPanel;
	public GameObject weatherpanel;


	void Start () 
	{
		ShipPanel.SetActive(false);
		TerraformPanel.SetActive(false);
		weatherpanel.SetActive(false);
	}
	

	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
			{
                 RaycastHit  hit;
                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
                  if (Physics.Raycast(ray, out hit))
				{
                    if (hit.transform.name == "SpaceStation" )
					{
						ShipPanel.SetActive(true);
					}
				}
			}
	}


	public void openTerraformDome()
	{
		TerraformPanel.SetActive(true);
		ShipPanel.SetActive(false);
	}

	public void closeTerraformDome()
	{
		TerraformPanel.SetActive(false);
		ShipPanel.SetActive(false);
		weatherpanel.SetActive(false);
	}

	public void openWeatherPanel()
	{
		weatherpanel.SetActive(true);
		TerraformPanel.SetActive(false);
		ShipPanel.SetActive(false);
	}

}

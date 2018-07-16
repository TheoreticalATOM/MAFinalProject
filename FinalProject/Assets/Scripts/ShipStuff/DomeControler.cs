using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DomeControler : MonoBehaviour {

	public GameObject TerraformPanel;
	public bool open = false;
	public ResorceManager resourceStats;
	public Terraform TerraformStats;
	public TextMeshProUGUI currentDomeLevelText;
	public TextMeshProUGUI currentDomeSizeText;
	public TextMeshProUGUI carboncostToUpgradeText;
	public TextMeshProUGUI PowerCostToUpgrageText;

	void Start () 
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
		TerraformStats = GameObject.Find("Dome").GetComponent<Terraform>();
	}

	void Update () 
	{
		if(Input.GetKeyDown("r"))
		{
			open = !open;
		}
		if(open) //Open Panel
		{
			TerraformPanel.SetActive(true);
		}
		if(!open) //Close Panel
		{
			TerraformPanel.SetActive(false);
		}

		currentDomeLevelText.text = "Dome Level " + TerraformStats.sphereLevel;
		if(TerraformStats.sphereLevel == 0)
		{
			currentDomeSizeText.text = "Dome Size 0";
			carboncostToUpgradeText.text = "Carbon = Free";
			PowerCostToUpgrageText.text = "Power Usage = Free";
		}
		if(TerraformStats.sphereLevel == 1)
		{
			currentDomeSizeText.text = "Dome Size 10";
			carboncostToUpgradeText.text = "Carbon = 25";
			PowerCostToUpgrageText.text = "Power Usage = 30";
		}
		if(TerraformStats.sphereLevel == 2)
		{
			currentDomeSizeText.text = "Dome Size 20";
			carboncostToUpgradeText.text = "Carbon = 40";
			PowerCostToUpgrageText.text = "Power Usage = 60";
		}
		if(TerraformStats.sphereLevel == 3)
		{
			currentDomeSizeText.text = "Dome Size 30";
			carboncostToUpgradeText.text = "Carbon = 60";
			PowerCostToUpgrageText.text = "Power Usage = 80";
		}
		if(TerraformStats.sphereLevel == 4)
		{
			currentDomeSizeText.text = "Dome Size 40";
			carboncostToUpgradeText.text = "Carbon = 80";
			PowerCostToUpgrageText.text = "Power Usage = 100";
		}
		if(TerraformStats.sphereLevel == 5)
		{
			currentDomeSizeText.text = "Dome Size 50";
			carboncostToUpgradeText.text = "Carbon = 100";
			PowerCostToUpgrageText.text = "Power Usage = 120";
		}



	}

}

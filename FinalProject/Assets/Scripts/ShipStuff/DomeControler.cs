using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DomeControler : MonoBehaviour {

	public GameObject TerraformPanel;
	public ResorceManager resourceStats;
	public Terraform TerraformStats;
	public TextMeshProUGUI currentDomeLevelText;
	public TextMeshProUGUI currentDomeSizeText;
	public TextMeshProUGUI carboncostToUpgradeText;
	public TextMeshProUGUI PowerCostToUpgrageText;
	public TextMeshProUGUI WaterCostToUpgradeText;

	void Start () 
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
		TerraformStats = GameObject.Find("Dome").GetComponent<Terraform>();
	}

	void Update () 
	{
		currentDomeLevelText.text = "Dome Level " + TerraformStats.sphereLevel;
		if(TerraformStats.sphereLevel == 0)
		{
			currentDomeSizeText.text = "Dome Size 0";
			carboncostToUpgradeText.text = "Carbon Cost = Free";
			PowerCostToUpgrageText.text = "Power Usage = Free";
			WaterCostToUpgradeText.text = "Water Cost = Free";
		}
		if(TerraformStats.sphereLevel == 1)
		{
			currentDomeSizeText.text = "Dome Size 10";
			carboncostToUpgradeText.text = "Carbon Cost = 25";
			PowerCostToUpgrageText.text = "Power Usage = 30";
			WaterCostToUpgradeText.text = "Water Cost = 50";
		}
		if(TerraformStats.sphereLevel == 2)
		{
			currentDomeSizeText.text = "Dome Size 20";
			carboncostToUpgradeText.text = "Carbon Cost = 40";
			PowerCostToUpgrageText.text = "Power Usage = 60";
			WaterCostToUpgradeText.text = "Water Cost = 80";
		}
		if(TerraformStats.sphereLevel == 3)
		{
			currentDomeSizeText.text = "Dome Size 30";
			carboncostToUpgradeText.text = "Carbon Cost = 60";
			PowerCostToUpgrageText.text = "Power Usage = 80";
			WaterCostToUpgradeText.text = "Water Cost = 110";
		}
		if(TerraformStats.sphereLevel == 4)
		{
			currentDomeSizeText.text = "Dome Size 40";
			carboncostToUpgradeText.text = "Carbon Cost = 80";
			PowerCostToUpgrageText.text = "Power Usage = 100";
			WaterCostToUpgradeText.text = "Water Cost = 150";
		}
		if(TerraformStats.sphereLevel == 5)
		{
			currentDomeSizeText.text = "Dome Size 50";
			carboncostToUpgradeText.text = "";
			PowerCostToUpgrageText.text = "";
			WaterCostToUpgradeText.text = "";
		}

	}
}

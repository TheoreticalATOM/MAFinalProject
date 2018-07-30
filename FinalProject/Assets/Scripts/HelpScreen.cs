using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour {


	public GameObject LorePanel;
	public GameObject ControllPanel;
	public GameObject ShipInfoPanel;
	public GameObject resourcesPanel;
	public GameObject naturePanel;
	public GameObject wildlifePanel;
	public GameObject CalanderPanel;


	void Start () 
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(false);
		ShipInfoPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		naturePanel.SetActive(false);
		wildlifePanel.SetActive(false);
		CalanderPanel.SetActive(false);
	}
	

	void Update () 
	{

	}

	public void LoreTog()
	{
		LorePanel.SetActive(true);
		ControllPanel.SetActive(false);
		ShipInfoPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		naturePanel.SetActive(false);
		wildlifePanel.SetActive(false);
		CalanderPanel.SetActive(false);
	}

	public void ControlTog()
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(true);
		ShipInfoPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		naturePanel.SetActive(false);
		wildlifePanel.SetActive(false);
		CalanderPanel.SetActive(false);
	}
		public void ShipTog()
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(false);
		ShipInfoPanel.SetActive(true);
		resourcesPanel.SetActive(false);
		naturePanel.SetActive(false);
		wildlifePanel.SetActive(false);
		CalanderPanel.SetActive(false);
	}
		public void resourceTog()
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(false);
		ShipInfoPanel.SetActive(false);
		resourcesPanel.SetActive(true);
		naturePanel.SetActive(false);
		wildlifePanel.SetActive(false);
		CalanderPanel.SetActive(false);
	}
		public void natureTog()
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(false);
		ShipInfoPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		naturePanel.SetActive(true);
		wildlifePanel.SetActive(false);
		CalanderPanel.SetActive(false);
	}
		public void WildlifeTog()
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(false);
		ShipInfoPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		naturePanel.SetActive(false);
		wildlifePanel.SetActive(true);
		CalanderPanel.SetActive(false);
	}
		public void CalandarTog()
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(false);
		ShipInfoPanel.SetActive(false);
		resourcesPanel.SetActive(false);
		naturePanel.SetActive(false);
		wildlifePanel.SetActive(false);
		CalanderPanel.SetActive(true);
	}



}

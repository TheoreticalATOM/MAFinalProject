using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour {


	public GameObject LorePanel;
	public GameObject ControllPanel;


	void Start () 
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(false);
	}
	

	void Update () 
	{

	}

	public void LoreTog()
	{
		LorePanel.SetActive(true);
		ControllPanel.SetActive(false);
	}

	public void ControlTog()
	{
		LorePanel.SetActive(false);
		ControllPanel.SetActive(true);
	}


}

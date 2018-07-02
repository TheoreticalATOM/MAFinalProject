using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {

public GameObject selfPanel;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	public void ClosePanelFunc()
	{
		selfPanel.SetActive (false);
	}
}

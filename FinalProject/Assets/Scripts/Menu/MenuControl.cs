using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

	public GameObject OptionsPanel;
	public GameObject CreditPanel;


	void Start () 
	{
		OptionsPanel.SetActive(false);
		CreditPanel.SetActive(false);
	}
	

	void Update () 
	{
		
	}

	public void NewGame()
	{
		SceneManager.LoadScene(1);
	}

	public void LoadGame()
	{
		
	}

	public void Options()
	{
		OptionsPanel.SetActive(true);
		CreditPanel.SetActive(false);
	}

	public void Credits()
	{
		OptionsPanel.SetActive(false);
		CreditPanel.SetActive(true);
	}

	public void Quit()
	{
        Application.Quit();
	}

}

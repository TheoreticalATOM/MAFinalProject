using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

	public GameObject OptionsPanel;
	public GameObject CreditPanel;

	public bool optionsOpen = false;
	public bool CreditsOpen = false;

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
		optionsOpen = !optionsOpen;

		if(optionsOpen) //Open Panel
		{
			OptionsPanel.SetActive(true);
			CreditPanel.SetActive(false);
			CreditsOpen = false;
		}
		if(!optionsOpen) //Close Panel
		{
			OptionsPanel.SetActive(false);
		}
	}

	public void Credits()
	{
		CreditsOpen = !CreditsOpen;

		if(CreditsOpen) //Open Panel
		{
			CreditPanel.SetActive(true);
			OptionsPanel.SetActive(false);
			optionsOpen = false;
		}
		if(!CreditsOpen) //Close Panel
		{
			CreditPanel.SetActive(false);
		}
	}

	public void Quit()
	{
        Application.Quit();
	}


	public void CloseCredits()
	{
		CreditsOpen = !CreditsOpen;

		if(CreditsOpen) //Open Panel
		{
			CreditPanel.SetActive(true);
		}
		if(!CreditsOpen) //Close Panel
		{
			CreditPanel.SetActive(false);
		}
	}

		public void CloseOptions()
	{
		optionsOpen = !optionsOpen;

		if(optionsOpen) //Open Panel
		{
			OptionsPanel.SetActive(true);
		}
		if(!optionsOpen) //Close Panel
		{
			OptionsPanel.SetActive(false);
		}
	}

	public void Twitter()
	{
		Application.OpenURL("https://twitter.com/TheoreticalATOM");
	}

}

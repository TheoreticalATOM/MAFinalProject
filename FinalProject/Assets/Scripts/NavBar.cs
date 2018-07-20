using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavBar : MonoBehaviour {

	public GameObject mapPanel;
	public GameObject SettingPanel;
	public GameObject HelpPanel;
	public GameObject PauseMenu;

	public bool mapOpen = false;
	public bool SettingOpen = false;
	public bool HelpOpen = false;
	private bool paused = false;


	void Start () 
	{
		mapPanel.SetActive(false);
		SettingPanel.SetActive(false);
		HelpPanel.SetActive(false);
		PauseMenu.SetActive(false);
	}
	

	void Update () 
	{
		
	}

	public void OpenMenu()
	{
		mapPanel.SetActive(false);
		SettingPanel.SetActive(false);
		HelpPanel.SetActive(false);
		mapOpen = false;
		SettingOpen = false;
		HelpOpen = false;

		  paused = !paused;
            if (paused)
            {
                Debug.Log("GamePaused");
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            if (!paused)
            {
                Debug.Log("GameUNPaused");
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
	}

	public void OpenMap()
	{
		mapOpen = !mapOpen;
		SettingPanel.SetActive(false);
		HelpPanel.SetActive(false);
		PauseMenu.SetActive(false);
		SettingOpen = false;
		HelpOpen = false;
		paused = false;
        Time.timeScale = 1;

		{
			if(mapOpen)
			{
				mapPanel.SetActive(true);
			}
			if(!mapOpen)
			{
				mapPanel.SetActive(false);
			}			
		}
	}

	public void OpenJournal()
	{

	}

	public void OpenSettings()
	{
		SettingOpen = !SettingOpen;
		mapPanel.SetActive(false);
		HelpPanel.SetActive(false);
		PauseMenu.SetActive(false);
		mapOpen = false;
		HelpOpen = false;
		paused = false;
        Time.timeScale = 1;

		{
			if(SettingOpen)
			{
				SettingPanel.SetActive(true);
			}
			if(!SettingOpen)
			{
				SettingPanel.SetActive(false);
			}			
		}
	}

	public void OpenHelp()
	{
		GameGrind.Journal.Increment("Help will always be given to those who ask for it.",1);
		HelpOpen = !HelpOpen;
		SettingPanel.SetActive(false);
		mapPanel.SetActive(false);
		PauseMenu.SetActive(false);
		mapOpen = false;
		SettingOpen = false;
		paused = false;
        Time.timeScale = 1;

		{
			if(HelpOpen)
			{
				HelpPanel.SetActive(true);
			}
			if(!HelpOpen)
			{
				HelpPanel.SetActive(false);
			}			
		}
	}

	public void Quit()
	{
        Application.Quit();
	}
}

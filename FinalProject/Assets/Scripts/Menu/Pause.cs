using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour 
{
	private bool paused = false;
    public GameObject PauseMenu;

    private Sleep SleepRef;
    private SystemManager SystemStats;

	void Start () 
	{
	//	Cursor.lockState = CursorLockMode.Locked;
        paused = false;
        PauseMenu.SetActive(false);
        SleepRef = GameObject.Find("SpaceStation").GetComponent<Sleep>();	
        SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();	
	}

	void Update () //TODO: Lock camera rotation while paused
	{
		if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            if (paused)
            {
                Debug.Log("GamePaused");
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                SleepRef.isSkipping = false;
		        SystemStats.SkipIcon.SetActive(false);
		        SystemStats.PlayIcon.SetActive(false);	
		        SystemStats.PauseIcon.SetActive(true);	
            //    Cursor.visible = true;
             //   Cursor.lockState = CursorLockMode.None;
            }
            if (!paused)
            {
                Debug.Log("GameUNPaused");
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
		        SystemStats.SkipIcon.SetActive(false);
		        SystemStats.PlayIcon.SetActive(true);	
		        SystemStats.PauseIcon.SetActive(false);
           //     Cursor.visible = true;
           //     Cursor.lockState = CursorLockMode.None;
            }
		}
	}		
}

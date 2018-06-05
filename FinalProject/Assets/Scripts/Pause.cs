using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour 
{
	private bool paused = false;
    public GameObject PauseMenu;

	void Start () 
	{
		Cursor.lockState = CursorLockMode.Locked;
        paused = false;
        PauseMenu.SetActive(false);
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
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            if (!paused)
            {
                Debug.Log("GameUNPaused");
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
		}
	}		
}

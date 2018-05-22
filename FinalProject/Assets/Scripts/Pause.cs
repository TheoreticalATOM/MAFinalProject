using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
	private bool paused = false;

	void Start () 
	{
		Cursor.lockState = CursorLockMode.Locked;
        paused = false;
	}

	void Update () //TODO: Lock camera rotation while paused
	{
		if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            if (paused)
            {
                Debug.Log("GamePaused");
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            if (!paused)
            {
                Debug.Log("GameUNPaused");
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
		}
	}		
}

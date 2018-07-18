using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour {

	public GameObject Ship;
	public GameObject CutCamera;
	public Vector3 Startposition;
	public Vector3 EndPosition;
	public Vector3 StartpositionCam;
	public Vector3 EndPositionCam;
	public float TimeScale;
	public float TimeScaleCam;
	public bool Landed;
	public bool LandedCam;


	void Start () 
	{
		Landed = false;
	StartCoroutine("StartCutscene");
	StartCoroutine("CameraMove");
	}
	

	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			SceneManager.LoadScene(2);
		}

		if (Landed == true && LandedCam == true)
		{
			SceneManager.LoadScene(2);
		}
	}



	IEnumerator StartCutscene()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.position = Vector3.Lerp(Startposition, EndPosition, progress);
		progress += Time.deltaTime * TimeScale;
		yield return null;
	}
			Landed = true;
	}

	IEnumerator CameraMove()
	{
		float progressq = 0;
	while(progressq <=1)
	{
		CutCamera.transform.position = Vector3.Lerp(StartpositionCam, EndPositionCam, progressq);
		progressq += Time.deltaTime * TimeScaleCam;
		yield return null;
	}
		LandedCam = true;
	}

}

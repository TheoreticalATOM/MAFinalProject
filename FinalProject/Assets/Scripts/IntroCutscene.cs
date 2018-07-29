using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class IntroCutscene : MonoBehaviour {

	public GameObject Ship;
	public GameObject CutCamera;
	public Vector3 Startposition;
	public Vector3 EndPosition;
	public Vector3 StartpositionCam;
	public Vector3 EndPositionCam;
	public float TimeScale;
	public float TimeScaleCam;
	public float TimeScaleText;
	public bool Landed;
	public bool LandedCam;
	public bool TextDone;

	public GameObject Line1;
	public GameObject Line2;
	public GameObject Line3;
	public GameObject Line4;


	void Start () 
	{
		Landed = false;
	StartCoroutine("StartCutscene");
	StartCoroutine("CameraMove");
	StartCoroutine("TextScroll");
	Line1.SetActive(false);
	Line2.SetActive(false);
	Line3.SetActive(false);
	Line4.SetActive(false);
	}
	

	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			SceneManager.LoadScene(2);
		}

		if (Landed == true && LandedCam == true && TextDone == true)
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
 
	IEnumerator TextScroll()
	{
		float ProgressT = 0;
		while (ProgressT <= 1)
		{	
			ProgressT += Time.deltaTime * TimeScaleText;
			yield return new WaitForSeconds(2.0f);
			Line1.SetActive(true);
			Line2.SetActive(false);
			Line3.SetActive(false);
			Line4.SetActive(false);
            yield return new WaitForSeconds(2.0f);
			Line1.SetActive(true);
			Line2.SetActive(true);
			Line3.SetActive(false);
			Line4.SetActive(false);
            yield return new WaitForSeconds(2.0f);
			Line1.SetActive(true);
			Line2.SetActive(true);
			Line3.SetActive(true);
			Line4.SetActive(false);
            yield return new WaitForSeconds(2.0f);
			Line1.SetActive(true);
			Line2.SetActive(true);
			Line3.SetActive(true);
			Line4.SetActive(true);
            yield return new WaitForSeconds(2.0f);
			Line1.SetActive(false);
			Line2.SetActive(false);
			Line3.SetActive(false);
			Line4.SetActive(false);
			TextDone = true;
			yield return null;
		}
	}

}

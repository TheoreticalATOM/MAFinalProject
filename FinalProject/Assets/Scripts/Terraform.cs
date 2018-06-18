using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraform : MonoBehaviour 
{
	//public float scallingFactor;
	public float TimeScale = 0.5f;
	public Vector3 InitialScale;
	public Vector3 FinalScale;



	void Start ()
	{
	StartCoroutine("ScaleSphere");

	}

	IEnumerator ScaleSphere()
	{
		float progress = 0;
	while(progress <=1)
	{
		transform.localScale = Vector3.Lerp(InitialScale, FinalScale, progress);
		progress += Time.deltaTime * TimeScale;
		yield return null;
	}
	transform.localScale = FinalScale;
	}

}

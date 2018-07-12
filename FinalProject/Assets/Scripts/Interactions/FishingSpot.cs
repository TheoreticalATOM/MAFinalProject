using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : Interactable {


public override void Interact()
{
	base.Interact();

	Fish();

}


	void Start () {
		
	}
	

	void Update () {
		
	}

	public void Fish()
	{
		Debug.Log("Fishing");
	}
}

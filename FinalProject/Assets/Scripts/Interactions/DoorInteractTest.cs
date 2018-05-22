using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorInteractTest : MonoBehaviour {
	public TextMeshProUGUI interactText;

	void OnTriggerStay(Collider other)   //Use for triggers
    {
        if (other.CompareTag("PlayerInteractCollider"))
        {
			interactText.text = "Press E to Enter";
			if(Input.GetButtonDown("Interact"))
				{
					Debug.Log("Entered");
				}
        }
    }
	void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}
}

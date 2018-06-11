using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishingSpot : MonoBehaviour {

	public TextMeshProUGUI interactText;
	public GameObject TextBorder;

	void OnTriggerStay(Collider other)   //Use for triggers
    {
        if (other.CompareTag("PlayerInteractCollider"))
        {
			interactText.text = "Press E to Fish";
			TextBorder.SetActive(true);
			{
				if(Input.GetButtonDown("Interact"))
				{
					Debug.Log("Did a Fish");
				}
			}
        }
    }
	void OnTriggerExit(Collider other)
	{
		TextBorder.SetActive(false);
		interactText.text = "";
	}
}

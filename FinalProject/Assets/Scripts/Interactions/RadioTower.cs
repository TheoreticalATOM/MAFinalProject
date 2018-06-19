using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadioTower : MonoBehaviour 
{
	public TextMeshProUGUI interactText;
	public GameObject TextBorder;
	public bool built;
	public GameObject RadioTowerMod;
	public GameObject RadioBuildPoint;

	void Start()
	{
		RadioTowerMod.SetActive(false);
		RadioBuildPoint.SetActive(true);
	}
	
	void OnTriggerStay(Collider other)   //Use for triggers
    {
		if (built == false)
		{
			if (other.CompareTag("PlayerInteractCollider"))
    		{
				interactText.text = "Press E to Build Radio Tower";
				TextBorder.SetActive(true);
				{
					if(Input.GetButtonDown("Interact"))
					{
						RadioTowerMod.SetActive(true);
						built = true;
						RadioBuildPoint.SetActive(false);
					}
				}
        	}
		}

		if (built == true)
		{
		if (other.CompareTag("PlayerInteractCollider"))
        {
			interactText.text = "Press E to Use";
			TextBorder.SetActive(true);
			{
				if(Input.GetButtonDown("Interact"))
				{
					Debug.Log("UsingConsole");
				}
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

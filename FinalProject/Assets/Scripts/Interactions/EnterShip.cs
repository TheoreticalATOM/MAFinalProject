using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterShip : MonoBehaviour {
	public TextMeshProUGUI interactText;
	public GameObject TextBorder;
	public GameObject ShipMenu;
	private SystemManager SystemStats;

	void Start ()
	{
		SystemStats = GameObject.Find("Manager").GetComponent<SystemManager>();
		ShipMenu.SetActive(false);
	}

	void OnTriggerStay(Collider other)   //Use for triggers
    {
        if (other.CompareTag("PlayerInteractCollider"))
        {
			interactText.text = "Press E to Access Ship";
			TextBorder.SetActive(true);
			if(Input.GetButtonDown("Interact") && SystemStats.InShip == false)
				{
					ShipMenu.SetActive(true);
					SystemStats.InShip = true;
					Cursor.visible = true;
               		Cursor.lockState = CursorLockMode.None;
				}
        }
    }
	void OnTriggerExit(Collider other)
	{
		interactText.text = "";
		TextBorder.SetActive(false);
	}
}
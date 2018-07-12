using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterShip : Interactable {

public GameObject ShipMenu;

public override void Interact()
{
	base.Interact();

	ShipEnter();

}

	void ShipEnter()
	{
		ShipMenu.SetActive(true);
	}

}

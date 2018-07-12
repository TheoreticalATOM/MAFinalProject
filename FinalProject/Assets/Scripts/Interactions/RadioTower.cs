using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTower : Interactable {

public GameObject RadioTowerMod;
public GameObject BuildPoint;

public override void Interact()
{
	base.Interact();

	BuildTower();

}
	
void BuildTower()
{
	RadioTowerMod.SetActive(true);
	BuildPoint.SetActive(false);
}

}

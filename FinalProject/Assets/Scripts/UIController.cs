using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {

	public TextMeshProUGUI interactText;
	public GameObject TextBorder;

	void Start () 
	{
		interactText.text = "";
		TextBorder.SetActive(false);
	}
	
	void Update () 
	{

	}
}

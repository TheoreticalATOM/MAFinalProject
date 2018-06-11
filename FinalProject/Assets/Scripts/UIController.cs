using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {

	public TextMeshProUGUI interactText;
	public GameObject TextBorder;
	public GameObject Canvas;

	void Start () 
	{
		interactText.text = "";
		TextBorder.SetActive(false);
		Canvas.SetActive(true);
	}
	
	void Update () 
	{

	}
}

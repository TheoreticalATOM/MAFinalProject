using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	public float speed;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		transform.Rotate(Vector3.left * speed * Time.deltaTime);
		transform.Rotate(Vector3.down * speed * Time.deltaTime, Space.World);
	}
}

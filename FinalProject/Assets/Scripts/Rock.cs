using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	public ResorceManager resourceStats;
	public GameObject RockBase;
	public GameObject RockResource;
	public int carbonCollected;
	public float TimeScale;


	void Start () 
	{
		resourceStats = GameObject.Find("Manager").GetComponent<ResorceManager>();
		RockBase.SetActive(false);
		RockResource.SetActive(true);
	}
	
	void Update () 
	{
		 if (Input.GetMouseButtonDown(0)) 
			{
                 RaycastHit  hit;
                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
                  if (Physics.Raycast(ray, out hit))
				{
                    if (hit.transform.gameObject == RockResource)
					{
						StartCoroutine ("RockRegen");
					}
				}
			}
	}
 
	IEnumerator RockRegen()
	{	
		RockResource.SetActive(false);
		RockBase.SetActive(true);
		resourceStats.CarbonStat += carbonCollected;

		float progress = 0;
		while(progress <=10000)
		{
			progress += Time.deltaTime * TimeScale;
			yield return null;
		}
		RockResource.SetActive(true);
	}

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OreNode : MonoBehaviour {

	public OreList getOres;
	public List<int> oreFindWeight = new List<int>();

	private int range = 0;
	private int top = 0;
	private int rand = 0;

	// Use this for initialization
	void Start () 
	{
		getOres = GameObject.FindGameObjectWithTag("OreList").GetComponent<OreList>();
		StartCoroutine(LoadOre());
	}
	
	IEnumerator LoadOre ()
	{
		yield return new WaitForSeconds(0.25f);

		for(int i = 0; i < getOres.oreList.Count; i++)
		{
			oreFindWeight.Add(getOres.oreList[i].rarity);
		}

		for(int j = 0; j < oreFindWeight.Count; j++)
		{
			range += oreFindWeight[j];
		}

		rand = Random.Range(0,range);
		print ("Random: " + rand);

		for(int k = 0; k < oreFindWeight.Count; k++)
		{
			top += oreFindWeight[k];

			if(rand < top)
			{
				transform.GetComponent<MeshRenderer>().material.color = getOres.oreList[k].oreColor;
				break;
			}
		}
	}
}

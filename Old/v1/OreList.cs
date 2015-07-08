using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OreList : MonoBehaviour {

	public List<OreType> oreList = new List<OreType>();
	private string itemType = "Ore";
	private string skillType = "Mining";

	void Start () 
	{
v		oreList.Add (new OreType("Iron", Color.blue, 0.0f, 10.0f, 3, 0.80f, itemType,, 0));
		oreList.Add (new OreType("Copper", Color.red, 5.0f, 20.0f, 3, 0.20f, itemType, SkillUsed.Mining, 1));
	}
}

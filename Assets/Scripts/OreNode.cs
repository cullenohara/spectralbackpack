using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OreNode : MonoBehaviour {

	public List<OreTypes> oreTypes = new List<OreTypes>();
	private List<OreTypes> possibleOre = new List<OreTypes> ();
	public GameObject orePrefab;
	private int listCount;
	private int chances;

	void Start ()
	{
		GenerateOres ();
	}

	void GenerateOres ()
	{
		oreTypes.Add( new OreTypes(5, "Copper Ore", "A large chunk of copper and rock.", Color.red, 0.0f, 10.0f, 70, 25));
		oreTypes.Add( new OreTypes(6, "Tin Ore", "A large chunk of tin and rock.", Color.grey, 8.0f, 20.0f, 120, 25));
		oreTypes.Add( new OreTypes(7, "Iron Ore", "A large chunk of iron and rock.", Color.blue, 18.0f, 30.0f, 160, 25));
	}

	void OnMouseDown ()
	{
		float rand = Random.Range (0.0f, PlayerPrefs.GetFloat ("Mining"));
		print ("Random : " + rand);

		for (int i = 0; i < oreTypes.Count; i++) 
		{
			if(rand > oreTypes[i].minSkill)
			{
				possibleOre.Add(oreTypes[i]);
				chances = oreTypes[i].findChance;
			}
		}

		int randChance = Random.Range (0, chances);
		print (randChance);
		chances = 0;

		for (int i = 0; i < possibleOre.Count; i++)
		{
			if(randChance < possibleOre[i].findChance)
			{
				print (possibleOre[i].oreName);
				break;
			}
		}
	}
}

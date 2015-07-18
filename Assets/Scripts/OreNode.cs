using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OreNode : MonoBehaviour {

	public List<OreTypes> oreTypes = new List<OreTypes>();
	private List<OreTypes> possibleOre = new List<OreTypes> ();
	public GameObject orePrefab;
	private int listCount;
	private int chances;

	public Inventory inventory;
	public GameObject player;

	void Start ()
	{
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
		GenerateOres ();
	}

	void GenerateOres ()
	{
		oreTypes.Add( new OreTypes(5, "Copper Ore", "A large chunk of copper and rock.", "copper", Color.red, 0.0f, 10.0f, 70, 25));
		oreTypes.Add( new OreTypes(6, "Tin Ore", "A large chunk of tin and rock.", "tin", Color.grey, 8.0f, 20.0f, 120, 25));
		oreTypes.Add( new OreTypes(7, "Iron Ore", "A large chunk of iron and rock.", "iron", Color.blue, 18.0f, 30.0f, 160, 25));
	}

	void OnMouseDown ()
	{
		float rand = Random.Range (0.0f, PlayerPrefs.GetFloat ("mining"));

		for (int i = 0; i < oreTypes.Count; i++) 
		{
			if(rand > oreTypes[i].minSkill)
			{
				possibleOre.Add(oreTypes[i]);
				chances = oreTypes[i].findChance;
			}
		}

		int randChance = Random.Range (0, chances);
		chances = 0;

		for (int i = 0; i < possibleOre.Count; i++)
		{
			if(randChance < possibleOre[i].findChance)
			{
				GiveOre (possibleOre[i]);
				break;
			}
		}
	}

	void GiveOre (OreTypes item)
	{
		GameObject tempOre = new GameObject ();
		tempOre.AddComponent<Ore> ();
		tempOre.GetComponent<Ore> ().itemID = item.oreID;
		tempOre.GetComponent<Ore> ().itemName = item.oreName;
		tempOre.GetComponent<Ore> ().itemDesc = item.oreDesc;
		tempOre.GetComponent<Ore> ().itemIcon = Resources.Load<Sprite> ("Icons/" + item.resourceName);
		tempOre.GetComponent<Ore> ().maxSkill = item.maxSkill;
		tempOre.GetComponent<Ore> ().minSkill = item.minSkill;
		tempOre.GetComponent<Ore> ().oreColor = item.oreColor;
		tempOre.GetComponent<Ore> ().rarity = Item.ItemRarity.common;
		tempOre.GetComponent<Ore> ().stackMax = item.stackMax;
		tempOre.GetComponent<Ore> ().type = Item.ItemType.material;
		tempOre.GetComponent<Ore> ().skill = Item.SkillUsed.mining;

		inventory.AddItem (tempOre.GetComponent<Ore>());
		Destroy (tempOre);

		player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<Player>().GainSkill(tempOre.GetComponent<Ore>().skill.ToString(), tempOre.GetComponent<Ore>().maxSkill);
	}
}
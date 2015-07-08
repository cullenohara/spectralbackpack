using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OreList : MonoBehaviour {

	public ItemDatabase itemDatabase;
	public List<Ore> oreList = new List<Ore>();

	// Use this for initialization
	void Start () {
		itemDatabase = GameObject.FindGameObjectWithTag("Database").GetComponent<ItemDatabase>();
		GenerateOre();
	}
	
	// Update is called once per frame
	void GenerateOre () {

		Ore iron = new Ore();
		iron.id = 1000;
		iron.name = "Iron Ore";
		iron.type = "Ore";
		iron.buy = 10;
		iron.sell = 3;
		iron.count = 0;
		iron.description = "A large chunk of iron and rock.";
		iron.maxFind = 5;
		iron.minSkill = 0.0f;
		iron.maxSkill = 10.0f;
		iron.oreColor = Color.gray;
		iron.rarity = 10;
		iron.skillUsed = Craftable.SkillUsed.Mining;
		iron.stackable = true;

		Ore copper = new Ore();
		copper.id = 1001;
		copper.name = "Copper Ore";
		copper.type = "Ore";
		copper.buy = 10;
		copper.sell = 3;
		copper.count = 0;
		copper.description = "A large chunk of copper and rock.";
		copper.maxFind = 5;
		copper.minSkill = 9.0f;
		copper.maxSkill = 20.0f;
		copper.oreColor = Color.red;
		copper.rarity = 20;
		copper.skillUsed = Craftable.SkillUsed.Mining;
		copper.stackable = true;

		Ore bronze = new Ore();
		bronze.id = 1002;
		bronze.name = "Bronze Ore";
		bronze.type = "Ore";
		bronze.buy = 10;
		bronze.sell = 3;
		bronze.count = 0;
		bronze.description = "A large chunk of bronze and rock.";
		bronze.maxFind = 5;
		bronze.minSkill = 19.0f;
		bronze.maxSkill = 30.0f;
		bronze.oreColor = Color.yellow;
		bronze.rarity = 40;
		bronze.skillUsed = Craftable.SkillUsed.Mining;
		bronze.stackable = true;

		//Add all ore types to oreList
		oreList.Add(iron);
		oreList.Add(copper);
		oreList.Add(bronze);
		//Call AddToDatabase() to place them all in the main game item database
		AddToDatabase();
	}

	void AddToDatabase ()
	{
		for(int i = 0; i < oreList.Count; i++)
		{
			Ore tempOre = new Ore();
			tempOre.id = oreList[i].id;
			tempOre.name = oreList[i].name;
			tempOre.type = oreList[i].type;
			tempOre.buy = oreList[i].buy;
			tempOre.sell = oreList[i].sell;
			tempOre.count = oreList[i].count;
			tempOre.description = oreList[i].description;
			tempOre.maxFind = oreList[i].maxFind;
			tempOre.maxSkill = oreList[i].maxSkill;
			tempOre.minSkill = oreList[i].minSkill;
			tempOre.oreColor = oreList[i].oreColor;
			tempOre.rarity = oreList[i].rarity;
			tempOre.skillUsed = oreList[i].skillUsed;
			tempOre.stackable = oreList[i].stackable;

			itemDatabase.database.Add(tempOre);
		}
	}
}

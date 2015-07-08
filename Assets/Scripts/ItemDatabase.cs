using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item> ();

	void Start ()
	{
		items.Add(new Item("Iron Ore", 0, "A large chunk of iron and rock.", Item.ItemType.Materials, 5,
		                   0.5f, Color.grey, true, 100, "Ore", 100, Item.SkillRequired.Mining, 0.0f, 12.0f));
		items.Add(new Item("Copper Ore", 1, "A large chunk of copper and rock.", Item.ItemType.Materials, 5,
		                   0.5f, Color.red, true, 100, "Ore", 50, Item.SkillRequired.Mining, 0.0f, 22.0f));
		items.Add(new Item("Bronze Ore", 2, "A large chunk of bronze and rock.", Item.ItemType.Materials, 5,
		                   0.5f, Color.yellow, true, 100, "Ore", 30, Item.SkillRequired.Mining, 0.0f, 32.0f));
	}

}

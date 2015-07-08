using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> database = new List<Item>();

	// Use this for initialization
	void Start () {
		database.Add(new Item(0, "Iron Ore", null, Item.ItemType.Craftable, 2, 1, 1, true));
		database.Add(new Item(1, "Copper Ore", null, Item.ItemType.Craftable, 2, 1, 1, true));
	}
}

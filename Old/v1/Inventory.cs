using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item> inventory = new List<Item>();

	void AddItem (int itemID, int itemCount)
	{
		inventory.Add(new Item(/*put some stuff in here*/));
	}

	void RemoveItem ()
	{

	}
}

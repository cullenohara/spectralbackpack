using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<Item> inventory = new List<Item>();
	public bool isEmpty = true;

	void Update ()
	{
		if (inventory.Count > 0) 
		{
			isEmpty = false;
		}
	}
	
	void AddItem (Item item)
	{
		print (item.ItemCount);
		if (!isEmpty) {
			int tempInt = 0;
			for( int i = 0; i < inventory.Count; i++)
			{
				tempInt++;
				if(item.itemID == inventory[i].itemID)
				{
					inventory[i].ItemCount += item.ItemCount;
					print (inventory[i].ItemCount);
					break;
				}
				if(tempInt == inventory.Count)
				{
					print ("No Match");
					inventory.Add(item);
					tempInt = 0;
					break;
				}
			}

		} else {
			inventory.Add(item);
		}
	}
}

using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Item : ScriptableObject {

	public int id;
	public string name;
	public string type;
	public string description;
	public Sprite icon;
	public int sell;
	public int buy;
	public int count;
	public bool stackable;

	public Item (int itemID, string itemName, string itemType, string itemDesc, Sprite itemIcon, int itemSell, int itemBuy, int itemCount, bool itemStackable)
	{
		id = itemID;
		name = itemName;
		type = itemType;
		description = itemDesc;
		icon = itemIcon;
		sell = itemSell;
		buy = itemBuy;
		count = itemCount;
		stackable = itemStackable;
	}

	public Item ()
	{

	}
}

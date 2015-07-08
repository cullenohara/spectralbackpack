using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Item {

	public int id;
	public string name;
	public Sprite icon;
	public ItemType type;
	public int buyPrice;
	public int sellPrice;
	public int count;
	public bool stackable;

	public Item(int itemID, string itemName, Sprite itemIcon, ItemType itemType, int itemBuy, int itemSell, int itemCount, bool itemStackable)
	{
		id = itemID;
		name = itemName;
		icon = itemIcon;
		type = itemType;
		buyPrice = itemBuy;
		sellPrice = itemSell;
		count = itemCount;
		stackable = itemStackable;
	}

	public Item()
	{

	}

	public enum ItemType
	{
		Armor,
		Consumable,
		Craftable,
		Weapon
	}
	
}

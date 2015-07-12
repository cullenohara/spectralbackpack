using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public enum ItemType { tool, material, consumable, armor, weapon }
	public enum ItemRarity { common, uncommon, rare, mythical, legendary }

	public int itemID;
	public string itemName;
	public string itemDesc;
	public Sprite itemIcon;
	public int stackMax;
	public ItemType type;
	public ItemRarity rarity;
	
	public void Use ()
	{
		switch (type) 
		{
		case ItemType.consumable:
			Debug.Log("You just used " + itemName);
			break;
		}
	}
}

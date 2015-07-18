using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public enum ItemType { tool, material, consumable, armor, weapon }
	public enum ItemRarity { common, uncommon, rare, mythical, legendary }
	public enum SkillUsed { alchemy, blacksmithing, carpentry, fishing, hunting, lumberjacking, mining, tinkering }

	public int itemID;
	public string itemName;
	public string itemDesc;
	public Sprite itemIcon;
	public int stackMax;
	public ItemType type;
	public ItemRarity rarity;
	public SkillUsed skill;
	public string resourceName;

	public virtual void Use ()
	{
		//Perform use function for this particular item type
	}

	public virtual void Pickup ()
	{

	}
}

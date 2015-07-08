using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	
	public string itemName;
	public int itemID;
	public string itemDesc;
	public ItemType itemType;
	public int itemCost;
	public int itemCount;
	public float itemWeight;
	public Color itemColor;
	public bool itemStackable;
	public int itemStackSize;
	public string itemMaterial;
	public int itemDropChance;

	public SkillRequired itemSkillReq;
	public float itemMinSkill;
	public float itemMaxSkill;
	
	public Sprite itemIcon;

	public enum ItemType
	{
		Materials,
		Consumable,
		Armor,
		Weapon
	}

	public enum SkillRequired
	{
		Mining,
		Blacksmithing,
		Alchemy,
		Carpentry,
		Lumberjacking,
		Tinkering,
		Tailoring,
		Hunting,
		Fishing
	}

	public Item (string _name, int _id, string _desc, ItemType _type, int _cost, int _count, float _weight, Color _color,
	             bool _stackable, int _stacksize, string _material, int _dropchance, SkillRequired _skillreq, float _minskill,
	             float _maxskill)
	{
		itemName = _name;
		itemID = _id;
		itemDesc = _desc;
		itemType = _type;
		itemCost = _cost;
		itemCount = _count;
		itemWeight = _weight;
		itemColor = _color;
		itemStackable = _stackable;
		itemStackSize = _stacksize;
		itemMaterial = _material;
		itemDropChance = _dropchance;
		itemSkillReq = _skillreq;
		itemMinSkill = _minskill;
		itemMaxSkill = _maxskill;
		for (int i = 0; i < Resources.LoadAll<Sprite>("Icons/Items").Length; i++) 
		{
			if(Resources.LoadAll<Sprite>("Icons/Items")[i].name == itemName)
			{
				itemIcon = Resources.LoadAll<Sprite>("Icons/Items")[i];
			}
		}
	}
}

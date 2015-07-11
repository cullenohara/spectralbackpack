using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public enum ItemType { tool, material, consumable, armor, weapon }

	public string itemName;
	public ItemType type;
	public int stackMax;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

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

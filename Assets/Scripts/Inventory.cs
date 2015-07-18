using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private RectTransform inventoryRect;
	private float inventoryWidth, inventoryHeight;

	public int slots;
	public int rows;
	public float slotPaddingLeft, slotPaddingTop;
	public float slotSize;
	public GameObject slotPrefab;
	
	private List<GameObject> allSlots;
	public List<Item> fullInventory;

	private static int emptySlots;

	public static int EmptySlots
	{
		get { return emptySlots; }
		set { emptySlots = value; }
	}

	private Slot from, to;

	// Use this for initialization
	void Start () {
		CreateLayout ();
	}

	private void CreateLayout ()
	{
		allSlots = new List<GameObject> ();
		emptySlots = slots;
		inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
		inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;
		inventoryRect = GetComponent<RectTransform> ();
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, inventoryWidth);
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, inventoryHeight);

		int columns = slots / rows;

		for (int y = 0; y < rows; y++) 
		{
			for(int x = 0; x < columns; x++)
			{
				GameObject newSlot = (GameObject)Instantiate(slotPrefab);
				RectTransform slotRect = newSlot.GetComponent<RectTransform>();
				newSlot.name = "Slot";
				newSlot.transform.SetParent(this.transform.parent);
				slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));
				slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
				allSlots.Add(newSlot);
			}
		}
	}

	public bool AddItem(Item item)
	{
		if (item.stackMax <= 1) 
		{
			PlaceEmpty (item);
			GetInventory();
			return true;
		} 
		else 
		{
			foreach (GameObject slot in allSlots)
			{
				Slot temp = slot.GetComponent<Slot>();

				if (!temp.IsEmpty)
				{
					if (temp.CurrentItem.itemID == item.itemID && temp.IsAvailable)
					{
						temp.AddItem(item);
						GetInventory();
						return true;
					}
				}
			}
			if (emptySlots > 0)
			{
				PlaceEmpty(item);
				GetInventory();
			}
			else
			{
				Debug.Log("Inventory is full.");
			}
		}

		return false;
	}

	private bool PlaceEmpty (Item item)
	{
		if (emptySlots > 0) 
		{
			foreach (GameObject slot in allSlots) 
			{
				Slot temp = slot.GetComponent<Slot> ();

				if (temp.IsEmpty) 
				{
					temp.AddItem (item);
					emptySlots--;
					return true;
				}
			}
		} 

		return false;
	}

	public void MoveItem(GameObject clicked)
	{
		if (from == null) 
		{
			if (!clicked.GetComponent<Slot> ().IsEmpty) 
			{
				//Gray out the item you have clicked
				from = clicked.GetComponent<Slot> ();
				from.GetComponent<Image> ().color = Color.gray;
				from.itemSprite.GetComponent<Image>().color = Color.gray;
				from.stackText.color = Color.gray;
			}
		} 
		else if (to == null) 
		{
			to = clicked.GetComponent<Slot>();
		}

		if (to != null && from != null) {
			Stack<Item> tempTo = new Stack<Item> (to.Stack);
			to.AddItems (from.Stack);

			if (tempTo.Count == 0) {
				from.ClearSlot();
			} 
			else {
				from.AddItems (tempTo);
			}
			//Set it back to full opacity;
			from.GetComponent<Image> ().color = Color.white;
			from.itemSprite.GetComponent<Image>().color = Color.white;
			from.stackText.color = Color.white;
			to = null;
			from = null;
		}
	}

	public void GetInventory ()
	{
		foreach (GameObject slot in allSlots) {
			Slot temp = slot.GetComponent<Slot> ();
		
			if (!temp.IsEmpty) {
				fullInventory.Add (temp.CurrentItem);
			}
		}
	}
}

	

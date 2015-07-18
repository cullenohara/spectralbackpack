using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
	private Stack<Item> stack;

	public Stack<Item> Stack
	{
		get { return stack; }
		set { stack = value; }
	}

	public Text stackText;
	public Sprite slotEmpty;
	public Sprite slotUncommon;
	public Sprite slotRare;
	public Sprite slotMythical;
	public Sprite slotLegendary;

	public RectTransform itemSprite;

	public bool IsEmpty
	{
		get { return stack.Count == 0; }
	}

	public Item CurrentItem
	{
		//returns the last item on the stack
		get { return stack.Peek (); }
	}

	public bool IsAvailable
	{
		//is stacking availabe?
		get { return CurrentItem.stackMax > stack.Count; }
	}

	// Use this for initialization
	void Start () {
		stack = new Stack<Item> ();
		RectTransform slotRect = GetComponent<RectTransform> ();
		RectTransform textRect = stackText.GetComponent<RectTransform> ();
		RectTransform iconRect = itemSprite;

		int textScaleFactor = (int)(slotRect.sizeDelta.x * 0.60);
		stackText.resizeTextMaxSize = textScaleFactor;
		stackText.resizeTextMinSize = textScaleFactor;

		textRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
		textRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
		iconRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
		iconRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
	}

	void Update ()
	{
		if (IsEmpty) 
		{
			itemSprite.GetComponent<Image> ().enabled = false;
		} 
		else 
		{
			itemSprite.GetComponent<Image> ().enabled = true;

			switch(stack.Peek().rarity)
			{
			case Item.ItemRarity.common :
				GetComponent<Image>().sprite = GetComponent<Slot>().slotEmpty;
				break;
			case Item.ItemRarity.uncommon :
				GetComponent<Image>().sprite = GetComponent<Slot>().slotUncommon;
				break;
			case Item.ItemRarity.rare :
				GetComponent<Image>().sprite = GetComponent<Slot>().slotRare;
				break;
			case Item.ItemRarity.mythical :
				GetComponent<Image>().sprite = GetComponent<Slot>().slotMythical;
				break;
			case Item.ItemRarity.legendary :
				GetComponent<Image>().sprite = GetComponent<Slot>().slotLegendary;
				break;
			}
		}
	}

	public void AddItem(Item item)
	{
		stack.Push (item);

		if (stack.Count > 1) 
		{
			stackText.text = stack.Count.ToString();
		}

		ChangeSprite (item.itemIcon);
	}
	
	private void ChangeSprite(Sprite icon)
	{
		itemSprite.GetComponent<Image>().sprite = icon;
	}

	private void UseItem ()
	{
		if (!IsEmpty && stack.Peek().type == Item.ItemType.consumable) 
		{
			stack.Pop().Use();
			stackText.text = stack.Count > 1 ? stack.Count.ToString() : string.Empty;

			if (IsEmpty)
			{
				ClearSlot();
			}
		}
	}

	public void AddItems(Stack<Item> stack)
	{
		this.stack = new Stack<Item>(stack);
		stackText.text = stack.Count > 1 ? stack.Count.ToString() : string.Empty;
		ChangeSprite (CurrentItem.itemIcon);
	}

	public void ClearSlot()
	{
		stack.Clear ();
		stackText.text = string.Empty;
		GetComponent<Image>().sprite = GetComponent<Slot>().slotEmpty;
		Inventory.EmptySlots++;
	}
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right) 
		{
			UseItem();
		}
	}
}

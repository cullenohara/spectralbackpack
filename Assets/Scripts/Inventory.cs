using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<Item> inventory = new List<Item>();
	private ItemDatabase database;

	public Image slot0;
	public Image slot1;
	public Image slot2;

	IEnumerator Start ()
	{
		yield return new WaitForSeconds (1.0f);

		database = GameObject.FindGameObjectWithTag ("Database").GetComponent<ItemDatabase> ();
		inventory.Add (database.items [0]);
		inventory.Add (database.items [1]);
		inventory.Add (database.items [2]);

		slot0.GetComponent<Image>().sprite = database.items[0].itemIcon;
		slot1.GetComponent<Image>().sprite = database.items[1].itemIcon;
		slot2.GetComponent<Image>().sprite = database.items[2].itemIcon;
	}

}

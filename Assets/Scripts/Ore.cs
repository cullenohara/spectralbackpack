using UnityEngine;
using System.Collections;

public class Ore : MonoBehaviour {

	public Item ore;
	public Inventory inventory;

	void Start ()
	{
		inventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<Inventory> ();
		transform.GetComponent<MeshRenderer> ().material.color = ore.itemColor;
		transform.name = ore.itemName;
	}

	void OnMouseDown ()
	{
		//print ("You collected (" + ore.itemCount + ") " + ore.itemName);
		inventory.SendMessage ("AddItem", ore, SendMessageOptions.DontRequireReceiver);

		Destroy (gameObject, 0.10f);
	}
}

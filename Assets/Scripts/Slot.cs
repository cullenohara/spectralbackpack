using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	private Stack<Item> stack;
	public Text stackText;
	public Sprite slotEmpty;
	public Sprite slotHighlighted;

	// Use this for initialization
	void Start () {
		stack = new Stack<Item> ();
		RectTransform slotRect = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

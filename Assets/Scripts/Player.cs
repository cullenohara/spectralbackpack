using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Inventory inventory;

	void Start ()
	{
		PlayerPrefs.SetFloat ("mining", 20.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandleMovement ();
	}

	private void HandleMovement ()
	{
		float translation = speed * Time.deltaTime;

		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * translation, 0, Input.GetAxis ("Vertical") * translation));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item") 
		{
			inventory.AddItem(other.GetComponent<Item>());
		}
	}

	public void GainSkill (string skill, float value)
	{
		print (skill);
	}
}

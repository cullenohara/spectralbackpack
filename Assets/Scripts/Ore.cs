using UnityEngine;
using System.Collections;

public class Ore : MonoBehaviour {

	public Color oreColor;
	public string oreName;
	public int oreRefID;

	void Start ()
	{
		transform.GetComponent<MeshRenderer>().material.color = oreColor;
		transform.name = oreName;
	}

	void OnMouseDown ()
	{
		Destroy (gameObject);
		print ("You collected " + oreName);
	}
}

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Ore : Item {

	public Color oreColor;
	public float minSkill;
	public float maxSkill;

	public override void Use ()
	{
		print ("I'm ore");
	}

	public override void Pickup ()
	{
		Destroy (gameObject);
		print ("You just grabbed some ore dude");
	}
}

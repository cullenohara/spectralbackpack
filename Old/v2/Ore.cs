using UnityEngine;
using System.Collections;

[System.Serializable]
public class Ore : Craftable {

	public Color oreColor;
	public int maxFind;
	public int rarity;

	public Ore (Color _oreColor, int _maxFind, int _rarity)
	{
		oreColor = _oreColor;
		maxFind = _maxFind;
		rarity = _rarity;
	}

	public Ore()
	{

	}

}

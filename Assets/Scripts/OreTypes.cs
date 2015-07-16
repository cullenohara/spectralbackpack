using UnityEngine;
using System.Collections;

[System.Serializable]
public class OreTypes
{
	public int oreID;
	public string oreName;
	public string oreDesc;
	public Color oreColor;
	public float minSkill;
	public float maxSkill;
	public int findChance;
	public int stackMax;

	public OreTypes (int id, string name, string desc, Color color, float min, float max, int chance, int stack)
	{
		oreID = id;
		oreName = name;
		oreDesc = desc;
		oreColor = color;
		minSkill = min;
		maxSkill = max;
		findChance = chance;
		stackMax = stack;
	}
}

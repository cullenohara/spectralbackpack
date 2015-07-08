using UnityEngine;
using System.Collections;

[System.Serializable]
public class OreType : Item {

	public Color color;
	public float minSkill;
	public float maxSkill;
	public SkillUsed skillUsed;
	public int maxFound;
	public float rarity;

	public OreType(string oreName, Color oreColor, float oreMinSkill, float oreMaxSkill, int oreMaxFound, float oreRarity, SkillUsed oreSkillUsed, int oreID)
	{
		id = oreID;
		name = oreName;
		color = oreColor;
		minSkill = oreMinSkill;
		maxSkill = oreMaxSkill;
		maxFound = oreMaxFound;
		rarity = oreRarity;
		skillUsed = oreSkillUsed;
	}

	public enum SkillUsed
	{
		Mining,
		Blacksmithing,
		Tailoring,
		Tinkering,
		Carpentry,
		Bowyer,
		Fishing,
		Lumberjacking,
		Leatherworking
	}
}

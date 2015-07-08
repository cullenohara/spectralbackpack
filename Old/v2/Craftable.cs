using UnityEngine;
using System.Collections;

public class Craftable : Item {

	public float minSkill;
	public float maxSkill;
	public SkillUsed skillUsed;

	public Craftable (float itemMinSkill, float itemMaxSkill, SkillUsed itemSkill)
	{
		minSkill = itemMinSkill;
		maxSkill = itemMaxSkill;
		skillUsed = itemSkill;
	}

	public Craftable ()
	{

	}

	public enum SkillUsed
	{
		Alchemy,
		Blacksmithing,
		Carpentry,
		Herbalism,
		Lumberjacking,
		Mining,
		Tinkering
	}
}

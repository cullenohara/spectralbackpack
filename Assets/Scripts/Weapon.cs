using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : Item {

	public enum WeaponSkill
	{
		Swordsmanship,
		Fencing,
		Macemanship,
		Polearms,
		Spears,
		Bows
	}

	public enum EquipType
	{
		OneHanded,
		TwoHanded
	}

	public WeaponSkill weaponSkill;
	public EquipType equipType;

	public int strBuff;
	public int dexBuff;
	public int intBuff;

	public Weapon (int id, string name, string desc, Sprite icon, int max, ItemType itemType, ItemRarity rare,
	               WeaponSkill skill, EquipType type, int str, int dex, int intel) : base (id, name, desc, icon, max, itemType, rare)
	{
		weaponSkill = skill;
		equipType = type;
		strBuff = str;
		dexBuff = dex;
		intBuff = intel;
	}

	public override void Use ()
	{
		print ("I'm a weapon.");
	}
}

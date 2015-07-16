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

	public override void Use ()
	{
		print ("I'm a weapon.");
	}
}

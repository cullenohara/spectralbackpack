using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour {

	public int playerStrength;
	public int playerDexterity;
	public int playerIntelligence;

	public float Mining;
	public float Blacksmithing;

	public Text miningText;

	void Start () {
		PlayerPrefs.SetInt ("Strength", 50);
		PlayerPrefs.SetInt ("Dexterity", 50);
		PlayerPrefs.SetInt ("Intelligence", 50);

		PlayerPrefs.SetFloat ("Mining", 0.0f);
		PlayerPrefs.SetFloat ("Blacksmithing", 0.0f);
	}

	void Update ()
	{
		miningText.text = "Mining: " + PlayerPrefs.GetFloat ("Mining") + "%";
	}
	
	void UseSkill (object[] itemInfo)
	{
		string skillName = itemInfo [0].ToString ();
		float curSkill = PlayerPrefs.GetFloat (skillName);
		float itemSkillMax = (float)itemInfo [1];
		if (curSkill >= itemSkillMax / 2 && curSkill < itemSkillMax) 
		{
			PlayerPrefs.SetFloat(skillName, curSkill + 0.25f);
		}
		if(curSkill <= itemSkillMax / 2 )
		{
			PlayerPrefs.SetFloat(skillName, curSkill + 0.5f);
		}
		if (curSkill <= itemSkillMax / 3) 
		{
			PlayerPrefs.SetFloat(skillName, curSkill + 0.75f);
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProfile : MonoBehaviour {

	private float currentSkill;
	private float itemMaxSkill;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("STR", 100);
		PlayerPrefs.SetInt ("INT", 100);
		PlayerPrefs.SetInt ("DEX", 100);

		PlayerPrefs.SetFloat ("Mining", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UseSkill(object[] skillInfo)
	{
		currentSkill = PlayerPrefs.GetFloat (skillInfo [0].ToString ());
		itemMaxSkill = (float) skillInfo[1];

		if (currentSkill <= itemMaxSkill / 3) 
		{
			PlayerPrefs.SetFloat((skillInfo[0].ToString()), currentSkill + 1.0f);
		}

		else if (currentSkill <= itemMaxSkill / 2) 
		{
			PlayerPrefs.SetFloat((skillInfo[0].ToString()), currentSkill + 0.5f);
		}

		else if (currentSkill > itemMaxSkill / 2 && currentSkill < itemMaxSkill) 
		{
			PlayerPrefs.SetFloat ((skillInfo [0].ToString ()), currentSkill + 0.25f);
		}

		else if (currentSkill >= itemMaxSkill) 
		{
			print ("Too high.");
		}
	}
}

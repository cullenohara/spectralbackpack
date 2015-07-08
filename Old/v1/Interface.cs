using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interface : MonoBehaviour {

	public int str;
	public int intel;
	public int dex;

	public Text strength;
	public Text intelligence;
	public Text dexterity;

	public float mining;

	public Text Mining;

	void Update () {
		//PLAYER STATS
		str = PlayerPrefs.GetInt ("STR");
		intel = PlayerPrefs.GetInt ("INT");
		dex = PlayerPrefs.GetInt ("DEX");
		//STATS TEXT
		strength.text = "STR: " + str.ToString ();
		intelligence.text = "INT: " + intel.ToString ();
		dexterity.text = "DEX: " + dex.ToString ();

		//PLAYER SKILLS
		mining = PlayerPrefs.GetFloat ("Mining");
		//SKILLS TEXT
		Mining.text = "Mining: " + mining.ToString () + "%";
	}
}

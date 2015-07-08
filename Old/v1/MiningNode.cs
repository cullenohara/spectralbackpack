using UnityEngine;
using System.Collections;

public class MiningNode : MonoBehaviour {
	
	public OreType ore;
	public bool spawnStarted = false;
	public bool hasSpawned = false;

	private float oreRarity;
	private Color nodeColor;
	private OreList getOre;
	private int oreAmount;
	private float reqSkill;

	private float randValue;
	private bool emptyNode = false;

	// Use this for initialization
	void Start () {
		nodeColor = this.GetComponent<MeshRenderer> ().material.color;
		getOre = GameObject.FindGameObjectWithTag ("oreList").GetComponent<OreList>();
		Spawn ();
	}

	void Update ()
	{
		if (oreAmount <= 0 && spawnStarted == false) 
		{
			emptyNode = true;
			this.GetComponent<MeshRenderer> ().material.color = nodeColor;
			StartCoroutine(SpawnCounter());
		}
	}

	IEnumerator SpawnCounter ()
	{
		spawnStarted = true;
		yield return new WaitForSeconds(3);
		Spawn ();
	}

	void Spawn ()
	{
		randValue = Random.value;
		print (randValue);
		for (int i = 0; i < getOre.oreList.Count; i++) 
		{
			if(getOre.oreList[i].rarity < randValue)
			{
				ore = getOre.oreList [i];
				oreAmount = ore.maxFound;
				reqSkill = ore.minSkill;
				this.GetComponent<MeshRenderer> ().material.color = ore.color;
				//What just spawned?
				print ("Spawned " + ore.name);
				spawnStarted = false;
				emptyNode = false;
				break;
			}
		}
	}

	
	void OnMouseDown () {
		if (!emptyNode)
		{
			if(PlayerPrefs.GetFloat(ore.skillUsed.ToString()) >= reqSkill) 
			{
				oreAmount --;
				object[] tempStorage = new object[2];
				tempStorage [0] = ore.skillUsed;
				tempStorage [1] = ore.maxSkill;
				GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerProfile> ().SendMessage ("UseSkill", tempStorage);
			}
			else
			{
				print ("Do not have the required skill.");
			}
		}
	}
}

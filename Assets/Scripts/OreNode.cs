using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OreNode : MonoBehaviour {

	private ItemDatabase database;
	private List<Item> ores = new List<Item>();
	public PlayerProfile player;

	public Transform ore;
	public Transform tempOre;

	public Item oreType;
	public int tempVeinType;
	public VeinType veinType;
	public int minCount;
	public int maxCount;
	public int oreCount;
	public bool spawning = false;

	public List<int> dropChances = new List<int>();
	public int dropCount;

	public enum VeinType
	{
		Tiny,
		Small,
		Medium,
		Large,
		Giant
	}

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag ("Database").GetComponent<ItemDatabase> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerProfile> ();

		for (int i = 0; i < database.items.Count; i++) 
		{
			if(database.items[i].itemMaterial == "Ore")
			{
				ores.Add(database.items[i]);
				dropChances.Add(database.items[i].itemDropChance);
			}
		}

		Spawn ();
	}

	void Update ()
	{
		if (oreCount <= 0 && spawning == false) 
		{
			spawning = true;
			Spawn();
		}
	}

	void Spawn()
	{
		spawning = false;
		dropCount = 0;
		for (int i = 0; i < dropChances.Count; i++) 
		{
			dropCount += dropChances[i];
		}
		int rand = Random.Range (0, dropCount);

		for (int j = 0; j < dropChances.Count; j++) 
		{
			if(rand <= ores[0].itemDropChance)
			{
				oreType = ores[0];
				transform.GetComponent<MeshRenderer> ().material.color = oreType.itemColor;
			}
			else if(dropChances[j] <= rand)
			{
				oreType = ores[j];
				transform.GetComponent<MeshRenderer> ().material.color = oreType.itemColor;
			}
		}

		tempVeinType = Random.Range (0, 5);
		GetVeinType ();
		SetVeinType ();

		oreCount = Random.Range(minCount, maxCount);
	}

	void GetVeinType ()
	{
		switch (tempVeinType) 
		{
		case 0:
			veinType = VeinType.Tiny;
			break;
		case 1:
			veinType = VeinType.Small;
			break;
		case 2:
			veinType = VeinType.Medium;
			break;
		case 3:
			veinType = VeinType.Large;
			break;
		case 4:
			veinType = VeinType.Giant;
			break;
		}
	}
	
	void SetVeinType ()
	{
		switch (veinType) 
		{
		case VeinType.Tiny:
			minCount = 1;
			maxCount = 2;
			break;
		case VeinType.Small:
			minCount = 1;
			maxCount = 3;
			break;
		case VeinType.Medium:
			minCount = 2;
			maxCount = 5;
			break;
		case VeinType.Large:
			minCount = 4;
			maxCount = 7;
			break;
		case VeinType.Giant:
			minCount = 6;
			maxCount = 10;
			break;
		}
	}

	void OnMouseDown()
	{
		if (PlayerPrefs.GetFloat ("Mining") >= oreType.itemMinSkill && oreCount > 0) {
			print ("You found " + oreType.itemName + " !");
			tempOre = Instantiate(ore, transform.position, transform.rotation) as Transform;
			tempOre.GetComponent<Rigidbody>().AddForce(transform.up * 500);
			tempOre.GetComponent<Ore>().oreColor = oreType.itemColor;
			tempOre.GetComponent<Ore>().oreName = oreType.itemName;
			tempOre.GetComponent<Ore>().oreRefID = oreType.itemID;
			oreCount--;
			object[] tempStorage = new object[2];
			tempStorage[0] = oreType.itemSkillReq.ToString();
			tempStorage[1] = oreType.itemMaxSkill;
			player.SendMessage("UseSkill", tempStorage, SendMessageOptions.DontRequireReceiver);
		} else {
			print ("You dig but find nothing at this location.");
		}
	}
}

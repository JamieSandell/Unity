using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {
    [SerializeField] [Range(0f, 100f)] float[] dropChance;
    [SerializeField] GameObject[] lootPrefab;

//gameObjectPrefab, dropChance,

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DropLoot()
    {
        float randomNumber = UnityEngine.Random.value; // between 0.0 and 1.0 inclusive
        randomNumber *= 100f;
        Debug.Log("DropLoot - Random Number = " + randomNumber.ToString());
        
        for(int lootPrefabElement = 0; lootPrefabElement < lootPrefab.Length; lootPrefabElement++)
        {
            if (randomNumber <= dropChance[lootPrefabElement])
            {
                Instantiate(lootPrefab[lootPrefabElement], transform.position, Quaternion.identity);
            }
        }
    }
}

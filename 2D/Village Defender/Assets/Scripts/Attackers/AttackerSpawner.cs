using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    private bool spawn = true;
    [SerializeField] float minTimeToSpawn = 1f;
    [SerializeField] float maxTimeToSpawn = 5f;
    [SerializeField] Attacker[] attackerPrefabs = null;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeToSpawn, maxTimeToSpawn));
            SpawnAttacker();
        }
    }

    private void Spawn(Attacker attacker)
    {
        Debug.Log("Spawned at: " + (int)Time.time + " seconds.");
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private void SpawnAttacker()
    {
        //One last check, as it's possible spawn was set to false during the while loop, meaning this can still be called even if spawn is false
        if (spawn)
        {
            int attackerPrefabsCount = attackerPrefabs.Length;
            int attackerIndex = Random.Range(0, attackerPrefabsCount);
            Spawn(attackerPrefabs[attackerIndex]);
        }        
    }

    public void StopSpawning()
    {
        spawn = false;
    }
}

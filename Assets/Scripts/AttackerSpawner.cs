using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;

    LevelController levelController;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;

    [SerializeField] Attacker[] attackerList;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        levelController = FindObjectOfType<LevelController>();
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerList.Length);
        Attacker attacker = attackerList[attackerIndex];
        Spawn(attacker);
        
        
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }

    

}

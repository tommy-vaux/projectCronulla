using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform spawnLocation;

    public int wave = 1;

    private bool waiting = false;

    private void Update()
    {
        if(!waiting)
        {
            StartCoroutine(enemySpawn());
        }
        
    }

    IEnumerator enemySpawn ()
    {
        waiting = true;
        Instantiate(enemy, spawnLocation.position, Quaternion.identity);
        yield return new WaitForSeconds(1 / wave * 0.5f);
        waiting = false;
    }
}

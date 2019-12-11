using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveController : MonoBehaviour
{
    
    [Header("Enemies")]
    public GameObject basicEnemy; // wave * 5 = #basicEnemy
    public GameObject heavyEnemy; // wave * 2 = #heavyEnemy
    public GameObject trojanEnemy; // if wave >= 10: wave/10 = #trojanEnemy
    private int spawnType = 0;
    



    [Header("Misc")]
    public int WAVE = 1;
    public Transform spawnLocation;


    private Stack<GameObject> enemies;

    private bool waveWaiting = false;
    private bool spawnWaiting = false;


    // Update is called once per frame
    void Update()
    {
        if(!waveWaiting)
        {
            StartCoroutine(waitForWave());
        }
    }
    // every ten seconds...
    IEnumerator waitForWave()
    {
        waveWaiting = true;
        spawnType = 0;
        StartCoroutine(enemySpawn());

        yield return new WaitForSeconds(10.0f);
        waveWaiting = false;
    }
    IEnumerator enemySpawn()
    {
        spawnWaiting = true;
        
        addEnemy(spawnType);
        spawnType++;
        WAVE++;
        yield return new WaitForSeconds(1 / WAVE * 0.5f);
        spawnWaiting = false;
    }
    void addEnemy(int type)
    {
        //  add basics (top
        if (type == 0)
            for (int i = 0; i <= WAVE * 5; i++)
            {
                {
                    Debug.Log("spawned " + WAVE * 5 + " basics");
                    GameObject enemyInstance = Instantiate(basicEnemy, spawnLocation.position, Quaternion.identity);

                }
            }
        //  add heavies (middle)
        else if (type == 1)
        {
            for (int i = 0; i <= WAVE * 2; i++)
            {
                Debug.Log("spawned " + WAVE * 2 + " heavies");
                GameObject enemyInstance = Instantiate(heavyEnemy, spawnLocation.position, Quaternion.identity);

            }
        }
        //  add trojans (bottom)
        else if (type == 2)
        {
            if (WAVE >= 10)
            {
                for (int i = 0; i <= WAVE / 10; i++)
                {
                    Debug.Log("spawned " + WAVE / 10 + " trojans");
                    GameObject enemyInstance = Instantiate(trojanEnemy, spawnLocation.position, Quaternion.identity);

                }
            }
        }
    }
}

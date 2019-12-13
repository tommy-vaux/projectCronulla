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
    public gameController controller;

    private Stack<GameObject> enemies;

    private bool waveWaiting = false;
    private bool spawnWaiting = false;

    private void Start()
    {
        controller = GetComponent<gameController>();

        controller.wave = WAVE;
    }

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
        StartCoroutine(spawnBasic());
        StartCoroutine(spawnPinata());
        StartCoroutine(spawnTrojan());
        WAVE++;
        controller.wave = WAVE;
        yield return new WaitForSeconds(20.0f);
        waveWaiting = false;
    }
    
        
   
    IEnumerator spawnBasic()
    {
        spawnWaiting = true;
        for (int i = 0; i <= WAVE * 3; i++)
        {
            {
                //Debug.Log("spawned " + WAVE * 5 + " basics");
                GameObject enemyInstance = Instantiate(basicEnemy, spawnLocation.position, Quaternion.identity);

            }
        }
        yield return new WaitForSeconds(1 / WAVE * 0.5f);
        spawnWaiting = false;
    }
    IEnumerator spawnPinata() {
        spawnWaiting = true;

        for (int i = 0; i <= WAVE * 2; i++)
        {
            //Debug.Log("spawned " + WAVE * 2 + " heavies");
            GameObject enemyInstance = Instantiate(heavyEnemy, spawnLocation.position, Quaternion.identity);

        }
        yield return new WaitForSeconds(1 / WAVE * 0.5f);
        spawnWaiting = false;
    }
    IEnumerator spawnTrojan() {
        spawnWaiting = true;

        if (WAVE >= 10)
        {
            for (int i = 0; i <= WAVE / 10; i++)
            {
                //Debug.Log("spawned " + WAVE / 10 + " trojans");
                GameObject enemyInstance = Instantiate(trojanEnemy, spawnLocation.position, Quaternion.identity);

            }
        }
        yield return new WaitForSeconds(1 / WAVE * 0.5f);
        spawnWaiting = false;
    }
        
  
}

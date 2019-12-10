using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script handles: Economy, other 
public class gameController : MonoBehaviour
{

    [Header("Economy")]
    public int health = 0;
    public int candy = 0;

    [Header("Progress")]
    public int score = 0;
    public int wave = 0;

    [Header("Starting Data")]
    public int startHealth = 100;
    public int startCandy = 500;

    // Settings
    int gameSpeedChosen = 0;
    float[] speeds = {0.5f, 1f, 2f, 5f, 10f};

    Collider a;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        candy = startCandy;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyController>().reachedEnd = true;
        }
    }

    public void changeGameSpeed()
    {
        if(gameSpeedChosen < 4)
        {
            gameSpeedChosen++;
        } else
        {
            gameSpeedChosen = 0;
        }
        

        Time.timeScale = speeds[gameSpeedChosen];
    }
}

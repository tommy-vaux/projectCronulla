using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingController : MonoBehaviour
{

    public building data;

    public enemyDetector detector;

    private bool attackedEnemies = true;

    // Start is called before the first frame update
    void Start()
    {
        // apply stats from data
        detector.thisCollider.radius = data.range;
    }

    // Update is called once per frame
    void Update()
    {
        if(attackedEnemies && detector.enemiesInRange.Count > 0)
        {
            StartCoroutine(attackFurthestEnemy());
        }
    }
    // attacks the first enemy in the array of enemies in range
    IEnumerator attackFurthestEnemy()
    {
        attackedEnemies = false;
        Debug.Log("Attacking the enemy for " + data.damage + " damage");
        // damage the hit enemy
        detector.enemiesInRange[0].gameObject.GetComponent<enemyController>().currentHealth -= data.damage;
        // wait for the cooldown to finish
        yield return new WaitForSeconds(data.cooldown);
        attackedEnemies = true;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDetector : MonoBehaviour
{

    public List<Collider> enemiesInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Debug.Log("Enemy entered range - " + other.gameObject.name);
            enemiesInRange.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            Debug.Log("Enemy left range - " + other.gameObject.name);
            enemiesInRange.Remove(other);
        }
    }
}
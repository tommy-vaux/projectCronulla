using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{

    public NavMeshAgent agent;

    public enemy data;

    public float currentHealth;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = data.health;
        agent.speed = data.speed;


        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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

    public AudioSource sound;

    bool destroying = false;

    public bool reachedEnd = false;

    public gameController controller;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        controller = GameObject.Find("GAME CONTROLLER").GetComponent<gameController>();

        currentHealth = data.health;
        agent.speed = data.speed;
        agent.destination = target.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            // play animation, give player money, destroy this object
            if(!destroying)
            {
                StartCoroutine(onDestroyed());
            }
            
        }

        if(reachedEnd)
        {
            controller.health -= data.damage;

            Object.Destroy(this.gameObject);
        }
    }

    IEnumerator onDestroyed()
    {
        destroying = true;
        agent.speed = 0;
        agent.enabled = false;

        sound.clip = data.death;
        sound.Play();

        yield return new WaitForSeconds(1);

        Object.Destroy(this.gameObject);
    }

}

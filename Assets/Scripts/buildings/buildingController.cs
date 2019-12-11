using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingController : MonoBehaviour
{

    public building data;

    public enemyDetector detector;

    private bool attackedEnemies = true;

    public Transform turret;

    Vector2 currentTarget;

    private AudioSource buildingAudio;
    public Animator buildingAnim;

    public bool flipTurretDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        // apply stats from data
        detector.thisCollider.radius = data.range;
        buildingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackedEnemies && detector.enemiesInRange.Count > 0)
        {
            StartCoroutine(attackFurthestEnemy());
            if(turret != null)
            {
                aimGun();
            }
            
        }
    }

    void aimGun() // for gatling gun and cannon
    {
        var heading = currentTarget - new Vector2(transform.position.x, transform.position.z);
        Quaternion rotation = Quaternion.identity;
        if (flipTurretDirection)
        {
             rotation = Quaternion.LookRotation(-heading, Vector3.zero);
        } else
        {
             rotation = Quaternion.LookRotation(heading, Vector3.zero);
        }
           
        turret.rotation = rotation;
    }

    void animationAndSound()
    {
        if(detector.enemiesInRange[0] != null)
        { // enemy in range
            buildingAudio.clip = data.attack;
            buildingAudio.Play();


        } else
        {
            //buildingAnim.
        }
    }
    // attacks the first enemy in the array of enemies in range
    IEnumerator attackFurthestEnemy()
    {
        attackedEnemies = false;
        
        // damage the hit enemy
        if (detector.enemiesInRange[0] != null)
        {
            Debug.Log("Attacking the enemy for " + data.damage + " damage");
            detector.enemiesInRange[0].gameObject.GetComponent<enemyController>().currentHealth -= data.damage;
            currentTarget = new Vector2(detector.enemiesInRange[0].transform.position.x, detector.enemiesInRange[0].transform.position.z);
            if (detector.enemiesInRange[0].gameObject.GetComponent<enemyController>().currentHealth <= 0)
            {
                detector.enemiesInRange.RemoveAt(0);
            }
        }
        // wait for the cooldown to finish
        yield return new WaitForSeconds(data.cooldown);
        attackedEnemies = true;
    }

    
}

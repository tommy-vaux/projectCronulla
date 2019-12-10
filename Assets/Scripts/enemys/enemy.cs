using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// right click -> create -> add enemy to create a data asset using this code

[CreateAssetMenu(fileName = "enemy", menuName = "Add Enemy", order = 1)]
public class enemy : ScriptableObject
{
    [Header("Stats")]
    public float health;
    public float speed;
    public float value;
    public int damage; // damage done to player health if it reaches the end

    [Header("Sound")]
    public AudioClip moving; // only used 
    public AudioClip hit;
    public AudioClip idle; // may not be used
    public AudioClip death;

    [Header("Graphics")]
    public GameObject model;
}

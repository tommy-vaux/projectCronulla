using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// right click -> create -> add building to create a data asset using this code

[CreateAssetMenu(fileName = "building", menuName = "Add Building", order = 1)]
public class building : ScriptableObject
{
    [Header("Stats")]
    public float range;
    public float damage;
    public float cooldown;
    public float cost;
    
    [Header("Sound")]
    public AudioClip attack;
    public AudioClip place;

    [Header("Graphics")]
    public GameObject model;
    
}

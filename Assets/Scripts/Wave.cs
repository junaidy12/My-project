using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int amountToSpawn;
    public float delayBeforeSpawn;
    public float delayBetweenEnemy;
    public Color color;

    [HideInInspector] public bool isSpawning = false;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{

    public int amountToSpawn;

    public float delayBeforeSpawn;
    public float delayBetweenEachSpawn;

    public bool isSpawning = false;
    public Color color;

    public bool finishSpawning = false;

    public List<Enemy> enemiesRef = new List<Enemy>();
}

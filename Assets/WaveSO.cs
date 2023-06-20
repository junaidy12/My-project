using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSO", menuName = "Level")]
public class WaveSO : ScriptableObject
{
    [SerializeField] float delayBetweenWave;
    [SerializeField] Wave[] waves;

    public Wave GetWave(int level)
    {
        return waves[level];
    }

    public int GetWaveLength()
    {
        return waves.Length;
    }

    public float GetDelayBetweenWave()
    {
        return delayBetweenWave;
    }
}

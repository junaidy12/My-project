using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool isAlive = true;
    //[SerializeField] int playerLiveDamage = 1;

    private void OnEnable()
    {
        isAlive = true;
    }
    public void Kill()
    {
        isAlive = false;
    }

    public bool GetAlive()
    {
        return isAlive;
    }

}

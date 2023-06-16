using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] int towerPrice;

    private void Start()
    {
    }
    public int GetPrice()
    {
        return towerPrice;
    }
}

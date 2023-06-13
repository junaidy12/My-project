using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHolder : MonoBehaviour
{
    bool isOccupied = false;
    Turret turret;
    private void Update()
    {

    }

    public void SetTurret(Turret turret)
    {
        this.turret = turret;
        isOccupied = true;
    }

    public void DeleteTurret()
    {
        turret = null;
        isOccupied = false;
    }

    public bool GetOccupied()
    {
        return isOccupied;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool isAlive = true;
    [SerializeField] int moneyAward;
    //[SerializeField] int playerLiveDamage = 1;

    private void OnEnable()
    {
        isAlive = true;
    }
    public void Kill()
    {
        BankManager.Instance.AddMoney(moneyAward);
        isAlive = false;
    }

    public bool GetAlive()
    {
        return isAlive;
    }

}

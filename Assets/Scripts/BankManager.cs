using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager Instance;
    [SerializeField] int startMoney;

    int currentMoney;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        currentMoney = startMoney;
    }
    public int GetMoney()
    {
        return currentMoney;
    }
    public void AddMoney(int value)
    {
        currentMoney += value;
    }

    public void SpendMoney(int value)
    {
        currentMoney -= value;
    }
}

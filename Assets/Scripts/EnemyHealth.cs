using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float baseHealth = 10;

    float currentHealth;

    bool immune = true;
    private void OnEnable()
    {
        currentHealth = baseHealth;
        immune = true;
    }
    public bool GetImmune()
    {
        return immune;
    }
    public void RemoveImmune()
    {
        immune = false;
    } 

    public void Damage(float value)
    {
        if (immune) return;
        currentHealth -= value;

        Debug.Log(gameObject.name + " damaged!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        GetComponent<Enemy>().Kill();
        Debug.Log(name + " died!");
    }
}

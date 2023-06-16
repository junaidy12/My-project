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
        Debug.Log("exit immune");
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
    void Die()
    {
        gameObject.SetActive(false);
        GetComponent<Enemy>().Kill();
        Debug.Log(name + " died!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveImmune();
    }
    private void OnParticleCollision(GameObject other)
    {
        TowerShooter tower = other.GetComponentInParent<TowerShooter>();
        if(tower != null)
        {
            Debug.Log(gameObject + " get hit!");
            Damage(tower.GetDamage());
        }
    }

   
}

using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    [SerializeField] float baseDamage;
    [SerializeField] float baseAttackSpeed;

    Collider2D target;
    TargetLocator targetLocator;
    float timeBeforeNextAttack;
    private void Start()
    {
        targetLocator = GetComponent<TargetLocator>();
        timeBeforeNextAttack = 0.2f;
    }
    private void Update()
    {
        timeBeforeNextAttack -= Time.deltaTime;
        

        Shoot();

    }

    void Shoot()
    {
        target = targetLocator.GetTarget();
        if (target == null)
        {
            targetLocator.FindNearestEnemy();
            return;
        }

        if (!target.GetComponent<Enemy>().GetAlive())
        {
            targetLocator.FindNearestEnemy();
            return;
        }

        if (target.GetComponent<EnemyHealth>().GetImmune()) return;

        if (timeBeforeNextAttack <= 0)
        {
            target.GetComponent<EnemyHealth>().Damage(baseDamage);
            timeBeforeNextAttack = 1 / baseAttackSpeed;
        }
    }
}

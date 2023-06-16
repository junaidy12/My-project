using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    [SerializeField] float baseDamage;
    [SerializeField] float baseAttackSpeed;
    [SerializeField] ParticleSystem projectilePrefab;


    Collider2D target;
    TargetLocator targetLocator;
    float timeBeforeNextAttack;
    private void Start()
    {
        targetLocator = GetComponent<TargetLocator>();
        var main = projectilePrefab.emission;
        main.rateOverTime = baseAttackSpeed;
        timeBeforeNextAttack = 0.2f;
    }
    private void Update()
    {
        timeBeforeNextAttack -= Time.deltaTime;

        var emmision = projectilePrefab.emission;
        emmision.enabled = Shoot();

    }
    public Collider2D GetTarget()
    {
        return target;
    }
    public float GetDamage()
    {
        return baseDamage;
    }
    bool Shoot()
    {
        target = targetLocator.GetTarget();
        if (target == null) return false;

        if (!target.GetComponent<Enemy>().GetAlive()) return false;
        
        if (target.GetComponent<EnemyHealth>().GetImmune()) return false;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance < targetLocator.GetRange())
        {
            return true;
        }

        return false;
    }
}

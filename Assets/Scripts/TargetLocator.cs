using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] Collider2D target;
    [SerializeField] LayerMask enemyLayerMask;


    Collider2D[] enemiesInRange;
    void Start()
    {

    }

    void Update()
    {
        if (target == null)
        {
            target = FindNearestEnemy();
        }
        if (target != null && !target.GetComponent<Enemy>().GetAlive())
        {
            target = FindNearestEnemy();
        }
    }

    public Collider2D GetTarget()
    {
        return target;
    }

    public float GetRange()
    {
        return range;
    }

    public Collider2D FindNearestEnemy()
    {

        enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range, enemyLayerMask);
        //if (prevTarget != null) return prevTarget.GetComponent<Collider2D>();
        Collider2D enemyClosest = null;
        foreach (var enemy in enemiesInRange)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < range)
            {
                enemyClosest = enemy;
            }
        }
        return enemyClosest;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

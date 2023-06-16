using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    TargetLocator targetLocator;
    private void Start()
    {
        targetLocator = GetComponentInParent<TargetLocator>();
    }
    private void Update()
    {
        if (targetLocator.GetTarget() == null) return;
        Vector3 direction = (targetLocator.GetTarget().transform.position - transform.position).normalized;
        transform.forward = direction;
    }
}

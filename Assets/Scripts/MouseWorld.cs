using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld Instance;
    [SerializeField] Turret towertest;
    [field: SerializeField] RaycastHit hittest;
    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TurretHolder turretHolder = GetHitObject().transform.GetComponentInParent<TurretHolder>();
            if(turretHolder != null)
            {
                if (!turretHolder.GetOccupied())
                {
                    Turret turret = Instantiate(towertest, turretHolder.transform.position, Quaternion.identity);
                    turretHolder.SetTurret(turret);
                }
            }
        }
    }

    [SerializeField] LayerMask mousePlaneLayerMask;
    public RaycastHit GetHitObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, mousePlaneLayerMask);
        return hit;
    }
}

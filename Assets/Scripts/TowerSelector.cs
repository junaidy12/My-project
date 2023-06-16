using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public static TowerSelector Instance;
    [SerializeField] Turret[] turrets;
    [field: SerializeField] RaycastHit hittest;

    Turret selectedTurret;
    private void Awake()
    {
        
    }

    private void Update()
    {
        SelectTurret();
        PlaceTurret();
    }

    private void PlaceTurret()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TurretHolder turretHolder = GetHitObject().transform.GetComponentInParent<TurretHolder>();
            if (turretHolder != null)
            {
                if (!turretHolder.GetOccupied() && selectedTurret != null && BankManager.Instance.GetMoney() >= selectedTurret.GetPrice())
                {
                    Turret turret = Instantiate(selectedTurret, turretHolder.transform.position, Quaternion.identity);

                    turretHolder.SetTurret(turret);
                }
            }
        }
    }

    void SelectTurret()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedTurret = turrets[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTurret = turrets[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTurret = turrets[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedTurret = turrets[3];
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

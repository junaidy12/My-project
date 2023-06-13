using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneArea : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.RemoveImmune();
        }
    }
}

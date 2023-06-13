using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Transform[] waypoints;

    Vector2 startPosition;
    Vector2 endPosition;
    int i = 0;
    
    private void OnEnable()
    {
        waypoints = Waypoints.Instance.GetWaypoints();
        transform.position = waypoints[0].position;
        i = 0;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {   
        startPosition = waypoints[i].position;
        endPosition = waypoints[i+1].position;

        Vector3 dir = (endPosition - startPosition).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[i + 1].position) <= .1f)
        {
            i++;
            if(i >= waypoints.Length - 1)
            {
                //damage player & destroy game object

                gameObject.SetActive(false);
            }
        }
    }


}

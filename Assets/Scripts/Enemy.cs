using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void GetNextWaypoint(){
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void Start(){
        target = Waypoints[0];
    }

    void Update(){
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector2.Distance(transform.position, target.position) <= 0.2){
            GetNextWaypoint();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour{
    public static Transform[] points;

    void Awake(){
        for(int i = 0; i < transform.childCount; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}

using UnityEngine;

public class Waypoints : MonoBehaviour{
    public static Transform[] points;

    void Awake(){
        points = Transform[transform.childCount];
        for(int i = 0; i < points.length; i++){
            points[i] = transform.GetChild(i);
        }
    }
}

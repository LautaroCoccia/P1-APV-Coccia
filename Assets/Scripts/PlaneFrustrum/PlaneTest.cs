using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class PlaneTest : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        Vec3 A = new Vec3(-15, -5, -29.7f);
        Vec3 B = new Vec3(-5, 10, 0.3f);

        Vector3 C = new Vector3(-15, -5, -29.7f);
        Vector3 D = new Vector3(-5, 10, 0.3f);
        Plane Z = new Plane(C, D);
        MyPlane b = new MyPlane(A, B);
        Debug.Log("DISTANCE : " + Z.distance);
        Debug.Log("NORMAL : " + Z.normal);
        Debug.Log("distance : " + b.distance);
        Debug.Log("normal : " + b.normal);
        Debug.Log("GETDISTANCE" + Z.ClosestPointOnPlane(C));
        Debug.Log("getDistance" + b.ClosestPointOnPlane(A));
        Debug.Log("angle" + Vector3.Angle(A,B));
        Debug.Log("ANGLE" + Vec3.Angle(A, B));
    }
}

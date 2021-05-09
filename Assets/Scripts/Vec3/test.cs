using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class test : MonoBehaviour
{
    public float t = 0.5f;
    public float maxLenght = 5;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 c = new Vector3(2, 4, 6);
        Vector3 d = new Vector3(7, 6, 5);

        Vec3 a = new Vec3(c);
        Vec3 b = new Vec3(d);

        #region FUNCIONA_ANGLE
        // Debug.Log("Vec3.Angle: " + Vec3.Angle(a, b));
        // Debug.Log("Vector3.Angle: " + Vector3.Angle(c, d));
        // Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_CLAMP_MAGNITUDE
        //Debug.Log("Vec3.ClampMagnitude: " + Vec3.ClampMagnitude(a, maxLenght)); 
        //Debug.Log("Vector3.ClampMagnitude: " + Vector3.ClampMagnitude(c, maxLenght));
        //Debug.Log("-----------------------------------------");
        #endregion
        #region FUNCIONA_MAGNITUDE
        //Debug.Log("Vec3.Magnitude: " + Vec3.Magnitude(a));
        //Debug.Log("Vector3.Magnitude: " + Vector3.Magnitude(c));
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_CROSS
        //Debug.Log("Vec3.Cross: " + Vec3.Cross(a, b));
        //Debug.Log("Vector3.Cross: " + Vector3.Cross(c, d));
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_DISTANCE
        //Debug.Log("Vec3.Distance: " + Vec3.Distance(a, b));
        //Debug.Log("Vector3.Distance: " + Vector3.Distance(c, d));
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_DOT
        //Debug.Log("Vec3.Dot: " + Vec3.Dot(a, b));
        //Debug.Log("Vector3.Dot: " + Vector3.Dot(c, d));
        //Debug.Log("-----------------------------------------");
        #endregion

        //APARENTA FUNCIONAR
        Debug.Log("Vec3.Lerp: " + Vec3.Lerp(a, b, t));
        Debug.Log("Vector3.Lerp: " + Vector3.Lerp(c, d, t));
        Debug.Log("-----------------------------------------");
        //APARENTA FUNCIONAR
        Debug.Log("Vec3.LerpUnclamped: " + Vec3.LerpUnclamped(a, b, t));
        Debug.Log("Vector3.LerpUnclamped: " + Vector3.LerpUnclamped(c, d, t));
        Debug.Log("-----------------------------------------");

        #region FUNCIONA_MAX
        //Debug.Log("Vec3.Max: " + Vec3.Max(a, b)); //RESULTADO X=9 Y= 10 Z = 11
        //Debug.Log("Vector3.Max: " + Vector3.Max(c, d)); //RESULTADO X=7 Y=6 Z=6
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_MIN
        //Debug.Log("Vec3.Min: " + Vec3.Min(a, b)); // RESULTADO X= -5 Y=-2 Z=1
        //Debug.Log("Vector3.Min: " + Vector3.Min(c, d));//RESULTADO X=2 Y=4 Z=5
        //Debug.Log("-----------------------------------------");
        #endregion

        Debug.Log("Vec3.SqrMagnitude: " + Vec3.SqrMagnitude(a));
        Debug.Log("Vector3.SqrMagnitude: " + Vector3.SqrMagnitude(c));
        Debug.Log("-----------------------------------------");

        #region FUNCIONA_PROJECT
        //Debug.Log("Vec3.Project: " + Vec3.Project(a, b));
        //Debug.Log("Vector3.Project: " + Vector3.Project(c, d));
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_SCALE
        //b.Scale(a);
        //Debug.Log("Vector3.Scale: " + b);
        //d.Scale(c);
        //Debug.Log("Vector3.Scale: " + d);
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_REFLECT
        //Debug.Log("Vec3.Reflect: " + Vec3.Project(a, b));
        //Debug.Log("Vector3.Reflect: " + Vector3.Project(c, d));
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_NORMALIZE
        //a.Normalize();
        //Debug.Log("Vec3.Normalize: " + a);
        //c.Normalize();
        //Debug.Log("Vector3.Normalize: " + c);
        #endregion
    }
}

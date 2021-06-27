using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class test : MonoBehaviour
{
    [SerializeField] Transform obj1;
    [SerializeField] Transform obj2;

    [SerializeField] Vector3 xyz;
    public float t = 0.5f;
    public float maxLenght = 5;
    [SerializeField] float angle;
    // Start is called before the first frame update
    Vector3 c = new Vector3(2, 4, 6);
    Vector3 d = new Vector3(7, 6, 10);

    Vec3 a;
    Vec3 b;

    Quaternion _c;
    Quaternion _d;
    Quater _c_;
    Quater _d_;
    void Start()
    {
        a = new Vec3(c);
        b = new Vec3(d);
        _c = new Quaternion(xyz.x, xyz.y, xyz.z, 1);
        _d = new Quaternion(d.x, d.y, d.z, 1);
        _c_ = new Quater(xyz.x, xyz.y, xyz.z, 1);
        _d_ = new Quater(d.x, d.y, d.z, 1);
        #region VEC3
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

        #region FUNCIONA_LERP
        //Debug.Log("Vec3.Lerp: " + Vec3.Lerp(a, b, t));
        //Debug.Log("Vector3.Lerp: " + Vector3.Lerp(c, d, t));
        //Debug.Log("-----------------------------------------");
        #endregion

        #region FUNCIONA_LERPUNCLAMP
        //Debug.Log("Vec3.LerpUnclamped: " + Vec3.LerpUnclamped(a, b, t));
        //Debug.Log("Vector3.LerpUnclamped: " + Vector3.LerpUnclamped(c, d, t));
        //Debug.Log("-----------------------------------------");
        #endregion

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

        #region FUNCIONA_SQRMAGNITUDE
        //Debug.Log("Vec3.SqrMagnitude: " + Vec3.SqrMagnitude(a));
        //Debug.Log("Vector3.SqrMagnitude: " + Vector3.SqrMagnitude(c));
        //Debug.Log("-----------------------------------------");
        #endregion

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
        #endregion

        #region QUATER
        #region FUNCIONA_DOT
        //Debug.Log("QUATERNION DOT");
        //Debug.Log( Quaternion.Dot(_c, _d));
        //Debug.Log("Quater DOT");
        //Debug.Log( Quater.Dot(_c_, _d_));
        #endregion

        //Debug.Log("QUATERNION EULER " + Quaternion.Euler(d));
        //Debug.Log("QUATER EULER " + Quater.Euler(d));
        #endregion
        Quater q = _c_ ;
        Quaternion _q = _c ;

        //Debug.Log("Multiplicacion de Quater " + q.ToString());
        //Debug.Log("Multiplicacion de Quaternion " + _q.ToString());
        Quaternion test = Quaternion.Euler(xyz);
        //Debug.Log("Euler de Quater float " + Quater.Euler(xyz.x, xyz.y, xyz.z));
        //Debug.Log("Euler de Quater vector3 " + Quater.Euler(xyz));
        //Debug.Log("Euler de Quaterion " + "X: " + test.x + " Y: " + test.y +" Z: " + test.z + " W: " + test.w);
        //Debug.Log("---------------------------------");
        //Debug.Log("QUATERNION INVERSE" + Quaternion.Inverse(_c));
        //Debug.Log("Quater INVERSE" + Quater.Inverse(_c_));
        Debug.Log("---------------------------------");
        test = Quaternion.AngleAxis(angle, Vector3.up);
        Debug.Log(" QUATERNION AngleAxis" + "X: " + test.x + " Y: " + test.y + " Z: " + test.z + " W: " + test.w);
        Debug.Log(" Quater AngleAxis" + Quater.AngleAxis(angle, Vec3.Up));
        Debug.Log("---------------------------------");
        test = Quaternion.Normalize(_c);
        Debug.Log("QUATERNION NORMALIZE " + "X: " + test.x + " Y: " + test.y + " Z: " + test.z + " W: " + test.w);
        Debug.Log(" Quater NORMALIZE " + Quater.Normalize(_c_));
        //Debug.Log("---------------------------------");
        //Debug.Log("Quaternion Angle: " + Quaternion.Angle(obj1.rotation, obj2.rotation));
        //Debug.Log("Quater Angle: " +Quater.Angle(new Quater(obj1.rotation), new Quater(obj2.rotation)));
        Debug.Log("---------------------------------");
        test = Quaternion.Lerp(_c, _d, t);
        Debug.Log("QUATERNION LERP " + "X: " + test.x + " Y: " + test.y + " Z: " + test.z + " W: " + test.w);
        Debug.Log("Quater LERP " + Quater.Lerp(_c_, _d_, t));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("---------------------------------");
            Debug.Log("QUATERNION SLEEP " + Quaternion.Slerp(_c, _d, t));
            Debug.Log("Quater SLEEP " + Quater.Slerp(_c_, _d_, t));
        }
       // Debug.Log("---------------------------------");
       // Debug.Log("QUAtTERNION SLEEPUNCLAMPED " + Quaternion.SlerpUnclamped(_c, _d, t));
       // Debug.Log("Quater SLEEPUNCLAMPED " + Quater.SlerpUnclamped(_c_, _d_, t));
    }
}

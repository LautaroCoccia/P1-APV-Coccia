using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct Matriz4x4 
{
    public float m00;
    public float m33;
    public float m23;
    public float m13;
    public float m03;
    public float m32;
    public float m22;
    public float m02;
    public float m12;
    public float m21;
    public float m11;
    public float m01;
    public float m30;
    public float m20;
    public float m10;
    public float m31;

    public Matriz4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
    {
        m00 = column0.x; m01 = column1.x; m02 = column2.x; m03 = column3.x;
        m10 = column0.y; m11 = column1.y; m12 = column2.y; m13 = column3.y;
        m20 = column0.z; m21 = column1.z; m22 = column2.z; m23 = column3.z;
        m30 = column0.w; m31 = column1.w; m32 = column2.w; m33 = column3.w;
    }
    public float this[int index] 
    { 
        get 
        {
            switch(index)
            {
                case 0:
                    return m00;
                case 1:
                    return m01;
                case 2:
                    return m02;
                case 3:
                    return m03;
                case 4:
                    return m10;
                case 5:
                    return m11;
                case 6:     
                    return m12;
                case 7:     
                    return m13;
                case 8:
                    return m20;
                case 9:
                    return m21;
                case 10:
                    return m22;
                case 11:
                    return m23;
                case 12:
                    return m30;
                case 13:
                    return m31;
                case 14:
                    return m32;
                case 15:
                    return m33;
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
            
        } 
        set; }
    //public float this[int row, int column] { get; set; }

    public static Matriz4x4 zero { get {
            Vector4 vec1 = new Vector4(0f, 0f, 0f, 0f);
            Vector4 vec2 = new Vector4(0f, 0f, 0f, 0f);
            Vector4 vec3 = new Vector4(0f, 0f, 0f, 0f);
            Vector4 vec4 = new Vector4(0f, 0f, 0f, 0f);
            return new Matriz4x4(vec1, vec2, vec3, vec4);
        }
    }
    //public static Matriz4x4 identity { get; }
    //public Matriz4x4 transpose { get; }
    //public Quaternion rotation { get; }
    //public Vector3 lossyScale { get; }
    //
    //public Matriz4x4 inverse { get; }
    //public static Matriz4x4 Inverse(Matriz4x4 m);
    //public static Matriz4x4 Rotate(Quaternion q);
    //public static Matriz4x4 Scale(Vector3 vector);
    //public static Matriz4x4 Translate(Vector3 vector);
    //public static Matriz4x4 Transpose(Matriz4x4 m);
    //public static Matriz4x4 TRS(Vector3 pos, Quaternion q, //Vector3 s);
    //public override bool Equals(object other);
    //public bool Equals(Matriz4x4 other);
    //public Vector4 GetColumn(int index);
    //public Vector3 MultiplyPoint(Vector3 point);
    //public Vector3 MultiplyPoint3x4(Vector3 point);
    //public Vector3 MultiplyVector(Vector3 vector);
    //public void SetColumn(int index, Vector4 column);
    //public void SetRow(int index, Vector4 row);
    //public void SetTRS(Vector3 pos, Quaternion q, Vector3 s);
    //public override string ToString();
    //public static Vector4 operator *(Matriz4x4 lhs, Vector4 vector);
    //public static Matriz4x4 operator *(Matriz4x4 lhs, Matriz4x4 rhs);
    //public static bool operator ==(Matriz4x4 lhs, Matriz4x4 rhs);
    //public static bool operator !=(Matriz4x4 lhs, Matriz4x4 rhs);
}

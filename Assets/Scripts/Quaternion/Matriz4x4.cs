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
        throw new NotImplementedException();
    }
    //public float this[int index] { get; set; }
    //public float this[int row, int column] { get; set; }

    //public static Matriz4x4 zero { get; }
    //public static Matriz4x4 identity { get; }
    public Matriz4x4 transpose { get; }
    public Quaternion rotation { get; }
    public Vector3 lossyScale { get; }

    public Matriz4x4 inverse { get; }
    public static Matriz4x4 Inverse(Matriz4x4 m);
    public static Matriz4x4 Rotate(Quaternion q);
    public static Matriz4x4 Scale(Vector3 vector);
    public static Matriz4x4 Translate(Vector3 vector);
    public static Matriz4x4 Transpose(Matriz4x4 m);
    public static Matriz4x4 TRS(Vector3 pos, Quaternion q, Vector3 s);
    public override bool Equals(object other);
    public bool Equals(Matriz4x4 other);
    public Vector4 GetColumn(int index);
    public Vector3 MultiplyPoint(Vector3 point);
    public Vector3 MultiplyPoint3x4(Vector3 point);
    public Vector3 MultiplyVector(Vector3 vector);
    public void SetColumn(int index, Vector4 column);
    public void SetRow(int index, Vector4 row);
    public void SetTRS(Vector3 pos, Quaternion q, Vector3 s);
    public override string ToString();
    public static Vector4 operator *(Matriz4x4 lhs, Vector4 vector);
    public static Matriz4x4 operator *(Matriz4x4 lhs, Matriz4x4 rhs);
    public static bool operator ==(Matriz4x4 lhs, Matriz4x4 rhs);
    public static bool operator !=(Matriz4x4 lhs, Matriz4x4 rhs);
}

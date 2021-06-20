using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMath
{

    public struct Quater
    {
        public const float kEpsilon = 1E-06F;
        public float _x;
        public float _y;
        public float _z;
        public float _w;
        public Quater(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }
            
        //public float this[int index] { get NotImplementedException(); set; }
        public static Quater identity { get { return new Quater(0, 0, 0, 1); } }
        //public Vector3 eulerAngles { get { } set { } }
        //public Quater normalized { get { } }
        //Funciones
        public static float Angle(Quater a, Quater b)
        {
            throw new NotImplementedException();
        }
        public static Quater AngleAxis(float angle, Vector3 axis)
        {
            throw new NotImplementedException();
        }
        public static float Dot(Quater a, Quater b)
        {
            return (a._x * b._x) + (a._y * b._y) + (a._z * b._z) + (a._w * b._w);
        }
        public static Quater Euler(Vector3 euler)
        {
            float cy = Mathf.Cos(euler.x * 0.5f);
            float sy = Mathf.Sin(euler.x * 0.5f);
            float cp = Mathf.Cos(euler.y * 0.5f);
            float sp = Mathf.Sin(euler.y * 0.5f);
            float cr = Mathf.Cos(euler.z * 0.5f);
            float sr = Mathf.Sin(euler.z * 0.5f);

            Quater q;
            q._w = cr * cp * cy + sr * sp * sy;
            q._x = sr * cp * cy - cr * sp * sy;
            q._y = cr * sp * cy + sr * cp * sy;
            q._z = cr * cp * sy - sr * sp * cy;

            return q;
        }
        public static Quater Euler(float x, float y,float z)
        {
            Quater q;
            q._x = Mathf.Sin(x / 2) * Mathf.Cos(y / 2) * Mathf.Cos(z / 2) -        Mathf.Cos(x / 2) * Mathf.Sin(y / 2) * Mathf.Sin(z / 2);
            q._y = Mathf.Cos(x / 2) * Mathf.Sin(y / 2) * Mathf.Cos(z / 2) +        Mathf.Sin(x / 2) * Mathf.Cos(y / 2) * Mathf.Sin(z / 2);
            q._z = Mathf.Cos(x / 2) * Mathf.Cos(y / 2) * Mathf.Sin(z / 2) -        Mathf.Sin(x / 2) * Mathf.Sin(y / 2) * Mathf.Cos(z / 2);
            q._w = Mathf.Cos(x / 2) * Mathf.Cos(y / 2) * Mathf.Cos(z / 2) +        Mathf.Sin(x / 2) * Mathf.Sin(y / 2) * Mathf.Sin(z / 2);
            return q;
        }
        public static Quater FromToRotation(Vector3 fromDirection,Vector3 toDirection)
        {
            throw new NotImplementedException();
        }
        public static Quater Inverse(Quater rotation)
        {
            throw new NotImplementedException();
        }
        public static Quater Lerp(Quater a, Quater b, float t)
        {
            //Mathf.Clamp(t, 0, 1);
            //a = a + (b - a) * t;
            //return a;
            throw new NotImplementedException();

        }
        public static Quater LerpUnclamped(Quater a, Quater b, float t)
        {
            throw new NotImplementedException();
        }
        public static Quater LookRotation(Vector3 foward)
        {
           throw new NotImplementedException();
        }
        public static Quater LookRotation(Vector3 foward, Vector3 upwards)
        {
            throw new NotImplementedException();
        }
        public static Quater Normalize(Quater q)
        {
            throw new NotImplementedException();
        }
        public static Quater RotateTowards(Quater from, Quater to, float maxDegreesDelta)
        {
            throw new NotImplementedException();
        }
        public static Quater Sleep(Quater a, Quater b,float t)
        {
            throw new NotImplementedException();
        }
        public static Quater SleepUnclamped(Quater a, Quater b, float t)
        {
            throw new NotImplementedException();
        }
        public bool Equals(Quater other)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object other)
        {
            throw new NotImplementedException();
        }
        public void Normalize()
        {

        }
        public void Set(float newX, float newY, float newZ, float newW)
        {
            _x = newX;
            _y = newY;
            _z = newZ;
            _w = newW;
        }
        public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {

        }
        public void SetLookRotation(Vector3 view,  Vector3 up)
        {

        }
        public void SetLookRotation(Vector3 view)
        {

        }
        //public void ToAngleAxis(out float angle, out Vector3 axis)
        //{
        //
        //}
        
        public override string ToString()
        {
            
            return "X = " + _x.ToString() + "   Y = " + _y.ToString() + "   Z = " + _z.ToString() + "   W = " + _w.ToString();
        }
        //public static Vector3 operator *(Quater rotation, Vector3 point)
        //{
        //
        //}
        public static Quater operator *(Quater lhs, Quater rhs)
        {
            float w = (lhs._w * rhs._w) - (lhs._x * rhs._x) - (lhs._y * rhs._y) - (lhs._z * rhs._z);
            float x = (lhs._w * rhs._x) + (lhs._x * rhs._w) + (lhs._y * rhs._z) - (lhs._z * rhs._y);
            float y = (lhs._w * rhs._y) - (lhs._x * rhs._z) + (lhs._y * rhs._w) + (lhs._z * rhs._x);
            float z = (lhs._w * rhs._z) + (lhs._x * rhs._y) - (lhs._y * rhs._x) + (lhs._z * rhs._w);
            //float CX = Mathf.Cos(euler.x * 0.5f);
            //float SX = Mathf.Sin(euler.x * 0.5f);
            //
            //float CY = Mathf.Cos(euler.y * 0.5f);
            //float SY = Mathf.Sin(euler.y * 0.5f);
            //
            //float CZ = Mathf.Cos(euler.z * 0.5f);
            //float SZ = Mathf.Sin(euler.z * 0.5f);
            //
            //q._w = CZ * CY * CX + SZ * SY * SX;
            //q._x = SZ * CY * CX - CZ * SY * SX;
            //q._y = CZ * SY * CX + SZ * CY * SX;
            //q._z = CZ * CY * SX - SZ * SY * CX;
            //
            Quater q = new Quater(x, y, z, w);
            return q;
        }
        public static bool operator ==(Quater lhs, Quater rhs)
        {
            float diff_x = lhs._x - rhs._x;
            float diff_y = lhs._y - rhs._y;
            float diff_z = lhs._z - rhs._z;
            float diff_w = lhs._w - rhs._w;
            float sqrmag = diff_x * diff_w * diff_y * diff_z;
            return sqrmag < kEpsilon * kEpsilon;

        }
        public static bool operator !=(Quater lhs, Quater rhs)
        {
            return !(lhs == rhs);
        }
    }
}
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
            float dot = Dot(a, b);
            float magFrom = ((a._x * a._x) + (a._y * a._y) + (a._z * a._z) + (a._w * a._w));
            float magTo = ((b._x * b._x) + (b._y * b._y) + (b._z * b._z) + (b._w * b._w));
            float aux = Mathf.Sqrt(magFrom * magTo);
            float aux2 = dot / aux;
            float rad = (float)Mathf.Acos(aux2);
            float acos = Mathf.Rad2Deg * rad;
            return acos;
        }
        public static Quater AngleAxis(float angle, Vector3 axis)
        {
            Quater q =  new Quater(axis.x * Mathf.Sin(angle / 2) , axis.y * Mathf.Sin(angle / 2) ,
                axis.z * Mathf.Sin(angle / 2) , Mathf.Cos(angle / 2));
            return q;
            //float S = Mathf.Sin(angle);
            //float C = Mathf.Cos(angle);
            //float T = 1 - C;
            //
            //float magnitude = Mathf.Sqrt(axis.x * axis.x + /axis.y/ * axis.y + axis.z * axis.z);
            //Quater q;
            //axis.x = axis.x / magnitude;
            //axis.y = axis.y / magnitude;
            //axis.z = axis.z / magnitude;
            //
            //if(axis.x* axis.y*T * axis.z*S> 0.998)
            //{
            //
            //}
        }
        public static float Dot(Quater a, Quater b)
        {
            return (a._x * b._x) + (a._y * b._y) + (a._z * b._z) + (a._w * b._w);
        }
        public static Quater Euler(Vector3 euler)
        {
            float C1 = Mathf.Cos(euler.x);
            float S1 = Mathf.Sin(euler.x);
            float C2 = Mathf.Cos(euler.y);
            float S2 = Mathf.Sin(euler.y);
            float C3 = Mathf.Cos(euler.z);
            float S3 = Mathf.Sin(euler.z);
            Quater q;
            q._w = Mathf.Sqrt(1 + C1 * C2 + C1 * C3 - S1 * S2 * S3 + C2 * C3) / 2;
            float w4 = (4 * q._w);
            q._x = (S1 * C2 + S1 * C3 + C1 * S2 * S3) / w4;
            q._y = (-S1 * S3 + C1 * S2 * C3 + S2) / w4;
            q._z = (C2 * S3 + C1 * S3 + S1 * S2 * C3) / w4;

            //float cy = Mathf.Cos(euler.x * 0.5f);
            //float sy = Mathf.Sin(euler.x * 0.5f);
            //float cp = Mathf.Cos(euler.y * 0.5f);
            //float sp = Mathf.Sin(euler.y * 0.5f);
            //float cr = Mathf.Cos(euler.z * 0.5f);
            //float sr = Mathf.Sin(euler.z * 0.5f);
            //
            //Quater q;
            //q._w = cr * cp * cy + sr * sp * sy;
            //q._x = sr * cp * cy - cr * sp * sy;
            //q._y = cr * sp * cy + sr * cp * sy;
            //q._z = cr * cp * sy - sr * sp * cy;
            //
            return q;
        }
        public static Quater Euler(float x, float y, float z)
        {
            float C1 = Mathf.Cos(x);
            float S1 = Mathf.Sin(x);
            float C2 = Mathf.Cos(y);
            float S2 = Mathf.Sin(y);
            float C3 = Mathf.Cos(z);
            float S3 = Mathf.Sin(z);
            Quater q;
            q._w = Mathf.Sqrt(1 + C1 * C2 + C1 * C3 - S1 * S2 * S3 + C2 * C3) / 2;
            float w4 = (4 * q._w);
            q._x = (S1 * C2 + S1 * C3 + C1 * S2 * S3) / w4;  
            q._y = (-S1 * S3 + C1 * S2 * C3 + S2) / w4;
            q._z = (C2 * S3 + C1 * S3 + S1 * S2 * C3) / w4; 

            //q._x = Mathf.Sin(x / 2) * Mathf.Cos(y / 2) * Mathf.Cos(z / 2) - Mathf.Cos(x / 2) * Mathf.Sin(y / 2) * Mathf.Sin(z / 2);
            //q._y = Mathf.Cos(x / 2) * Mathf.Sin(y / 2) * Mathf.Cos(z / 2) + Mathf.Sin(x / 2) * Mathf.Cos(y / 2) * Mathf.Sin(z / 2);
            //q._z = Mathf.Cos(x / 2) * Mathf.Cos(y / 2) * Mathf.Sin(z / 2) - Mathf.Sin(x / 2) * Mathf.Sin(y / 2) * Mathf.Cos(z / 2);
            //q._w = Mathf.Cos(x / 2) * Mathf.Cos(y / 2) * Mathf.Cos(z / 2) + Mathf.Sin(x / 2) * Mathf.Sin(y / 2) * Mathf.Sin(z / 2);
            return q;
        }
        public static Quater FromToRotation(Vector3 fromDirection,Vector3 toDirection)
        {
            throw new NotImplementedException();
        }
        public static Quater Inverse(Quater rotation)
        {
            rotation._x *= -1;
            rotation._y *= -1;
            rotation._z *= -1;
            return rotation;
        }
        public static Quater Lerp(Quater a, Quater b, float t)
        {
            Mathf.Clamp(t, 0, 1);
            a._w = a._w + (b._w - a._w) * t;
            a._x = a._x + (b._x - a._x) * t;
            a._y = a._y + (b._y - a._y) * t;
            a._z = a._z + (b._z - a._z) * t;
            return a;

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
            float answ = (q._x * q._x) + (q._y * q._y) + (q._z * q._z) + (q._w *q._w);
            if (answ > 1)
            {
                q._x = q._x / answ;
                q._y = q._y / answ;
                q._z = q._z / answ;
            }
            return q;
        }
        public static Quater RotateTowards(Quater from, Quater to, float maxDegreesDelta)
        {
            throw new NotImplementedException();
        }
        public static Quater Slerp(Quater qa, Quater qb, float t)
        {
            // quaternion to return
            Quater qm;
            // Calculate angle between them.
            float cosHalfTheta = qa._w * qb._w + qa._x * qb._x + qa._y * qb._y + qa._z * qb._z;
            // if qa=qb or qa=-qb then theta = 0 and we can return qa
            if (Mathf.Abs(cosHalfTheta) >= 1.0)
            {
                qm._w = qa._w; qm._x = qa._x; qm._y = qa._y; qm._z = qa._z;
                return qm;
            }
            // Calculate temporary values.
            float halfTheta = Mathf.Acos(cosHalfTheta);
            float sinHalfTheta = Mathf.Sqrt(1.0f - cosHalfTheta * cosHalfTheta);
            // if theta = 180 degrees then result is not fully defined
            // we could rotate around any axis normal to qa or qb
            if (Mathf.Abs(sinHalfTheta) < 0.001)
            { // fabs is floating point absolute
                qm._w = (qa._w * 0.5f + qb._w * 0.5f);
                qm._x = (qa._x * 0.5f + qb._x * 0.5f);
                qm._y = (qa._y * 0.5f + qb._y * 0.5f);
                qm._z = (qa._z * 0.5f + qb._z * 0.5f);
                return qm;
            }
            float ratioA = Mathf.Sin((1 - t) * halfTheta) / sinHalfTheta;
            float ratioB = Mathf.Sin(t * halfTheta) / sinHalfTheta;
            //calculate Quaternion.
            qm._w = (qa._w * ratioA + qb._w * ratioB);
            qm._x = (qa._x * ratioA + qb._x * ratioB);
            qm._y = (qa._y * ratioA + qb._y * ratioB);
            qm._z = (qa._z * ratioA + qb._z * ratioB);
            return qm;
            /* Mathf.Clamp(t, 0, 1);
             Quater q;
             float cosHalfTheta = a._w * b._w + a._x * b._x + a._y * b._y + a._z * b._z;
             if(Mathf.Abs(cosHalfTheta)>1)
             {
                 q = a;
                 return q;
             }

             float halfTheta = Mathf.Acos(cosHalfTheta);
             float sinHalfTheta = Mathf.Sqrt(1 - cosHalfTheta * cosHalfTheta);
             if(Mathf.Abs(sinHalfTheta) < 0.001f)
             {
                 q._w = (a._w * 0.5f + b._w * 0.5f);
                 q._x = (a._x * 0.5f + b._x * 0.5f);
                 q._y = (a._y * 0.5f + b._y * 0.5f);
                 q._z = (a._z * 0.5f + b._z * 0.5f);
                 return q;
             }
             float ratioA = Mathf.Sin((1 - t) * halfTheta) / sinHalfTheta;
             float ratioB = Mathf.Sin(t * halfTheta) / sinHalfTheta;

             q._w = a._w * ratioA + b._w * ratioB;
             q._x = a._x * ratioA + b._x * ratioB;
             q._y = a._y * ratioA + b._y * ratioB;
             q._z = a._z * ratioA + b._z * ratioB;
             return q;*/
        }
        public static Quater SlerpUnclamped(Quater a, Quater b, float t)
        {
            Quater q;
            float cosHalfTheta = a._w * b._w + a._x * b._x + a._y * b._y + a._z * b._z;
            if (Mathf.Abs(cosHalfTheta) > 1)
            {
                q = a;
            }

            float halfTheta = Mathf.Acos(cosHalfTheta);
            float sinHalfTheta = Mathf.Sqrt(1 - cosHalfTheta * cosHalfTheta);
            if (Mathf.Abs(sinHalfTheta) < 0.001f)
            {
                q._w = (a._w * 0.5f + b._w * 0.5f);
                q._x = (a._x * 0.5f + b._x * 0.5f);
                q._y = (a._y * 0.5f + b._y * 0.5f);
                q._z = (a._z * 0.5f + b._z * 0.5f);
            }
            float ratioA = Mathf.Sin((1 - t) * halfTheta) / sinHalfTheta;
            float ratioB = Mathf.Sin(t * halfTheta) / sinHalfTheta;

            q._w = a._w * ratioA + b._w * ratioB;
            q._x = a._x * ratioA + b._x * ratioB;
            q._y = a._y * ratioA + b._y * ratioB;
            q._z = a._z * ratioA + b._z * ratioB;
            return q;
        }
        public bool Equals(Quater other)
        {
            return _x == other._x && _y == other._y && _z == other._z && _w == other._w;
        }
        public override bool Equals(object other)
        {
            if (!(other is Quater)) return false;
            return Equals((Quater)other);
        }
        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ (_y.GetHashCode() << 2) ^ (_z.GetHashCode() >> 2) ^ _w.GetHashCode();
        }
        public void Normalize()
        {
            float answ = (_x * _x) + (_y * _y) + (_z * _z) + (_w * _w);
            if (answ > 1)
            {
                _x = _x / answ;
                _y = _y / answ;
                _z = _z / answ;
            }
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
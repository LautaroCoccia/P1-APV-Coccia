using System;
using UnityEngine;
using UnityEngine.Internal;
using CustomMath;

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
        public Quater(Quaternion a)
        {
            _x = a.x;
            _y = a.y;
            _z = a.z;
            _w = a.w;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _x;
                    case 1:
                        return _y;
                    case 2:
                        return _z;
                    case 3:
                        return _w;
                    default:
                        throw new IndexOutOfRangeException("Invalid Index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _x = value;
                        break;
                    case 1:
                        _y = value;
                        break;
                    case 2:
                        _z = value;
                        break;
                    case 3:
                        _w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Index");
                }
            }
        }
        public static Quater identity { get { return new Quater(0, 0, 0, 1); } }
        public Vec3 eulerAngles
        {
            get
            {
                // Cos(ang°/2) + Sin(ang°/2)(i + j + k) <- Formula de quaterniones en base a angulos.
                // W es el Cos(ang°/2)
                // con estos calculos se calcula la forma de un quaternion base

                float sinX = 2 * (_w * _x + _y * _z);
                float cosX = 1 - 2 * (_x * _x + _y * _y);
                float eulerX = Mathf.Atan2(sinX, cosX) * Mathf.Rad2Deg;

                float sinY = 2 * (_w * _y - _z * _x);
                float eulerY = Mathf.PI / 2;

                if (Mathf.Abs(sinY) >= 1)
                {
                    if (sinY < 0)
                    {
                        eulerY = -eulerY;
                    }
                }
                else
                {
                    eulerY = Mathf.Asin(sinY) * Mathf.Rad2Deg;
                }

                float sinZ = 2 * (_w * _z + _x * _y);
                float cosZ = 1 - 2 * (_y * _y + _z * _z);
                float eulerZ = Mathf.Atan2(sinZ, cosZ) * Mathf.Rad2Deg;

                return new Vec3(eulerX, eulerY, eulerZ);
            }
            set
            {
                Quater quat = Euler(value);
                this._x = quat._x;
                this._y = quat._y;
                this._z = quat._z;
                this._w = quat._w;
            }
        }
        public Quater normalized {
            get
            {
                // Magnitud
                float mag = Mathf.Sqrt((_x * _x) + (_y * _y) + (_z * _z) + (_w * _w));
                // Normalize
                return new Quater(this._x / mag, this._y / mag, this._z / mag, this._w / mag);
            }
        }
        public void SetFromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {

            throw new NotImplementedException();
        }
        public void SetLookRotation(Vec3 view, [DefaultValue("Vec3.Up")] Vec3 up)
        {
            throw new NotImplementedException();

        }
        public void SetLookRotation(Vec3 view)
        {
            throw new NotImplementedException();

        }
        public void ToAngleAxis(out float angle, out Vec3 axis)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "X = " + _x.ToString() + "   Y = " + _y.ToString() + "   Z = " + _z.ToString() + "   W = " + _w.ToString();
        }
        //Funciones
        public static float Angle(Quater a, Quater b)
        {
            float dot = Dot(a, b);
            float abs = Mathf.Min(Mathf.Abs(dot));
            float acos = Mathf.Acos(abs);
            float rad = acos * 2 * Mathf.Rad2Deg;
            return rad;
            //acos(| a·b |) * 2 * (Pi / 180);
        }
        public static Quater AngleAxis(float angle, Vec3 axis)
        {
            if (axis.sqrMagnitude == 0)
                return identity;
            Quater q;
            q._x = axis.x * Mathf.Sin(angle / 2);
            q._y = axis.y * Mathf.Sin(angle / 2);
            q._z = axis.z * Mathf.Sin(angle / 2);
            q._w = Mathf.Cos(angle / 2);
            q = Inverse(q);
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
        public static Quater Euler(Vec3 euler)
        {
            Quater q;

            float C1 = Mathf.Cos(Mathf.Deg2Rad * euler.x / 2);
            float S1 = Mathf.Sin(Mathf.Deg2Rad * euler.x / 2);
            float C2 = Mathf.Cos(Mathf.Deg2Rad * euler.y / 2);
            float S2 = Mathf.Sin(Mathf.Deg2Rad * euler.y / 2);
            float C3 = Mathf.Cos(Mathf.Deg2Rad * euler.z / 2);
            float S3 = Mathf.Sin(Mathf.Deg2Rad * euler.z / 2);

            Quater X = new Quater(S1, 0, 0, C1);
            Quater Y = new Quater(0, S2, 0, C2);
            Quater Z = new Quater(0, 0, S3, C3);

            q = (X * Y * Z);
            return q;
        }
        public static Quater Euler(float x, float y, float z)
        {
            Quater q;
            float C1 = Mathf.Cos(Mathf.Deg2Rad * x / 2);
            float S1 = Mathf.Sin(Mathf.Deg2Rad * x / 2);
            float C2 = Mathf.Cos(Mathf.Deg2Rad * y / 2);
            float S2 = Mathf.Sin(Mathf.Deg2Rad * y / 2);
            float C3 = Mathf.Cos(Mathf.Deg2Rad * z / 2);
            float S3 = Mathf.Sin(Mathf.Deg2Rad * z / 2);

            Quater X = new Quater(S1, 0, 0, C1);
            Quater Y = new Quater(0, S2, 0, C2);
            Quater Z = new Quater(0, 0, S3, C3);

            q = (X * Y * Z);
            return q;
        }
        public static Quater FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            Vec3 cross = Vec3.Cross(fromDirection, toDirection);
            Quater q;
            q._x = cross.x;
            q._y = cross.y;
            q._z = cross.z;
            q._w = fromDirection.magnitude * toDirection.magnitude + Vec3.Dot(fromDirection, toDirection);
            q.Normalize();
            return q;
        }
        public static Quater Inverse(Quater rotation)
        {
            rotation._x = -1 * rotation._x;
            rotation._y = -1 * rotation._y;
            rotation._z = -1 * rotation._z;
            return rotation;
        }
        public static Quater Lerp(Quater a, Quater b, float t)
        {
            Mathf.Clamp(t, 0, 1);
            a._x = (b._x - a._x) * t;
            a._y = (b._y - a._y) * t;
            a._z = (b._z - a._z) * t;
            a._w = (b._w - a._w) * t;
            a.Normalize();
            return a;

        }
        public static Quater LerpUnclamped(Quater a, Quater b, float t)
        {
            a._x = (b._x - a._x) * t;
            a._y = (b._y - a._y) * t;
            a._z = (b._z - a._z) * t;
            a._w = (b._w - a._w) * t;
            a.Normalize();
            return a;
        }
        public static Quater LookRotation(Vec3 forward, Vec3 upwards)
        {
            Vec3 upForwardCross = Vec3.Cross(upwards, forward);
            Vec3 right = new Vec3();
            right.x = upForwardCross.x / (Mathf.Sqrt(upForwardCross.x * upForwardCross.x + upForwardCross.y * upForwardCross.y + upForwardCross.z * upForwardCross.z));
            right.y = upForwardCross.y / (Mathf.Sqrt(upForwardCross.x * upForwardCross.x + upForwardCross.y * upForwardCross.y + upForwardCross.z * upForwardCross.z));
            right.z = upForwardCross.z / (Mathf.Sqrt(upForwardCross.x * upForwardCross.x + upForwardCross.y * upForwardCross.y + upForwardCross.z * upForwardCross.z));

            // se reemplaza el up default por uno usando los otros vectores.
            upwards.x = forward.y * right.y - right.z * forward.z;
            upwards.y = forward.z * right.z - forward.x * right.x;
            upwards.z = forward.x * right.x - forward.y * right.y;

            // Suma total
            float totalSum = right.x + upwards.y + forward.z;
            Quater q = new Quater();

            if (totalSum > 0f)
            {
                float sqrtTotalSum = Mathf.Sqrt(totalSum + 1.0f);
                q._w = sqrtTotalSum * 0.5f;
                sqrtTotalSum = 0.5f / sqrtTotalSum;
                q._x = (upwards.z - forward.y) * sqrtTotalSum;
                q._y = (forward.x - right.z) * sqrtTotalSum;
                q._z = (right.y - upwards.x) * sqrtTotalSum;
                return q;
            }
            if ((right.x >= upwards.y) && (right.x >= forward.z))
            {
                float num7 = Mathf.Sqrt(((1.0f + right.x) - upwards.y) - forward.z);
                float num4 = 0.5f / num7;
                q._x = 0.5f * num7;
                q._y = (right.y + upwards.x) * num4;
                q._z = (right.z + forward.x) * num4;
                q._w = (upwards.z - forward.y) * num4;
                return q;
            }
            if (upwards.y > forward.z)
            {
                float num6 = (float)System.Math.Sqrt(((1f + upwards.y) - right.x) - forward.z);
                float num3 = 0.5f / num6;
                q._x = (upwards.x + right.y) * num3;
                q._y = 0.5f * num6;
                q._z = (forward.y + upwards.z) * num3;
                q._w = (forward.x - right.z) * num3;
                return q;
            }

            float num5 = Mathf.Sqrt(((1f + forward.x) - right.x) - upwards.y);
            float num2 = 0.5f / num5;
            q._x = (forward.x + right.z) * num2;
            q._y = (forward.y + upwards.z) * num2;
            q._z = 0.5f * num5;
            q._w = (right.y - upwards.x) * num2;

            return q;
        }
        public static Quater Normalize(Quater q)
        {
            float answ = Mathf.Sqrt((q._x * q._x) + (q._y * q._y) + (q._z * q._z) + (q._w * q._w));
            q._x = q._x / answ;
            q._y = q._y / answ;
            q._z = q._z / answ;
            q._w = q._w / answ;
            return q;
        }
        public static Quater RotateTowards(Quater from, Quater to, float maxDegreesDelta)
        {
            float angle = Angle(from, to);
            if(angle == 0)
            {
                return to;
            }
            float temp = Mathf.Min(maxDegreesDelta / angle);
            return SlerpUnclamped(from, to, temp);
        }
        public static Quater Slerp(Quater qa, Quater qb, float t)
        {
            Mathf.Clamp(t, 0, 1);
            Quater q = identity;
            float cosHalfTheta = qa._x * qb._x + qa._y * qb._y + qa._z * qb._z * qa._w * qb._w;
            if (cosHalfTheta < 0)
            {
                qb._w = -qb._w;
                qb._x = -qb._x;
                qb._y = -qb._y;
                qb._z = -qb._z;
                cosHalfTheta = -cosHalfTheta;
            }
            if (Mathf.Abs(cosHalfTheta) > 1)
            {
                q = qa;
                return q;
            }

            float halfTheta = Mathf.Acos(cosHalfTheta);
            float sinHalfTheta = Mathf.Sqrt(1 - cosHalfTheta * cosHalfTheta);
            if (Mathf.Abs(sinHalfTheta) <= 0)
            {
                q._w = (qa._w / 2 + qb._w / 2);
                q._x = (qa._x / 2 + qb._x / 2);
                q._y = (qa._y / 2 + qb._y / 2);
                q._z = (qa._z / 2 + qb._z / 2);
            }
            float ratioA = Mathf.Sin((1 - t) * halfTheta) / sinHalfTheta;
            float ratioB = Mathf.Sin(t * halfTheta) / sinHalfTheta;

            q._w = qa._w * ratioA + qb._w * ratioB;
            q._x = qa._x * ratioA + qb._x * ratioB;
            q._y = qa._y * ratioA + qb._y * ratioB;
            q._z = qa._z * ratioA + qb._z * ratioB;
            return q;
        }
        public static Quater SlerpUnclamped(Quater a, Quater b, float t)
        {
            Quater q = identity;
            float cosHalfTheta = a._x * b._x + a._y * b._y + a._z * b._z * a._w * b._w;

            if (cosHalfTheta < 0)
            {
                b._w = -b._w;
                b._x = -b._x;
                b._y = -b._y;
                b._z = -b._z;
                cosHalfTheta = -cosHalfTheta;
            }
            if (Mathf.Abs(cosHalfTheta) > 1)
            {
                q = a;
                return q;
            }

            float halfTheta = Mathf.Acos(cosHalfTheta);
            float sinHalfTheta = Mathf.Sqrt(1 - cosHalfTheta * cosHalfTheta);
            if (Mathf.Abs(sinHalfTheta) <= 0)
            {
                q._w = (a._w / 2 + b._w / 2);
                q._x = (a._x / 2 + b._x / 2);
                q._y = (a._y / 2 + b._y / 2);
                q._z = (a._z / 2 + b._z / 2);
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
            return _x.GetHashCode() ^ (_y.GetHashCode() << 2) ^ (_z.GetHashCode() >> 2) ^ _w.GetHashCode() >> 1;
        }
        public void Normalize()
        {
            float answ = Mathf.Sqrt((_x * _x) + (_y * _y) + (_z * _z) + (_w * _w));
            if (answ > 1)
            {
                _x = _x / answ;
                _y = _y / answ;
                _z = _z / answ;
                _w = _w / answ;
            }
        }
        public void Set(float newX, float newY, float newZ, float newW)
        {
            _x = newX;
            _y = newY;
            _z = newZ;
            _w = newW;
        }
        
        public static Vec3 operator *(Quater rotation, Vec3 point)
        {
            float n1 = rotation._x * 2;
            float n2 = rotation._y * 2;
            float n3 = rotation._z * 2;
            float n4 = rotation._x * n1;
            float n5 = rotation._y * n2;
            float n6 = rotation._z * n3;
            float n7 = rotation._x * n2;
            float n8 = rotation._x * n3;
            float n9 = rotation._y * n3;
            float n10 = rotation._w * n1;
            float n11 = rotation._w * n2;
            float n12 = rotation._w * n3;
            Vec3 vec;
            vec.x = (1 - (n5 + n6)) * point.x + (n7 - n12) * point.y + (n8 + n11) * point.z;
            vec.y = (n7 + n12) * point.x + (1 - (n4 + n6)) * point.y + (n9 - n10) * point.z;
            vec.z = (n8 - n11) * point.x + (n9 + n10) * point.y + (1 - (n4 + n5)) * point.z;
            return vec;
        }
        public static Quater operator *(Quater a, Quater b)
        {
            float w = (a._w * b._w) - (a._x * b._x) - (a._y * b._y) - (a._z * b._z);
            float x = (a._w * b._x) + (a._x * b._w) + (a._y * b._z) - (a._z * b._y);
            float y = (a._w * b._y) - (a._x * b._z) + (a._y * b._w) + (a._z * b._x);
            float z = (a._w * b._z) + (a._x * b._y) - (a._y * b._x) + (a._z * b._w);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomMath
{
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


        public float this[int index]
        {
            get
            {
                switch (index)
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
            //Poner un setter
        }
        public float this[int row, int column]
        {
            get
            {
                switch (row)
                {
                    case 0:
                        switch (column)
                        {
                            case 0:
                                return m00;
                            case 1:
                                return m10;
                            case 2:
                                return m20;
                            case 3:
                                return m30;
                            default:
                                throw new IndexOutOfRangeException("Invalid Index");
                        }
                    case 1:
                        switch (column)
                        {
                            case 0:
                                return m01;
                            case 1:
                                return m11;
                            case 2:
                                return m21;
                            case 3:
                                return m31;
                            default:
                                throw new IndexOutOfRangeException("Invalid Index");
                        }
                    case 2:
                        switch (column)
                        {
                            case 0:
                                return m02;
                            case 1:
                                return m12;
                            case 2:
                                return m22;
                            case 3:
                                return m32;
                            default:
                                throw new IndexOutOfRangeException("Invalid Index");
                        }
                    case 3:
                        switch (column)
                        {
                            case 0:
                                return m03;
                            case 1:
                                return m13;
                            case 2:
                                return m23;
                            case 3:
                                return m33;
                            default:
                                throw new IndexOutOfRangeException("Invalid Index");
                        }
                    default:
                        throw new IndexOutOfRangeException("Invalid Index");
                }
            }
            //agregar setter 
        }

        public Matriz4x4 transpose
        {
            get
            {
                return Transpose(this);
            }
        }

        public Matriz4x4 inverse { get { return Inverse(this); } }
        public Matriz4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            m00 = column0.x; m01 = column1.x; m02 = column2.x; m03 = column3.x;
            m10 = column0.y; m11 = column1.y; m12 = column2.y; m13 = column3.y;
            m20 = column0.z; m21 = column1.z; m22 = column2.z; m23 = column3.z;
            m30 = column0.w; m31 = column1.w; m32 = column2.w; m33 = column3.w;
        }
        public static Matriz4x4 zero
        {
            get
            {
                Vector4 vecX = new Vector4(0f, 0f, 0f, 0f);
                Vector4 vecY = new Vector4(0f, 0f, 0f, 0f);
                Vector4 vecZ = new Vector4(0f, 0f, 0f, 0f);
                Vector4 vecW = new Vector4(0f, 0f, 0f, 0f);
                return new Matriz4x4(vecX, vecY, vecZ, vecW);
            }
        }
        public static Matriz4x4 identity
        {
            get
            {
                Vector4 vecX = new Vector4(1f, 0f, 0f, 0f);
                Vector4 vecY = new Vector4(0f, 1f, 0f, 0f);
                Vector4 vecZ = new Vector4(0f, 0f, 1f, 0f);
                Vector4 vecW = new Vector4(0f, 0f, 0f, 1f);
                return new Matriz4x4(vecX, vecY, vecZ, vecW);
            }
        }
        public static Matriz4x4 Rotate(Quaternion q)
        {
            Matriz4x4 m = Matriz4x4.identity;
            m.m00 = 1 - 2 * (q.y * q.y) - 2 * (q.z * q.z);
            m.m01 = 2 * q.x * q.y - 2 * q.z * q.w;
            m.m02 = 2 * q.x * q.z + 2 * q.y * q.w;
            m.m10 = 2 * q.x * q.y + 2 * q.z * q.w;
            m.m11 = 1 - 2 * (q.x * q.x) - 2 * (q.z * q.z);
            m.m12 = 2 * q.y * q.z - 2 * q.x * q.w;
            m.m20 = 2 * q.x * q.z - 2 * q.y * q.w;
            m.m21 = 2 * q.y * q.z + 2 * q.x * q.w;
            m.m22 = 1 - 2 * (q.x * q.x) - 2 * (q.y * q.y);
            return m;
        }
        public static Matriz4x4 Scale(Vector3 vec3)
        {
            Matriz4x4 m = Matriz4x4.zero;
            m.m00 = vec3.x;
            m.m11 = vec3.y;
            m.m22 = vec3.z;
            m.m33 = 1;
            return m;
        }
        public static Matriz4x4 Translate(Vector3 vec3)
        {
            Matriz4x4 m = Matriz4x4.identity;
            m.m03 = vec3.x;
            m.m13 = vec3.y;
            m.m23 = vec3.z;
            m.m33 = 1;
            return m;
        }
        public static Matriz4x4 Transpose(Matriz4x4 m)
        {
            return new Matriz4x4(new Vector4(m.m00, m.m01, m.m02, m.m03), 
                                 new Vector4(m.m10, m.m11, m.m12, m.m13),
                                 new Vector4(m.m20, m.m21, m.m22, m.m23),
                                 new Vector4(m.m30, m.m31, m.m32, m.m33));
        }
        public static Matriz4x4 TRS(Vector3 pos, Quaternion q, Vector3 s)
        {
            Matriz4x4 translate = Matriz4x4.Translate(pos);
            Matriz4x4 rotate = Matriz4x4.Rotate(q);
            Matriz4x4 scale = Matriz4x4.Scale(s);
                 
            Matriz4x4 m = translate * rotate * scale;

            return m;
        }
       
        public static Matriz4x4 Inverse(Matriz4x4 m)
        {
            m.m01 = m.m01 *-1;
            m.m10 = m.m10 *-1;

            m.m02 = m.m02 *-1;
            m.m20 = m.m20 *-1;

            m.m12 = m.m12 *-1;
            m.m21 = m.m21 *-1;

            m.m12 = m.m12 *-1;
            m.m21 = m.m21 *-1;

            m.m03 = m.m03 *-1;
            m.m30 = m.m30 *-1;

            m.m13 = m.m13 *-1;
            m.m31 = m.m31 *-1;

            m.m23 = m.m23 *-1;
            m.m32 = m.m32 *-1;

            Vector4 column0 = new Vector4(m.m00, m.m01, m.m02, m.m03);
            Vector4 column1 = new Vector4(m.m10, m.m11, m.m12, m.m13);
            Vector4 column2 = new Vector4(m.m20, m.m21, m.m22, m.m23);
            Vector4 column3 = new Vector4(m.m30, m.m31, m.m32, m.m33);

            return new Matriz4x4(column0, column1, column2, column3);
        }
       
        public override bool Equals(object other)
        {
            if (!(other is Matriz4x4)) return false;
            return Equals((Matriz4x4)other);
        }
        public bool Equals(Matriz4x4 other)
        {
            return this == other;

        }
        public Vector4 GetRow(int index)
        {
            switch (index)
            {
                case 0:
                    return new Vector4(m00, m01, m02, m03);
                case 1:
                    return new Vector4(m10, m11, m12, m13);
                case 2:
                    return new Vector4(m20, m21, m22, m23);
                case 3:
                    return new Vector4(m30, m31, m32, m33);
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
        }
        public Vector4 GetColumn(int index)
        {                                  
            switch(index)                  
            {                              
                case 0:
                    return new Vector4(m00, m10, m20, m30);
                case 1:
                    return new Vector4(m01, m11, m21, m31);
                case 2:
                    return new Vector4(m02, m12, m22, m32);
                case 3:
                    return new Vector4(m03, m13, m23, m33);
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
        }
        public void SetColumn(int index, Vector4 column)
        {
            switch (index)
            {
                case 0:
                    m00 = column.x; m10 = column.y; m20 = column.z; m30 = column.w;
                    break;
                case 1:
                    m01 = column.x; m11 = column.y; m21 = column.z; m31 = column.w;
                    break;
                case 2:
                    m02 = column.x; m12 = column.y; m22 = column.z; m32 = column.w;
                    break;
                case 3:
                    m03 = column.x; m13 = column.y; m23 = column.z; m33 = column.w;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
        }
        public void SetRow(int index, Vector4 row)
        {
            switch (index)
            {
                case 0:
                    m00 = row.x; m01 = row.y; m02 = row.z; m03 = row.w;
                    break;
                case 1:
                    m10 = row.x; m11 = row.y; m12 = row.z; m13 = row.w;
                    break;
                case 2:
                    m20 = row.x; m21 = row.y; m22 = row.z; m23 = row.w;
                    break;
                case 3:
                    m30 = row.x; m31 = row.y; m32 = row.z; m33 = row.w;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
        }
        public void SetTRS(Vector3 pos, Quaternion q, Vector3 s)
        {
            this = TRS(pos, q, s);
        }
        public override string ToString()
        {
            return (" " + m00 + "  " + m01 + "  " + m02 + "  " + m03 +
                  "\n " + m10 + "  " + m11 + "  " + m12 + "  " + m13 +
                  "\n " + m20 + "  " + m21 + "  " + m22 + "  " + m23 +
                  "\n " + m30 + "  " + m31 + "  " + m32 + "  " + m33);
        }
        public static Vector4 operator *(Matriz4x4 a, Vector4 vector)
        {
            Vector4 vec4 = Vector4.zero;
            vec4.x = (a.m00 * vector.x) + (a.m01 * vector.x) + (a.m02 * vector.x) + (a.m03 * vector.x);
            vec4.y = (a.m10 * vector.y) + (a.m11 * vector.y) + (a.m12 * vector.y) + (a.m13 * vector.y);
            vec4.z = (a.m20 * vector.z) + (a.m21 * vector.z) + (a.m22 * vector.z) + (a.m23 * vector.z);
            vec4.w = (a.m30 * vector.w) + (a.m31 * vector.w) + (a.m32 * vector.w) + (a.m33 * vector.w);
            return vec4;
        }
        public static Matriz4x4 operator *(Matriz4x4 a, Matriz4x4 b)
        {
            Matriz4x4 m = Matriz4x4.zero;

            m.m00 = (a.m00 * b.m00) + (a.m01 * b.m10) + (a.m02 * b.m20) + (a.m03 * b.m30);
            m.m01 = (a.m00 * b.m01) + (a.m01 * b.m11) + (a.m02 * b.m21) + (a.m03 * b.m31);
            m.m02 = (a.m00 * b.m02) + (a.m01 * b.m12) + (a.m02 * b.m22) + (a.m03 * b.m32);
            m.m03 = (a.m00 * b.m03) + (a.m01 * b.m13) + (a.m02 * b.m23) + (a.m03 * b.m33);
            
            m.m10 = (a.m10 * b.m00) + (a.m11 * b.m10) + (a.m12 * b.m20) + (a.m13 * b.m30);
            m.m11 = (a.m10 * b.m01) + (a.m11 * b.m11) + (a.m12 * b.m21) + (a.m13 * b.m31);
            m.m12 = (a.m10 * b.m02) + (a.m11 * b.m12) + (a.m12 * b.m22) + (a.m13 * b.m32);
            m.m13 = (a.m10 * b.m03) + (a.m11 * b.m13) + (a.m12 * b.m23) + (a.m13 * b.m33);
            
            m.m20 = (a.m20 * b.m00) + (a.m21 * b.m10) + (a.m22 * b.m20) + (a.m23 * b.m30);
            m.m21 = (a.m20 * b.m01) + (a.m21 * b.m11) + (a.m22 * b.m21) + (a.m23 * b.m31);
            m.m22 = (a.m20 * b.m02) + (a.m21 * b.m12) + (a.m22 * b.m22) + (a.m23 * b.m32);
            m.m23 = (a.m20 * b.m03) + (a.m21 * b.m13) + (a.m22 * b.m23) + (a.m23 * b.m33);
            
            m.m30 = (a.m30 * b.m00) + (a.m31 * b.m10) + (a.m32 * b.m20) + (a.m33 * b.m30);
            m.m31 = (a.m30 * b.m01) + (a.m31 * b.m11) + (a.m32 * b.m21) + (a.m33 * b.m31);
            m.m32 = (a.m30 * b.m02) + (a.m31 * b.m12) + (a.m32 * b.m22) + (a.m33 * b.m32);
            m.m33 = (a.m30 * b.m03) + (a.m31 * b.m13) + (a.m32 * b.m23) + (a.m33 * b.m33);
            return m;
        }
        public static bool operator ==(Matriz4x4 a, Matriz4x4 b)
        {
            return (a == b);
        }
        public static bool operator !=(Matriz4x4 a, Matriz4x4 b)
        {
            return (a != b);
        }
    }

}

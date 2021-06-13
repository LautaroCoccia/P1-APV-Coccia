using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQuaternion : MonoBehaviour
{
    public struct Quater
    {
        public const float kEpsilon = 1E-06F;
        public float _x;
        public float _y;
        public float _z;
        public Quater(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        public float this[int index] { get; set; }
        public static Quater identity { get { return new Quater(0, 0, 0, 1); } }
        public Vector3 eulerAngles { get { } set { } }
        public Quater normalized { get { } }

    }
}

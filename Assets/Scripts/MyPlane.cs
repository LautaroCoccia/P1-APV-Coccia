using UnityEngine;

namespace CustomMath
{
    [SerializeField]
    public struct MyPlane
    {
        public Vec3 normal;
        public float distance;
        public MyPlane(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal.normalized;
            distance = Vec3.Dot(inNormal, inPoint);
        }
        public MyPlane(Vec3 inNormal, float d)
        {
            normal = inNormal.normalized;
            distance = d;
        }
        public MyPlane(Vec3 a, Vec3 b, Vec3 c)
        {
            normal = Vec3.Cross(b - a, c - a).normalized;
            distance = Vec3.Dot(normal, a);
        }
        public void Set3Points(Vec3 a, Vec3 b, Vec3 c)
        {
            Vec3 vec1 = b - a;
            Vec3 vec2 = c - a;
            normal = Vec3.Cross(vec1, vec2).normalized;
            distance = Vec3.Dot(normal, a);
        }

        public MyPlane flipped
        {
            get
            {
                return new MyPlane(-normal, -normal * distance);
            }
        }
        public void Translate( Vec3 translation) 
        {
            Vec3 res = ((normal * distance) + translation);
            distance = Vec3.Dot(normal, res);
        }
        public Vec3 ClosestPointOnPlane(Vec3 point)
        {
            Vec3 aux = (point -normal) * GetDistanceToPoint(point);
            return aux;
        }
        public void Flip()
        {
            normal = normal * -1;
            distance = distance * -1;
        }
        public float GetDistanceToPoint(Vec3 point)
        {
            float aux = -Vec3.Dot(normal, point)+ distance;
            return aux;
        }
        public bool GetSide(Vec3 point)
        {
            if (GetDistanceToPoint(point) > 0.0f) 
                return true;
            else
                return false;
        }
        public bool SameSide(Vec3 inPt0, Vec3 inPt1)
        {
            if (GetSide(inPt0) && GetSide(inPt1))
                return true;
            else
                return false;
        }
        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal.normalized;
            distance = Vec3.Dot(inNormal, inPoint);
        }

    }

}

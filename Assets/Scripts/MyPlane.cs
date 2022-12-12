using UnityEngine;

namespace CustomMath
{
    [SerializeField]
    public struct MyPlane
    {
        Vec3 normal;
        float distance;
        public float Distance()
        {
            return distance;
        }
        public Vec3 Flipped()
        {
            return -normal;
        }
        public Vec3 Normal()
        {
            return normal;
        }

        public override string ToString()
        {
            return "Normal: " + normal.ToString() + ", Distance: " + distance;
        }

        public MyPlane(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal.normalized;
            distance = -Vec3.Dot(normal, inPoint);
        }
        public MyPlane(Vec3 inNormal, float d)
        {
            normal = inNormal.normalized;
            distance = d;
        }
        public MyPlane(Vec3 a, Vec3 b, Vec3 c)
        {
            normal = Vec3.Cross(b - a, c - a);
            distance = -Vec3.Dot(normal, a);
        }
        public void Set3Points(Vec3 a, Vec3 b, Vec3 c)
        {
            normal = Vec3.Cross(b - a, c - a);
            distance = -Vec3.Dot(normal, a);
        }

        
        public Vec3 ClosestPointOnPlane(Vec3 point)
        {
            Vec3 aux = (point - normal) / GetDistanceToPoint(point);
            return aux;
        }
        public void Flip()
        {
            normal = normal * -1;
            distance = distance * -1;
        }
        public float GetDistanceToPoint(Vec3 point)
        {
            float aux = Vec3.Dot(point, normal) + distance ;
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
            distance = -Vec3.Dot(inNormal, inPoint);
        }
    }
}

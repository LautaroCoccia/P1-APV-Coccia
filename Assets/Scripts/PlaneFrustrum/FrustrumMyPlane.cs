using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class FrustrumMyPlane : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] GameObject cube0;
    [SerializeField] GameObject cube1; 
    [SerializeField] GameObject cube2;
    [SerializeField] GameObject cube3;
    [SerializeField] GameObject cube4;
    [SerializeField] GameObject cube5;
    [SerializeField] GameObject cube6;

    [SerializeField] public MyPlane near;
    [SerializeField] public MyPlane far;
    [SerializeField] public MyPlane left;
    [SerializeField] public MyPlane right;
    [SerializeField] public MyPlane top;
    [SerializeField] public MyPlane down;

    GameObject[] cubes;
    Vec3 pivPos;
    Vec3 pivRot;
    Vec3[] points;

    Vec3 punto1 = new Vec3(5, 0, 0.3f);
    Vec3 punto2 = new Vec3(5, 10, 0.3f);
    Vec3 punto3 = new Vec3(15, 15, -29.7f);
    Vec3 punto4 = new Vec3(-5, 0, 0.3f);
    Vec3 punto5 = new Vec3(-5, 10, 0.3f);
    Vec3 punto6 = new Vec3(-15, 15, -29.7f);
    Vec3 punto7 = new Vec3(-15, -5, -29.7f);
    Vec3 punto8 = new Vec3(15, -5, -29.7f);

    // Start is called before the first frame update
    void Start()
    {
        cubes = new GameObject[7];
        cubes[0] = cube0;
        cubes[1] = cube1;
        cubes[2] = cube2;
        cubes[3] = cube3;
        cubes[4] = cube4;
        cubes[5] = cube5;
        cubes[6] = cube6;

        points = new Vec3[8];
        points[0] = punto1;
        points[1] = punto2;
        points[2] = punto3;
        points[3] = punto4;
        points[4] = punto5;
        points[5] = punto6;
        points[6] = punto7;
        points[7] = punto8;

        pivPos = new Vec3(pivot.position.x, pivot.position.y, pivot.position.z);
        pivRot = new Vec3(pivot.rotation.x, pivot.rotation.y, pivot.rotation.z);
        near = new MyPlane(punto1, punto2, punto4);
        far = new MyPlane(punto3, punto6, punto8);
        left = new MyPlane(punto1, punto2, punto8);
        right = new MyPlane(punto6, punto5, punto4);
        top = new MyPlane(punto3, punto2, punto6);
        down = new MyPlane(punto1, punto4, punto7);

        near.Flip();
        down.Flip();
    }
    private void Update()
    {
        UpdatePlanesPos();

        Debug.DrawLine(points[0], points[1], Color.blue);
        Debug.DrawLine(points[1], points[2], Color.blue);
        Debug.DrawLine(points[2], points[3], Color.blue);

        Debug.DrawLine(points[0], points[3], Color.green);
        Debug.DrawLine(points[0], points[2], Color.green);
        Debug.DrawLine(points[4], points[5], Color.blue);

        for (int i = 0; i < cubes.Length; i++)
        {
            if (near.GetSide(new Vec3(cubes[i].transform.position)) && far.GetSide(new Vec3(cubes[i].transform.position)) &&
            left.GetSide(new Vec3(cubes[i].transform.position)) && right.GetSide(new Vec3(cubes[i].transform.position)) &&
            top.GetSide(new Vec3(cubes[i].transform.position)) && down.GetSide(new Vec3(cubes[i].transform.position)))
            {
                cubes[i].GetComponent<MeshRenderer>().enabled = true;
                Debug.Log(cubes[i].name +" esta dentro");
            }
            else
            {
                cubes[i].GetComponent<MeshRenderer>().enabled = false;
                Debug.Log(cubes[i].name + " esta fuera ");
            }
        }
    }
    // FALTA REFACTORIZAR MAS!!!!!!!!!!
    private void UpdatePlanesPos()
    {
        #region MOVEMENT
        if (pivPos != pivot.transform.position)
        {
            if (pivot.transform.position.x > pivPos.x)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].x += (pivot.transform.position.x - pivPos.x);
                }
                pivPos.x = pivot.transform.position.x;
            }
            else if (pivot.transform.position.x < pivPos.x)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].x -= (pivPos.x - pivot.transform.position.x );
                }
                pivPos.x = pivot.transform.position.x;
            }
            if (pivot.transform.position.y > pivPos.y)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].y += (pivot.transform.position.y - pivPos.y);
                }
                pivPos.y = pivot.transform.position.y;
            }
            else if (pivot.transform.position.y < pivPos.y)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].y -= (pivPos.y - pivot.transform.position.y);
                }
                pivPos.y = pivot.transform.position.y;
            }
            if (pivot.transform.position.z > pivPos.z)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].z += (pivot.transform.position.z - pivPos.z);
                }
                pivPos.z = pivot.transform.position.z;
            }
            else if (pivot.transform.position.z < pivPos.z)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].z -= (pivPos.z - pivot.transform.position.z);
                }
                pivPos.z = pivot.transform.position.z;
            }
            //if( pivRot.y>pivot.transform.rotation.y)
            //{
            //    for (int i = 0; i < points.Length; i++)
            //    {
            //        points[i].x += (pivot.transform.position.x - pivPos.x*pivRot.x);
            //        points[i].z += (pivot.transform.position.z - pivPos.z*pivRot.z);
            //    }
            //    pivRot.y = pivot.transform.rotation.y;
            //}
        }
        #endregion

        near = new MyPlane(points[0], points[1], points[3]);
        far = new MyPlane(points[2], points[5], points[7]);
        left = new MyPlane(points[0], points[1], points[7]);
        right = new MyPlane(points[5], points[4], points[3]);
        top = new MyPlane(points[2], points[1], points[5]);
        down = new MyPlane(points[0], points[3], points[6]);
        
        near.Flip();
        down.Flip();
    }
}



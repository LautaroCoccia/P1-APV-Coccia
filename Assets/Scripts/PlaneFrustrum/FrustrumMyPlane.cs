using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class FrustrumMyPlane : MonoBehaviour
{
    public List<GameObject> cubeTests;
    [SerializeField] bool rotate = false;

    public Transform pivot;

    public List<Transform> frusTransf;
    
    Vec3 pivPos;


    MyPlane _planeLeft;
    MyPlane _planeRight;
    MyPlane _planeNear;
    MyPlane _planeFar;
    MyPlane _planeTop;
    MyPlane _planeDown;

    Vec3 leftPlaneNormal;
    Vec3 rightPlaneNormal;
    Vec3 nearPlaneNormal;
    Vec3 farPlaneNormal;
    Vec3 topPlaneNormal;
    Vec3 downPlaneNormal;

    Vec3 leftPlanePosition;
    Vec3 rightPlanePosition;
    Vec3 nearPlanePosition;
    Vec3 farPlanePosition;
    Vec3 topPlanePosition;
    Vec3 downPlanePosition;

    // -----------------------------
    const float SPEED_ROTATION = 20;
    Vec3 ROTATION_AXIS = new Vec3(0, 5, 0);
    Vec3 ROTATE_POINT = Vec3.Zero;
    // -----------------------------

    void Start()
    {
        UpdatePositionObjects();

        _planeLeft = new MyPlane(leftPlaneNormal, leftPlanePosition);
        _planeRight = new MyPlane(rightPlaneNormal, rightPlanePosition);
        _planeNear = new MyPlane(nearPlaneNormal, nearPlanePosition);
        _planeFar = new MyPlane(farPlaneNormal, farPlanePosition);
        _planeTop = new MyPlane(topPlaneNormal, topPlanePosition);
        _planeDown = new MyPlane(downPlaneNormal, downPlanePosition);

        pivPos = new Vec3(pivot.position);
    }

    void Update()
    {
        if(rotate)
        {
            ROTATE_POINT = new Vec3(pivot.position.x, pivot.position.y, pivot.position.z);
            RotateObjects();
        }
        UpdatePositionObjects();
        MovePlanes();

        for (int i = 0; i < cubeTests.Count; i++)
        {
            Vec3 aux = new Vec3(cubeTests[i].transform.position);
            if (DetectObject(aux))
            {
                cubeTests[i].SetActive(true);
            }
            else
            {
                cubeTests[i].SetActive(false);
            }
        }
    }

    void UpdatePositionObjects()
    {
        

        leftPlaneNormal = new Vec3(frusTransf[0].right);
        rightPlaneNormal = new Vec3(frusTransf[1].right);
        nearPlaneNormal = new Vec3(frusTransf[2].right);
        farPlaneNormal = new Vec3(frusTransf[3].right);
        topPlaneNormal = new Vec3(frusTransf[4].right);
        downPlaneNormal = new Vec3(frusTransf[5].right);

        leftPlanePosition = new Vec3(frusTransf[0].localPosition);
        rightPlanePosition = new Vec3(frusTransf[1].localPosition);
        nearPlanePosition = new Vec3(frusTransf[2].localPosition);
        farPlanePosition = new Vec3(frusTransf[3].localPosition);
        topPlanePosition = new Vec3(frusTransf[4].localPosition);
        downPlanePosition = new Vec3(frusTransf[5].localPosition);
    }

    void MovePlanes()
    {
        _planeLeft.SetNormalAndPosition(leftPlaneNormal, leftPlanePosition);
        _planeRight.SetNormalAndPosition(rightPlaneNormal, rightPlanePosition);
        _planeNear.SetNormalAndPosition(nearPlaneNormal, nearPlanePosition);
        _planeFar.SetNormalAndPosition(farPlaneNormal, farPlanePosition);
        _planeTop.SetNormalAndPosition(topPlaneNormal, topPlanePosition);
        _planeDown.SetNormalAndPosition(downPlaneNormal, downPlanePosition);
        #region MOVEMENT
        if (pivPos != pivot.position)
        {
            if (pivot.position.x > pivPos.x)
            {
                for (int i = 0; i < frusTransf.Count; i++)
                {
                    float aux = frusTransf[i].position.x;
                    aux += pivot.position.x - pivPos.x;
                    frusTransf[i].position = new Vector3(aux, frusTransf[i].position.y, frusTransf[i].position.z);
                }
                    pivPos = new Vec3(pivot.transform.position.x, pivPos.y, pivPos.z);
            }
            else if (pivot.position.x < pivPos.x)
            {
                for (int i = 0; i < frusTransf.Count; i++)
                {
                    float aux = frusTransf[i].position.x;
                    aux -= pivPos.x - pivot.position.x;
                    frusTransf[i].position = new Vector3(aux, frusTransf[i].position.y, frusTransf[i].position.z);
            
                }
                pivPos = new Vec3(pivot.transform.position.x, pivPos.y, pivPos.z);
            }
            if (pivot.position.y > pivPos.y)
            {
                for (int i = 0; i < frusTransf.Count; i++)
                {
                    float aux = frusTransf[i].position.y;
                    aux += pivot.position.y - pivPos.y;
                    frusTransf[i].position = new Vector3( frusTransf[i].position.x, aux, frusTransf[i].position.z);
                }
                pivPos = new Vec3(pivPos.x, pivot.transform.position.y, pivPos.z);
            }
            else if (pivot.position.y < pivPos.y)
            {
                for (int i = 0; i < frusTransf.Count; i++)
                {
                    float aux = frusTransf[i].position.y;
                    aux -= pivPos.y - pivot.position.y;
                    frusTransf[i].position = new Vector3( frusTransf[i].position.y, aux, frusTransf[i].position.z);

                }
                pivPos = new Vec3(pivPos.x, pivot.transform.position.y, pivPos.z);
            }
            if (pivot.position.z > pivPos.z)
            {
                for (int i = 0; i < frusTransf.Count; i++)
                {
                    float aux = frusTransf[i].position.z;
                    aux += pivot.position.z - pivPos.z;
                    frusTransf[i].position = new Vector3(frusTransf[i].position.x, frusTransf[i].position.y, aux);
                }
                pivPos = new Vec3(pivPos.x, pivPos.y, pivot.transform.position.z);
            }
            else if (pivot.position.z < pivPos.z)
            {
                for (int i = 0; i < frusTransf.Count; i++)
                {
                    float aux = frusTransf[i].position.z;
                    aux -= pivPos.z - pivot.position.z;
                    frusTransf[i].position = new Vector3(frusTransf[i].position.x, frusTransf[i].position.y, aux);

                }
                pivPos = new Vec3(pivPos.x, pivPos.y, pivot.transform.position.z);
            }
            
        }
        #endregion
    }
    void RotateObjects()
    {
        for (int i = 0; i < frusTransf.Count; i++)
        {
            frusTransf[i].RotateAround(ROTATE_POINT, ROTATION_AXIS, SPEED_ROTATION * Time.deltaTime);
        }
       
    }

    bool DetectObject(Vec3 cubePos)
    {
        
        if (_planeNear.GetSide(cubePos) && _planeRight.GetSide(cubePos) && _planeLeft.GetSide(cubePos) &&
         _planeDown.GetSide(cubePos) && _planeTop.GetSide(cubePos) && _planeFar.GetSide(cubePos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
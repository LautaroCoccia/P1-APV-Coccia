using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class FrustrumMyPlane : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] GameObject sphere;

    [SerializeField] public MyPlane near;
    [SerializeField] public MyPlane far;
    [SerializeField] public MyPlane left;
    [SerializeField] public MyPlane right;
    [SerializeField] public MyPlane top;
    [SerializeField] public MyPlane down;

    Vec3 piv;

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
        piv = new Vec3(pivot.position.x, pivot.position.y, pivot.position.z);

        near = new MyPlane(punto1, punto2, punto4);
        far = new MyPlane(punto3, punto6, punto8);
        left = new MyPlane(punto1, punto2, punto8);
        right = new MyPlane(punto6, punto5, punto4);
        top = new MyPlane(punto3, punto2, punto6);
        down = new MyPlane(punto1, punto4, punto7);

        far.Flip();
        down.Flip();
        left.Flip();
        right.Flip();
        top.Flip();
        down.Flip();
    }
    private void Update()
    {
        

        Debug.DrawLine(punto1, punto2, Color.blue);
        Debug.DrawLine(punto2, punto3, Color.blue);
        Debug.DrawLine(punto3, punto4, Color.blue);

        Debug.DrawLine(punto1, punto4, Color.green);
        Debug.DrawLine(punto1, punto3, Color.green);
        Debug.DrawLine(punto5, punto6, Color.blue);

        if (near.GetSide(new Vec3(sphere.transform.position)) && far.GetSide(new Vec3(sphere.transform.position)) &&
            left.GetSide(new Vec3(sphere.transform.position)) && right.GetSide(new Vec3(sphere.transform.position)) &&
            top.GetSide(new Vec3(sphere.transform.position)) && down.GetSide(new Vec3(sphere.transform.position)) )
        {
            sphere.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("esta dentro");
        }
        else
        {
            sphere.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("esta fuera ");
        }

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrustrumPlane : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] GameObject sphere;


    [SerializeField] public Plane near;
    [SerializeField] public Plane far;
    [SerializeField] public Plane left;
    [SerializeField] public Plane right;
    [SerializeField] public Plane top;
    [SerializeField] public Plane down;

    //Vector3 puntoX = new Vector3(5, 0, 0);
    //Vector3 puntoY = new Vector3(0, 5, 0);
    //Vector3 puntoZ = new Vector3(0, 0, 5);

    Vector3 punto1 = new Vector3(5, 0, 0.3f);
    Vector3 punto2 = new Vector3(5, 10, 0.3f);
    Vector3 punto3 = new Vector3(15, 15, -29.7f);
    Vector3 punto4 = new Vector3(-5, 0, 0.3f);
    Vector3 punto5 = new Vector3(-5, 10, 0.3f);
    Vector3 punto6 = new Vector3(-15, 15, -29.7f);
    Vector3 punto7 = new Vector3(-15, -5, -29.7f);
    Vector3 punto8 = new Vector3(15, -5, -29.7f);
    Vector3 piv;
    // Start is called before the first frame update
    void Start()
    {
        piv= new Vector3(pivot.position.x, pivot.position.y, pivot.position.z);
        near = new Plane(punto1,punto2,punto4);
        far = new Plane(punto3, punto6, punto7);
        left = new Plane(punto1, punto2, punto8);
        right = new Plane(punto6, punto5, punto4);
        top = new Plane(punto3, punto2, punto6);
        down = new Plane(punto1, punto4, punto7);

        near.Flip();
        down.Flip();
    }
    private void Update()
    {
        if(piv != pivot.transform.position)
        {
            piv = pivot.transform.position;
            near.Translate(piv);
            far.Translate(piv);
            left.Translate(piv);
            right.Translate(piv);
            top.Translate(piv);
            down.Translate(piv);
        }
        

        //Debug.DrawLine(puntoX - puntoY + puntoZ, -puntoX - puntoY + puntoZ, Color.red);
        //Debug.DrawLine(puntoX + puntoY + puntoZ, -puntoX + puntoY + puntoZ, Color.red);
        //
        //Debug.DrawLine(puntoX - puntoY + puntoZ, puntoX + puntoY + puntoZ, Color.red);
        //Debug.DrawLine(-puntoX - puntoY + puntoZ, -puntoX + puntoY + puntoZ, Color.red);
        //
        //Debug.DrawLine(puntoX + puntoY - puntoZ, -puntoX + puntoY - puntoZ, Color.red);
        //Debug.DrawLine(puntoX - puntoY - puntoZ, -puntoX - puntoY - puntoZ, Color.red);
        //
        //Debug.DrawLine(puntoX + puntoY - puntoZ, puntoX - puntoY - puntoZ, Color.red);
        //Debug.DrawLine(-puntoX + puntoY - puntoZ, -puntoX - puntoY - puntoZ, Color.red);
        //
        //Debug.DrawLine(puntoX - puntoY + puntoZ, puntoX - puntoY - puntoZ, Color.red);
        //Debug.DrawLine(puntoX + puntoY + puntoZ, puntoX + puntoY - puntoZ, Color.red);
        //
        //Debug.DrawLine(-puntoX - puntoY + puntoZ, -puntoX - puntoY - puntoZ, Color.red);
        //Debug.DrawLine(-puntoX + puntoY + puntoZ, -puntoX + puntoY - puntoZ, Color.red);

        Debug.DrawLine(punto1, punto2, Color.blue);
        Debug.DrawLine(punto2, punto3, Color.blue);
        Debug.DrawLine(punto3, punto4, Color.blue);

        Debug.DrawLine(punto1, punto4, Color.green);
        Debug.DrawLine(punto1, punto3, Color.green);
        Debug.DrawLine(punto5, punto6, Color.blue);

        if (near.GetSide(sphere.transform.position) && far.GetSide(sphere.transform.position) &&
            left.GetSide(sphere.transform.position) && right.GetSide(sphere.transform.position) &&
            top.GetSide(sphere.transform.position) && down.GetSide(sphere.transform.position))
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

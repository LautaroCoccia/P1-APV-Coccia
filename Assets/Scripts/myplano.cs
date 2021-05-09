using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class myplano : MonoBehaviour
{
    public GameObject sphere;
    [SerializeField] public Plane planos1;
    [SerializeField] public Plane planos2;
    [SerializeField] public Plane planos3;
    [SerializeField] public Plane planos4;
    [SerializeField] public Plane planos5;
    [SerializeField] public Plane planos6;

    [SerializeField] public Plane Xplanos1;
    [SerializeField] public Plane Xplanos2;
    [SerializeField] public Plane Xplanos3;
    [SerializeField] public Plane Xplanos4;
    [SerializeField] public Plane Xplanos5;
    [SerializeField] public Plane Xplanos6;

    Vector3 puntoX = new Vector3(5,0,0);
    Vector3 puntoY = new Vector3(0,5,0);
    Vector3 puntoZ = new Vector3(0, 0, 5);
    
    Vector3 punto1 = new Vector3(-5, 5 -5);
    Vector3 punto2 = new Vector3(5, 5, -5);
    Vector3 punto3 = new Vector3(5, -5, 5);
    Vector3 punto4 = new Vector3(-5, 5, 5);
    Vector3 punto5 = new Vector3(5, 5, 5);
    Vector3 punto6 = new Vector3(-5, 5, -5);
    // Start is called before the first frame update
    void Start()
    {

        planos1 = new Plane(punto1, punto2);
        planos2 = new Plane(punto2, punto3);
        planos3 = new Plane(punto3, punto4);
        planos4 = new Plane(punto4, punto1);
        planos4.Flip();
        planos5 = new Plane(punto3, punto1);
        //planos5.Flip();
        planos6 = new Plane(punto5, punto6);

    }
    private void Update()
    {
        //planos5.Flip();
        punto1 = new Vector3(-5, -5, -5);
        Debug.DrawLine(puntoX- puntoY +puntoZ, -puntoX- puntoY +puntoZ, Color.red);
        Debug.DrawLine(puntoX+puntoY+puntoZ, -puntoX+puntoY+puntoZ, Color.red);

        Debug.DrawLine(puntoX - puntoY + puntoZ, puntoX + puntoY + puntoZ, Color.red);
        Debug.DrawLine(-puntoX - puntoY + puntoZ, -puntoX + puntoY + puntoZ, Color.red);

        Debug.DrawLine(puntoX+puntoY-puntoZ, -puntoX+puntoY-puntoZ, Color.red);
        Debug.DrawLine(puntoX-puntoY-puntoZ, -puntoX-puntoY-puntoZ, Color.red);

        Debug.DrawLine(puntoX+puntoY-puntoZ, puntoX - puntoY - puntoZ, Color.red);
        Debug.DrawLine(-puntoX + puntoY - puntoZ, -puntoX - puntoY - puntoZ, Color.red);

        Debug.DrawLine(puntoX - puntoY + puntoZ, puntoX - puntoY - puntoZ, Color.red);
        Debug.DrawLine(puntoX + puntoY + puntoZ, puntoX + puntoY - puntoZ, Color.red);

        Debug.DrawLine(-puntoX - puntoY + puntoZ, -puntoX - puntoY - puntoZ, Color.red);
        Debug.DrawLine(-puntoX + puntoY + puntoZ, -puntoX + puntoY - puntoZ, Color.red);



        Debug.DrawLine(punto1, punto2, Color.blue);
        Debug.DrawLine(punto2, punto3, Color.blue);
        Debug.DrawLine(punto3, punto4, Color.blue);
        Debug.DrawLine(punto1, punto4, Color.green);
        Debug.DrawLine(punto1, punto3, Color.green);
        Debug.DrawLine(punto5, punto6, Color.blue);

        if (planos1.GetSide(sphere.transform.position) && planos2.GetSide(sphere.transform.position) &&
            planos3.GetSide(sphere.transform.position) && planos4.GetSide(sphere.transform.position) &&
            planos5.GetSide(sphere.transform.position) && planos6.GetSide(sphere.transform.position))
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

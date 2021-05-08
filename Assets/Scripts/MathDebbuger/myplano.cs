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

    Vector3 punto1 = new Vector3(-5, -5 -5);
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
        planos5 = new Plane(punto3, punto1);
        planos5.Flip();
        planos6 = new Plane(punto5, punto6);
    }
    private void Update()
    {
        if (planos1.GetSide(sphere.transform.position) && planos2.GetSide(sphere.transform.position) &&
            planos3.GetSide(sphere.transform.position) && planos4.GetSide(sphere.transform.position) &&
            planos5.GetSide(sphere.transform.position) && planos6.GetSide(sphere.transform.position))
        {
            Debug.Log("esta dentro");
        }
        else
        {
            Debug.Log("esta fuera ");
        }
    }

}

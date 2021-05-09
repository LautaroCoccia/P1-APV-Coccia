using System.Collections;
using UnityEngine;
using CustomMath;
using MathDebbuger;
public class EjerciciosVector3 : MonoBehaviour
{
    public enum Ejercicio
    {
        uno,
        dos,
        tres,
        cuatro,
        cinco,
        seis,
        siete,
        ocho,
        nueve,
        diez
    }
    [SerializeField] private Vector3 A;
    [SerializeField] private Vector3 B;
    [SerializeField] private Vec3 resultado;
    public float t = 0;
    Vec3 vecB;
    Vec3 vecA;
    public Ejercicio ejer;
    private void Start()
    {
        resultado = new Vec3(0,0,0);
        Vector3Debugger.AddVector(Vec3.Zero, vecA, Color.white, "A");
        Vector3Debugger.EnableEditorView("A");
        Vector3Debugger.AddVector(Vec3.Zero, vecB, Color.black, "B");
        Vector3Debugger.EnableEditorView("B");
        Vector3Debugger.AddVector(Vec3.Zero, resultado, Color.red, "resultado");
        Vector3Debugger.EnableEditorView("resultado");
    }
    // Update is called once per frame
    void Update()
    {
        vecA = new Vec3(A.x, A.y, A.z);
        vecB = new Vec3(B.x, B.y, B.z);
        
        switch (ejer)
        {
            case Ejercicio.uno:
                
                resultado = vecA + vecB;

                break;
            case Ejercicio.dos:
                resultado = vecB - vecA;
                break;
            case Ejercicio.tres:
                resultado = new Vec3(vecA.x * vecB.x, vecA.y * vecB.y, vecA.z * vecB.z);
                break;
            case Ejercicio.cuatro:
                resultado = Vec3.Cross(vecB, vecA);
                break;
            case Ejercicio.cinco:
                resultado = Vec3.Lerp(vecA, vecB, t);
                if(t<1)
                {
                    t += Time.deltaTime;
                }
                else
                {
                    t = 0;
                }
                break;
            case Ejercicio.seis:
                resultado = Vec3.Max(vecA, vecB);
                break;
            case Ejercicio.siete:
                resultado = Vec3.Project(vecA, vecB);
                break;
            case Ejercicio.ocho:
                resultado = vecA + vecB;
                break;
            case Ejercicio.nueve:
                resultado = Vec3.Reflect(vecA, vecB);
                break;
            case Ejercicio.diez:
                resultado = Vec3.LerpUnclamped(vecA, vecB,t);
                if(t<50)
                {
                    t += Time.deltaTime;
                }
                else
                {
                    t = 0;
                }
                break;
        }
        Vector3Debugger.UpdatePosition("A", vecA);
        Vector3Debugger.UpdatePosition("B", vecB);
        Vector3Debugger.UpdatePosition("resultado", resultado);

    }

}

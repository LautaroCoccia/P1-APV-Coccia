using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;
public class EjerciciosQuaternion : MonoBehaviour
{
   public enum Ejercicios
    {
        Ejercicio1,
        Ejercicio2,
        Ejercicio3,
    }
    public Ejercicios ejer;

    [SerializeField] float ANGLE;
    Vector3 ejer1;
    Vector3 ejer2;
    Vector3 ejer3;
    Vector3 ejer4;

    Vector3 ejer5;
    Vector3 ejer6;
    Vector3 ejer7;

    Vector3 ejer8;
    private void Start()
    {
        //EJER 3
        ejer1 = new Vector3(10, 0, 0);
        ejer2 = new Vector3(ejer1.x, 10, 0);
        ejer3 = new Vector3(ejer2.x +10, ejer2.y, 0);
        ejer4 = new Vector3(ejer3.x, ejer3.y+10, 0);
        
        Vector3Debugger.AddVector(new Vector3(0,0,0),ejer1, Color.green, "EL VERDE");
        Vector3Debugger.AddVector(ejer1,ejer2, Color.yellow, "EL AMARILLO");
        Vector3Debugger.AddVector(ejer2,ejer3, Color.white, "EL BLANCO");
        Vector3Debugger.AddVector(ejer3, ejer4, Color.black, "EL NEGRO");
        
        //Ejer 2
        ejer5 = ejer1;
        ejer6 = ejer2;
        ejer7 = ejer3;

        Vector3Debugger.AddVector(new Vector3(0, 0, 0), ejer5, Color.blue, "AZUL1");
        Vector3Debugger.AddVector(ejer5, ejer6, Color.blue, "AZUL2");
        Vector3Debugger.AddVector(ejer6, ejer7, Color.blue, "AZUL3");

        

        //EJER 1
        ejer8 = ejer1;

        Vector3Debugger.AddVector(new Vector3(0, 0, 0), ejer8, Color.green, "VERDE");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(ejer)
        {
            case Ejercicios.Ejercicio1:
                Quater q = Quater.Euler(new Vec3(0, ANGLE,0));
                
                Vector3Debugger.EnableEditorView("VERDE");

                ejer8 = q * new Vec3(ejer8);

                Vector3Debugger.UpdatePosition("VERDE", ejer8);

                Vector3Debugger.DisableEditorView("EL VERDE");
                Vector3Debugger.DisableEditorView("EL AMARILLO");
                Vector3Debugger.DisableEditorView("EL BLANCO");
                Vector3Debugger.DisableEditorView("EL NEGRO");
                                                 
                Vector3Debugger.DisableEditorView("AZUL1");
                Vector3Debugger.DisableEditorView("AZUL2");
                Vector3Debugger.DisableEditorView("AZUL3");
                break;
            case Ejercicios.Ejercicio2:
                Quater qa = Quater.Euler(new Vec3(0, ANGLE,0));

                Vector3Debugger.EnableEditorView("AZUL1");
                Vector3Debugger.EnableEditorView("AZUL2");
                Vector3Debugger.EnableEditorView("AZUL3");

                ejer5 = qa * new Vec3(ejer5);
                ejer6 = qa * new Vec3(ejer6);
                ejer7 = qa * new Vec3(ejer7);
                Vector3Debugger.UpdatePosition("AZUL1", ejer5);
                Vector3Debugger.UpdatePosition("AZUL2", ejer5, ejer6);
                Vector3Debugger.UpdatePosition("AZUL3", ejer6, ejer7);
                //Disable
                Vector3Debugger.DisableEditorView("EL VERDE");
                Vector3Debugger.DisableEditorView("EL AMARILLO");
                Vector3Debugger.DisableEditorView("EL BLANCO");
                Vector3Debugger.DisableEditorView("EL NEGRO");

                Vector3Debugger.DisableEditorView("VERDE");
                break;
            case Ejercicios.Ejercicio3:
                Quater qb = Quater.Euler(new Vec3(ANGLE, ANGLE,0));

                Vector3Debugger.EnableEditorView("EL VERDE");
                Vector3Debugger.EnableEditorView("EL AMARILLO");
                Vector3Debugger.EnableEditorView("EL BLANCO");
                Vector3Debugger.EnableEditorView("EL NEGRO");

                ejer1 = qb * new Vec3(ejer1);
                ejer2 = qb * new Vec3(ejer2);
                ejer3 = Quater.Inverse(qb) * new Vec3(ejer3);
                ejer4 = qb * new Vec3(ejer4);

                Vector3Debugger.UpdatePosition("EL VERDE", ejer1);
                Vector3Debugger.UpdatePosition("EL AMARILLO", ejer1, ejer2);
                Vector3Debugger.UpdatePosition("EL BLANCO", ejer2, ejer3);
                Vector3Debugger.UpdatePosition("EL NEGRO", ejer3, ejer4);

                Vector3Debugger.DisableEditorView("VERDE");

                Vector3Debugger.DisableEditorView("AZUL1");
                Vector3Debugger.DisableEditorView("AZUL2");
                Vector3Debugger.DisableEditorView("AZUL3");

                break;

        }
    }
}
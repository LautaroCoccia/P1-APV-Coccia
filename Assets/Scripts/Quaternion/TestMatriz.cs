using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class TestMatriz : MonoBehaviour
{
    [SerializeField] Matrix4x4 Matrix4;
    Matriz4x4 Matriz4;
    [SerializeField] Vector3 scaleVec;
    [SerializeField] Vector3 translateVec;
    [SerializeField] Vector3 rotateVec;

    // Start is called before the first frame update
    void Start()
    {
        Matriz4.m00 = Matrix4.m00; Matriz4.m10 = Matrix4.m10; Matriz4.m20 = Matrix4.m20; Matriz4.m30 = Matrix4.m30;
        Matriz4.m01 = Matrix4.m01; Matriz4.m11 = Matrix4.m11; Matriz4.m21 = Matrix4.m21; Matriz4.m31 = Matrix4.m31;
        Matriz4.m02 = Matrix4.m02; Matriz4.m12 = Matrix4.m12; Matriz4.m22 = Matrix4.m22; Matriz4.m32 = Matrix4.m32;
        Matriz4.m03 = Matrix4.m03; Matriz4.m13 = Matrix4.m13; Matriz4.m23 = Matrix4.m23; Matriz4.m33 = Matrix4.m33;


        Quaternion test = Quaternion.Euler(rotateVec);

        Matrix4 = Matrix4x4.Translate(translateVec);
        Matrix4 = Matrix4x4.Scale(scaleVec);
        Matrix4 = Matrix4x4.Rotate(test);
        
        Matriz4 = Matriz4x4.Translate(translateVec);
        Matriz4 = Matriz4x4.Rotate(test);
        
        Matrix4 = Matrix4x4.Inverse(Matrix4);
        //Matriz4 = Matriz4x4.Inverse(Matriz4); No anda
        
        Debug.Log("MATRIX4X4 " + "\n" + Matrix4);
        Debug.Log("MATRIZ4X4 " + "\n" + Matriz4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

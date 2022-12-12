using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchanger : MonoBehaviour
{
    [SerializeField] GameObject cube;
    MeshRenderer mesh;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        mesh = cube.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ColorChanger());
        }
    }
    IEnumerator ColorChanger()
    {
        while(time<2)
        {
            time += Time.deltaTime;
            mesh.material.color = Color.Lerp(Color.red, Color.black, time);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        time = 0;
        while (time<2)
        {
            time += Time.deltaTime;
            mesh.material.color = Color.Lerp(Color.black, Color.red, time);
            yield return null;
        }
        time = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploIf : MonoBehaviour
{
    public Material rojo;

    public Material azul;

    public MeshRenderer render;

    float contador = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.material = rojo;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;

        if (contador >= 5.0f)
        {
            render.material = azul;
        }
    }
}

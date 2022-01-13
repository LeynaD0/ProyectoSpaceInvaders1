using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Repaso : MonoBehaviour
{
    public string[] palabras;

    public string error;

    public TextMeshProUGUI palabraCopiar;

    public TextMeshProUGUI contador;

    public TMP_InputField field;

    public float tiempo = 0f;

    bool jugar = true;

    
    // Start is called before the first frame update
    void Start()
    {
        MostrarTexto();
    }

    // Update is called once per frame
    void Update()
    {
       if(jugar == true)
        {
            tiempo += Time.deltaTime;
            contador
        }
    }

    void MostrarTexto()
    {
        palabraCopiar.text = palabras[Random.Range(0, palabras.Length)];
    }

    void 
}

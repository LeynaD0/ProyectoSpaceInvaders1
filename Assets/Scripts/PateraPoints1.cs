using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patera1Points : MonoBehaviour
{
    [SerializeField]

    int valorEnemigo = 20;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            gameObject.SetActive(false);
            other.GetComponent<ContadorPuntos>().Puntos(valorEnemigo);


        }
    }
}

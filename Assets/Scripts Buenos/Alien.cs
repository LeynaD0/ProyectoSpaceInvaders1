using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue;

    public GameObject explosion;

    private float timeExplosion = 1f;


    public void Kill()
    {
        AlienMaster.allAliens.Remove(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        addPoinstEnemy();
    }

    public void addPoinstEnemy()
    {
        UI.instance.point += scoreValue;
        UI.instance.pointsText.text = "Points " + UI.instance.point.ToString();
        Debug.Log("Dando Puntos " + UI.instance.point);
    }
}

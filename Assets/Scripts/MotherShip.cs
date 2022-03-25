using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    
    private const float Max_Left = -400f;
    private float speed = 100f;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x <= Max_Left)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }





}

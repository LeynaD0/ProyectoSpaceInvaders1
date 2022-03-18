using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;
    

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        this.destroyed.Invoke();
        Destroy(this.gameObject);

        if (other.tag == "Separroqui")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Score.instance.AddPointsEnemy1();
        }
        if (other.tag == "Separroqui2")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Score.instance.AddPointsEnemy2();
        }
        if (other.tag == "Separroqui3")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Score.instance.AddPointsEnemy3();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Bunker"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.tag == "MotherShip")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Score.instance.AddPointsMotherShip();
        }
    }

    internal void SetObjective(string v)
    {
        throw new NotImplementedException();
    }

    internal void Launch(Vector3 down, int v)
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;
    public bool alienShooting;

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

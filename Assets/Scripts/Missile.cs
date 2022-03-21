using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Missile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;
    

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;

    }

    internal void SetObjective(string v)
    {
        throw new NotImplementedException();
    }

    internal void Launch(Vector3 down, int v)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.layer == LayerMask.NameToLayer("Bunker"))
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            WinOrLose.instance.YourLose();
            
            
        }

        if (other.tag == "Pared")
        {
            Destroy(this.gameObject);
        }


    }
}

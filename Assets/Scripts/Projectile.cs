using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, float force)
    {
        rigidbody.AddForce(direction * force);
    }

    private void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyController e = collision.collider.GetComponent<EnemyController>();

        if(e != null)
        {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBullet : MonoBehaviour
{
    private float speed = 200;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            collision.gameObject.GetComponent<Alien>().Kill();
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}

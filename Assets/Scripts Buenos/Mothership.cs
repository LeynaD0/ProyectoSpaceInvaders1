using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    public int scoreValue;

    private const float MAX_LEFT = -270f;
    private float speed = 150;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if ( transform.position.x <= MAX_LEFT)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            collision.gameObject.GetComponent<Alien>().Kill();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 100;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            UI.instance.LoseScreen();
        }
    }
}

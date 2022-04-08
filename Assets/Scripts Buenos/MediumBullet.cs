using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MediumBullet : MonoBehaviour
{
    public static MediumBullet instance;
    private float speed = 200;
    public int countEnemies = 4;
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
            countEnemies++;

            if(countEnemies >= 4)
            {
                countEnemies = 0;
                Destroy(gameObject);
            }

            Debug.Log("Enemigos no destruido");
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }


}

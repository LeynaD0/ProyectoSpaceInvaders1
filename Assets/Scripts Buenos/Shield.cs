using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    

    
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Alien"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("StrongBullet"))
        {
            Destroy(gameObject);
        }


    }
}

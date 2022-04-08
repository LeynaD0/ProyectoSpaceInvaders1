using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public ShipStats shiptStats;
    public GameObject bulletPrefab;
    public GameObject strongBulletPrefab;
    public GameObject mediumBulletPrefab;

    private Vector2 offScreenPos = new Vector2(0, -300f);
    private Vector2 startPos = new Vector2(0, -190f);

    private const float MAX_LEFT = -180f;
    private const float MAX_RIGHT = 180f;

    private const float speed = 150;
    private float cooldown = 0.5f;

    private bool isShooting;
    
    void Start()
    {
        shiptStats.currentHealth = shiptStats.maxHealth;
        shiptStats.currentLives = shiptStats.maxLives;

        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > MAX_LEFT)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < MAX_RIGHT)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.W) && !isShooting)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetKey(KeyCode.E) && !isShooting)
        {
            StartCoroutine(StrongBullet());
        }
        
        if (Input.GetKey(KeyCode.Q) && !isShooting)
        {
            StartCoroutine(MediumBullet());
        }
    }

    private void TakeDamage()
    {
        shiptStats.currentHealth--;

        if (shiptStats.currentHealth <= 0)
        {
            shiptStats.currentLives--;

            if (shiptStats.currentLives <= 0)
            {
                Debug.Log("Game Over");
            }
            else
            {
                Debug.Log("Respawn");
                StartCoroutine(Respawn());
            }
        }
    }
    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }

    private IEnumerator StrongBullet()
    {
        isShooting = true;
        Instantiate(strongBulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }

    private IEnumerator MediumBullet()
    {
        isShooting = true;
        Instantiate(mediumBulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        shiptStats.currentHealth = shiptStats.maxHealth;

        transform.position = startPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}

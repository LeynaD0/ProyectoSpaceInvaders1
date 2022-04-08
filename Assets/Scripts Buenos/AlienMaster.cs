using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class AlienMaster : MonoBehaviour
{
    public static AlienMaster instance;
    public GameObject bulletPrefab;
    public GameObject mothershipPrefab;

    private Vector3 hMoveDistance = new Vector3(3f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 3f, 0);
    private Vector3 motherShipSpawnPos = new Vector3(270f, 180f, 0);

    private const float MAX_LEFT = -220f;
    private const float MAX_RIGHT = 220f;
    private const float MAX_MOVE_SPEED = 0.02f;

    private float moveTimer = 0.01f;
    private const float moveTime = 0.005f;

    private float shootTimer = 3f;
    private const float shootTime = 3f;

    private float mothershipTimer = 60f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;

    private bool dontDestroyLast;

    private bool movingRight;

    public static List<GameObject> allAliens = new List<GameObject>();


    void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(go);
        }
    }

    void Update()
    {
        if(moveTimer <= 0)
        {
            MoveEnemies();
        }

        if (shootTimer <= 0)
        {
            Shoot();
        }

        if (mothershipTimer <= 0)
        {
            SpawnMothership();
        }
        moveTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;
        mothershipTimer -= Time.deltaTime;

        
    }

    private void MoveEnemies()
    {
        if(allAliens.Count > 0)
        {
            int hitMax = 0;

            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += hMoveDistance;
                }
                else
                {
                    allAliens[i].transform.position -= hMoveDistance;
                }
                if(allAliens[i].transform.position.x > MAX_RIGHT || allAliens[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
            }

            if(hitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                {
                    allAliens[i].transform.position -= vMoveDistance;
                }

                movingRight = !movingRight;
            }

            moveTimer = GetMoveSpeed();
        }
    }

    /*public void BulletMedium()
    {
        for (int i = 44; i < allAliens.Count; i++)
        {
            if (i >= MediumBullet.instance.countEnemies)
            {
                Destroy(Player.instance.mediumBulletPrefab);
                
                i = 44;
            }

         Debug.Log("Enemigos Alcanzados" + MediumBullet.instance.countEnemies);
        }
    }*/
    private void Shoot()
    {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;

        Instantiate(bulletPrefab, pos, Quaternion.identity);

        shootTimer = shootTime;
    }

    private void SpawnMothership()
    {
        Instantiate(mothershipPrefab, motherShipSpawnPos, Quaternion.identity);
        mothershipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }
    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;
        if (f < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }
    
}

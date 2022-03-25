using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour
{
    public GameObject missilePrefab;
    public GameObject motherShipPrefab;


    private Vector3 hMoveDistance = new Vector3(5f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 2f, 0);
    private Vector3 motherShipSpawnPos = new Vector3(420.4f, 193.1f, 26.3f);

    private const float MAX_LEFT = -200f;
    private const float MAX_RIGHT = 228;
    private const float MAX_MOVE_SPEED = 0.5f;

    private float moveTimer = 0.01f;
    private const float moveTime = 0.005f;

    private float shootTimer = 0.0f;
    private const float shootTime = 1.0f;

    private float motherShipTimer = 60f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;

    private bool movingRight;

    public static List<GameObject> allInvader = new List<GameObject>();

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Separroqui"))
        {
            allInvader.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Separroqui2"))
        {
            allInvader.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Separroqui3"))
        {
            allInvader.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer <= 0)
        {
            MoveEnemies();
        }
        if (shootTimer <= 0)
        {
            Shoot();
        }
        if (motherShipTimer <= 0)
        {
            SpawnMotherShip();
        }

        if (allInvader.Count == 0)
        {
            WinOrLose.instance.YourWin();
        }

        moveTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;
        motherShipTimer -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        if (allInvader.Count > 0)
        {
            int hitMax = 0;

            for (int i = 0; i < allInvader.Count; i++)
            {
                if (movingRight)
                {
                    allInvader[i].transform.position += hMoveDistance;
                }
                else
                {
                    allInvader[i].transform.position -= hMoveDistance;
                }

                if (allInvader[i].transform.position.x > MAX_RIGHT || allInvader[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
                
                
            }
            if(hitMax > 0)
            {
                for (int i = 0; i < allInvader.Count; i++)
                {
                    allInvader[i].transform.position -= vMoveDistance;
                }

                movingRight = !movingRight;
            }
            
            moveTimer = GetMoveSpeed();
        }
    }

    public void Shoot()
    {
        Debug.Log("Enemigo dispara");
        Vector3 pos = allInvader[Random.Range(0, allInvader.Count)].transform.position;

        Instantiate(missilePrefab, pos, Quaternion.identity);

        shootTimer = shootTime;
    }

    private void SpawnMotherShip()
    {
        Instantiate(motherShipPrefab, motherShipSpawnPos, Quaternion.identity);
        motherShipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }
    private float GetMoveSpeed()
    {
        float f = allInvader.Count * moveTime;
        if (f < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bunker")
        {
            gameObject.SetActive(false);
        }
    }
}

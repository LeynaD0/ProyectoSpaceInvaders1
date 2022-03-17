using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// Se encarga de mover los enemigos y seleccionar el que va  a disparar (lógica)
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Serializable]
    public class EnemiesList
    {
        public GameObject[] enemies;
    }
    public EnemiesList[] enemiesList;

    public int columNumber;

    public int[] rowNumber;

    public int columsActivated;
    public GameObject projectilePrefab;
    public float shootTimer = 1;
    public GameObject enemigos;

    public bool spaceToTheR = true;
    public bool spaceToTheL;
    public float movingTimer;
    public float movingTime = 2;

    public static EnemyController instance;

    private void Awake()
    {
        movingTimer = movingTime;
        if (EnemyController.instance == null)
        {
            EnemyController.instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
        columNumber = enemiesList.Length;

        for (int x = 0; x < enemiesList.Length; x++)
        {
            rowNumber.SetValue(enemiesList[x].enemies.Length, x);
        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        PrintArray();
    }

    void PrintArray()
    {
        for (int x = 0; x < enemiesList.Length; x++)
        {
            for (int y = 0; y < enemiesList[x].enemies.Length; y++)
            {
                if (enemiesList[x].enemies[y].activeSelf == true)
                {
                    Debug.Log(enemiesList[x].enemies[y].name);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            shootTimer = 1;
            bool seHaDisparado = false;

            while (!seHaDisparado)
            {
                columsActivated = 0;
                for (int r = 0; r < rowNumber.Length; r++)
                {
                    columsActivated += rowNumber[r];
                }
                if (columsActivated > 0)
                {
                    seHaDisparado = AlienShoot();
                }
                else
                {
                    seHaDisparado = true;
                }
            }
        }

        movingTimer -= Time.deltaTime;

        if (spaceToTheR == true)
        {
            if (movingTimer <= 0)
            {
                enemigos.transform.Translate(Vector3.right * 2);
                movingTimer = movingTime;
            }
        }

        if (spaceToTheL == true)
        {
            if (movingTimer <= 0)
            {
                enemigos.transform.Translate(Vector3.left * 2);
                movingTimer = movingTime;
            }
        }
        
        /*if (Input.GetKeyUp(KeyCode.Space))
        {
            int lastx = 0;
            int lasty = 0;
            bool foundLastActive = false;

            for (int x = 0; x < enemiesList.Length; x++)
            {
                for (int y = 0; y < enemiesList[x].enemies.Length; y++)
                {
                    if (enemiesList[x].enemies[y].activeSelf == false && foundLastActive == false)
                    {
                        foundLastActive = true;
                        Debug.Log("Encontrado primero no activo x = " + lastx + " y = " + lasty);
                    }
                    else if (enemiesList[x].enemies[y].activeSelf == true && foundLastActive == false)
                    {
                        lastx = x;
                        lasty = y;
                    }
                }
            }
            enemiesList[lastx].enemies[lasty].SetActive(false);

        }

        this.transform.position += direction * this.speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToScreenPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToScreenPoint(Vector3.right);
        
        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (direction == Vector3.right && enemy.position.x > rightEdge.x - 1.0f)
            {
                AdvanceRow();
            }

            else if (direction == Vector3.left && enemy.position.x < (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
        }*/
    }

    public bool AlienShoot()
    {
        int colum = UnityEngine.Random.Range(0, enemiesList.Length);
        int lastActiveAlien = 0;
        bool hayAliens = true;
        if (rowNumber[colum] > 0)
        {
            for (int y = 0; y < enemiesList[colum].enemies.Length; y++)
            {
                if (enemiesList[colum].enemies[y].activeSelf == false && y == 0)
                {
                    hayAliens = false;
                    rowNumber.SetValue(0, colum);
                    break;
                }

                else if (enemiesList[colum].enemies[y].activeSelf == true)
                {
                    lastActiveAlien = y;
                    rowNumber.SetValue(lastActiveAlien + 1, colum);
                }
            }

            if (hayAliens)
            {
                GameObject shooter = enemiesList[colum].enemies[lastActiveAlien];
                GameObject projectileObject = Instantiate(projectilePrefab, shooter.transform.position + Vector3.down, Quaternion.Euler(90, 0, 0));
                Projectile projectile = projectileObject.GetComponent<Projectile>();
                projectile.SetObjective("Player");
                projectile.alienShooting = true;
                projectile.transform.localScale *= 0.5f;
                projectile.Launch(Vector3.down, 3000);
            }
        }
        if (rowNumber[colum] == 0)
        {
            hayAliens = false;
        }
        return hayAliens;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            other.gameObject.SetActive(false);
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

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

    public float missileAttackRate = 1.0f;

    bool choquePared = false;

    private Vector3 enemy = new Vector3();

    // Start is called before the first frame update
    private void Start()
    {
        enemy = new Vector3(1f, 0f, 0f);
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
        if (Input.GetKeyUp(KeyCode.Space))
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

        if(choquePared == true)
        {
            enemy.x = enemy.x * -1f;
            choquePared = false;
        }
        transform.Translate(enemy * Time.deltaTime * 10, Space.World);
    }

    private void EnemyAttack()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pared")
        {
            choquePared = true;
        }
    }
}


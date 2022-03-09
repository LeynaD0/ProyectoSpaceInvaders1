using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    [Serializable]
    public class EnemiesList
    {
        public GameObject[] enemies;
    }
    public EnemiesList[] enemiesList;

    // Start is called before the first frame update
    void Start()
    {
        PrintArray();
    }

    void PrintArray()
    {
       for (int x = 0; x < enemiesList.Length; x++)
               {
                   for(int y = 0; y < enemiesList[x].enemies.Length; y++)
                   {
                        if(enemiesList[x].enemies[y].activeSelf == true) 
                        { 
                            Debug.Log(enemiesList[x].enemies[y].name);
                        }
                       
                   }
               }
    }

    // Update is called once per frame
    void Update()
    {
        int lastx = 0;
        int lasty = 0;
        bool foundLastActive;

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
                    lastx;
                    lasty;
                    }
                    
                    
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            enemiesList[2].enemies[enemiesList[2].enemies.Length - 1].SetActive(false);
            PrintArray();
        }
    }
}

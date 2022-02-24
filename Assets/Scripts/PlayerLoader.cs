using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    void Awake()
    {
        GameObject nave = Instantiate(GameDataPersistent.instance.selectSpaceShip.prefab);
        nave.transform.localScale *= 10f;
    }
}

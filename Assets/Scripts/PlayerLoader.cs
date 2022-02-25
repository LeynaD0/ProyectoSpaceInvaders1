using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    void Awake()
    {
        GameObject nave = Instantiate(GameDataPersistent.instance.selectSpaceShip.prefab);
        nave.transform.localScale *= 0.03f;
        nave.transform.position = new Vector3(0, -150, 285);
    }
}

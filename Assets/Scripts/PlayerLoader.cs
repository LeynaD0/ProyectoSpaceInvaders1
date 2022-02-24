using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    private void Awake()
    {
        GameObject nave = Instantiate(GameDataPersistant.instance.selectSpaceShip.prefab);
        nave.transform.localScale *= 10f;
    }
}

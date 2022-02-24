using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataPersistant : MonoBehaviour
{
    public SpaceShipData selectSpaceShip;
    public static GameDataPersistant instance;
    private void Awake()
    {
        if (GameDataPersistant.instance == null)
        {
            GameDataPersistant.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

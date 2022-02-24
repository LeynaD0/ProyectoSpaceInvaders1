using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SpaceShip", order = 1)]

public class SpaceShipData : ScriptableObject
{
    public string spaceshipName;

    [Range(0, 3.0f)]
    public int shield = 2;

    [Range(0, 3.0f)]
    public int speed = 2;

    [Range(0, 3.0f)]
    public int heat = 1;

    public GameObject prefab;

}



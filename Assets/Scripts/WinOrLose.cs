using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    [SerializeField]
    public static WinOrLose instance;
    public GameObject hud;
    public GameObject lose;

    // Update is called once per frame
    void Update()
    {

    }

    public void YourLose()
    {
        hud.SetActive(false);
        lose.SetActive(true);
    }
}

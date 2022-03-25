using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{
    [SerializeField]
    public static WinOrLose instance;
    public GameObject hud;
    public GameObject lose;
    public GameObject win;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YourLose()
    {
        hud.SetActive(false);
        lose.SetActive(true);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Menu");
        hud.SetActive(true);
    }

    public void YourWin()
    {
        hud.SetActive(false);
        win.SetActive(true);
    }
}

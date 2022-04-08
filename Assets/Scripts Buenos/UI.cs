using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    public GameObject hud;
    public GameObject win;
    public GameObject lose;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;

    public int point = 0;
    public int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pointsText.text = "Points " + point.ToString();

        highScoreText.text = "HighScore " + highscore.ToString();
    }

    public void WinScreen()
    {
        win.SetActive(true);
        hud.SetActive(false);
    }

    public void LoseScreen()
    {
        lose.SetActive(true);
        hud.SetActive(false);
    }

    
}



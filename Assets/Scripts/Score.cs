using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;

    int point = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pointsText.text = "Points " + point.ToString();

        highScoreText.text = "HighScore " + highscore.ToString();
    }

    public void AddPointsEnemy1()
    {
            point += 10;
            pointsText.text = point.ToString() + " Points";
        
    }
    public void AddPointsEnemy2()
    {
        point += 20;
        pointsText.text = point.ToString() + " Points";

    }
    public void AddPointsEnemy3()
    {
        point += 30;
        pointsText.text = point.ToString() + " Points";

    }

}

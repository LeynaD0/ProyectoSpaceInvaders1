using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceShipScreen : MonoBehaviour
{
    public SpaceShipData[] infoSpaceShip;
    public Slider speedSlider;
    public Slider shieldSlider;
    public Slider heatSlider;
    public TextMeshProUGUI nameShip;

    public int index = 0;

    public GameObject[] spaceShips;

    private float speed = 1.0f;


    void Start()
    {
        Debug.Log(infoSpaceShip[index].speed);
        Debug.Log(infoSpaceShip[index].shield);
        Debug.Log(infoSpaceShip[index].heat);
        Debug.Log(infoSpaceShip[index].spaceshipName);

        for (int i = 0; i < spaceShips.Length; i++)
        {
            spaceShips[i].SetActive(true);

            if (i == index)
            {
                spaceShips[i].SetActive(true);
            }

            else
            {
                spaceShips[i].SetActive(false);
            }

            nameShip.text = infoSpaceShip[index].spaceshipName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speedSlider.value < infoSpaceShip[index].speed)
        {
            speedSlider.value += Time.deltaTime * speed;
        }

        if (shieldSlider.value < infoSpaceShip[index].shield)
        {
            shieldSlider.value += Time.deltaTime * speed;
        }

        if (heatSlider.value < infoSpaceShip[index].heat)
        {
            heatSlider.value += Time.deltaTime * speed;
        }
    }

    public void NextShip()
    {
        index++;

        if (index > 2)
        {
            index = 0;
        }
        speedSlider.value = 0.0f;
        shieldSlider.value = 0.0f;
        heatSlider.value = 0.0f;
        nameShip.text = infoSpaceShip[index].spaceshipName;

        for (int i = 0; i < spaceShips.Length; i++)
        {
            spaceShips[i].SetActive(true);

            if (i == index)
            {
                spaceShips[i].SetActive(true);
            }

            else
            {
                spaceShips[i].SetActive(false);
            }
        }
    }

    public void PreviusShip()
    {
        index--;

        if (index > 2)
        {
            index = 0;
        }
        speedSlider.value = 0.0f;
        shieldSlider.value = 0.0f;
        heatSlider.value = 0.0f;
        nameShip.text = infoSpaceShip[index].spaceshipName;

        for (int i = 0; i < spaceShips.Length; i++)
        {
            spaceShips[i].SetActive(true);

            if (i == index)
            {
                spaceShips[i].SetActive(true);
            }

            else
            {
                spaceShips[i].SetActive(false);
            }
        }
    }
}
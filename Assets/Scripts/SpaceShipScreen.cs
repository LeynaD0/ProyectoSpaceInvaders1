using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipScreen : MonoBehaviour
{
    public SpaceShipData infoSpaceShip;
    public Slider speedSlider;
    public Slider shieldSlider;
    public Slider heatSlider;
    void Start()
    {
        Debug.Log(infoSpaceShip.speed);
        Debug.Log(infoSpaceShip.shield);
        Debug.Log(infoSpaceShip.heat);
        Debug.Log(infoSpaceShip.spaceshipName);
    }

    // Update is called once per frame
    void Update()
    {
       if (speedSlider.value < infoSpaceShip.speed)
        {
            speedSlider.value += Time.deltaTime * speed;
        }

       if(shieldSlider.value < infoSpaceShip.shield)
        {
            shieldSlider.value += Time.deltaTime.shield;
        }
        heatSlider.value = infoSpaceShip.heat;

    }
}

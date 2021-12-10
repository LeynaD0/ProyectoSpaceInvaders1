using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController menuControll;

    public GameObject introductionScreen; //Un GameObject para asignar una función a la introducción. 

    public GameObject waitingScreen;  //Un GameObject para asignar una función a la pantalla de espera.

    public GameObject menuScreen;  //Un GameObject para asignar una función a la pantalla del menú.

    public GameObject playModeScreen;

    public float timeIntroScreen = 0.0f;  //Un float para poner un tiempo para la introducción. 

    public bool stopTimeIntro = false;

    public GameObject optionsMenuScreen;

    public AudioSource menuEffects;

    bool touchEnded = false;

    public GameObject spaceShipScreen;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (introductionScreen.activeSelf == true)
        {
            IntroductionControllerScreen();
        }else if (waitingScreen.activeSelf == true)
        {
            WaitinScreenController();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                touchEnded = true;
            }
        }
        else
        {
            touchEnded = false;
        }
        
    }

    public void IntroductionControllerScreen()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            introductionScreen.SetActive(false);
            waitingScreen.SetActive(true);
            timeIntroScreen = 109f;
            
        }
        if (stopTimeIntro == false)
        {
            timeIntroScreen += Time.deltaTime;
        }
        if (timeIntroScreen >= 106 && timeIntroScreen < 108)
        {
            stopTimeIntro = true;
            introductionScreen.SetActive(false);
            waitingScreen.SetActive(true);
            timeIntroScreen = 0f;
        }
        
    }
    public void WaitinScreenController()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.touchCount > 0)
        {
            waitingScreen.SetActive(false);
            menuScreen.SetActive(true);
            
        }

        
    }

    public void OptionsMenuScreen()
    {   
        menuScreen.SetActive(false);
        optionsMenuScreen.SetActive(true);       
    }

    public void CancelOptionsMenu()
    {
        optionsMenuScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

    public void AcceptOptionsMenu()
    {
        optionsMenuScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

    public void PlayModeScreen()
    {
        menuScreen.SetActive(false);
        playModeScreen.SetActive(true);
    }

    public void BackButtonScreen()
    {
        playModeScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

    public void SpaceShipScreenOn()
    {
        spaceShipScreen.SetActive(true);
        playModeScreen.SetActive(false);
    }

    public void SpaceShipScreenOff()
    {
        spaceShipScreen.SetActive(false);
        playModeScreen.SetActive(true);
    }
}

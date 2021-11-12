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

    public float timeIntroScreen = 0.0f;  //Un float para poner un tiempo para la introducción. 

    public bool stopTimeIntro = false;

    public GameObject optionsMenuScreen;

    public AudioSource menuEffects;
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IntroductionControllerScreen();
        WaitinScreenController();
        
    }

    public void IntroductionControllerScreen()
    {
        if (Input.GetKey(KeyCode.Space))
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
        if (Input.GetKey(KeyCode.P))
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
}

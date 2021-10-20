using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject introductionScreen;
    public GameObject waitingScreen;
    public GameObject menuScreen;
    

    // Start is called before the first frame update
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
        }
        
        
    }
    public void WaitinScreenController()
    {
        if (Input.GetKey(KeyCode.S))
        {
            waitingScreen.SetActive(false);
            menuScreen.SetActive(true);
        }
    }

    
}

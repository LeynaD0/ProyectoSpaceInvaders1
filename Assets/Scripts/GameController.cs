using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject introductionScreen;
    public GameObject menuScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntroductionControllerScreen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            introductionScreen.SetActive(false);
 
        }
        else
        {
            menuScreen.SetActive(true);
        }

    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlMenu : MonoBehaviour
{
    public AudioSource audioSource;

    public Button selectButton;
    // Start is called before the first frame update
    void OnEnable()
    {
        selectButton.Select();
    }

  
}

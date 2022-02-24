using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
   public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
}

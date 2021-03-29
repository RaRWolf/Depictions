using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    //Load the Tutorial Level (with the build index of 1) 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}

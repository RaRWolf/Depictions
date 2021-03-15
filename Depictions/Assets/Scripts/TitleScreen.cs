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

    //If the player taps on the Options button,
    //Load up the options (Add in Panel later) 
    public void OpenOptions()
    {
        //Add in code to pop up a panel for adding in the options 
    }
}

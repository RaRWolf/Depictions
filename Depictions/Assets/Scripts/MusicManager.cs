using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    //Reference to this Audio Source
    public AudioSource source;

    //Reference to music source 
    //public AudioSource musicSource;

    //An instance of this AudioManager script, which is used for the DontDestroyOnLoad method. 
    private static MusicManager instance;


    private void Awake()
    {
        //If there is already an instance of this script in the current scene, then delete this duplicated instance 
        if (instance != null)
        {
            Destroy(gameObject);
        }

        //Otherwise, if there is no other instances of this script in the current scene, then make sure that it doesn't get deleted with DontDestroyOnLoad()
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject); //DontDestroyOnLoad is applied to the current gameObject with the AudioManager script on it 
        }
    }
}

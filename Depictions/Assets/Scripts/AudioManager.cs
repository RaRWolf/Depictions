using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip cratePushSFX;
    public AudioClip doorOpenSFX;
    public AudioClip playerFootstep;
    public AudioClip playerLose;
    public AudioClip rotateObjectSFX;
    public AudioClip stonePushSFX;

    //Reference to this AudioSource 
    public AudioSource source;

    //An instance of this AudioManager script, which is used for the DontDestroyOnLoad method.
    private static AudioManager instance; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

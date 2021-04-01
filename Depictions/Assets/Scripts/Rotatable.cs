using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    //tj: edit made so that the rotation will affect the parent game object--allows the new mirrors to work
    //tj: modified to allow turning of new mirrors and set default turning points as 180 degree

    public AudioSource mySource;
    public AudioClip rotateSound;

    public Canvas myCanvas;

    public float rotateAngle = 180f;
    public float rotateAngle2 = 270f;
    public Quaternion target;
    private bool Return;
    bool moving;

    void Start()
    {
        myCanvas.enabled = false;
    }

    public void ActivateRotate()
    {
        myCanvas.enabled = true;
    }

    public void DeactivateRotate()
    {
        myCanvas.enabled = false;
    }

    public void RotateRight()
    {
        //Play a sound effect for rotation here
        mySource.clip = rotateSound;
        mySource.Play();

        target = transform.rotation;
        target.y = transform.rotation.y + rotateAngle;
        transform.parent.Rotate(0f, rotateAngle, 0f);
        if(Return)
        {
            rotateAngle2 = rotateAngle2 * -1;
            transform.Rotate(0f, rotateAngle2, 0f);
            Return = false;
        }
        else
        {
            rotateAngle2 = rotateAngle2 * -1;
            transform.Rotate(0f, rotateAngle2, 0f);
            Return = false;
        }
    }

    public void RotateLeft()
    {
        //Play a sound effect for rotation here
        mySource.clip = rotateSound;
        mySource.Play();

        target = transform.rotation;
        target.y = transform.rotation.y - rotateAngle;
        transform.parent.Rotate(0f,-rotateAngle,0f);
        if (Return)
        {
            rotateAngle2 = rotateAngle2 * -1;
            transform.Rotate(0f, rotateAngle2, 0f);
            Return = false;
        }
        else
        {
            rotateAngle2 = rotateAngle2 * -1;
            transform.Rotate(0f, rotateAngle2, 0f);
            Return = false;
        }
    }
}

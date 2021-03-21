using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public Canvas myCanvas;

    public float rotateAngle = 90f;
    public Quaternion target;
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
        target = transform.rotation;
        target.y = transform.rotation.y + rotateAngle;
        transform.Rotate(0f, rotateAngle, 0f);
    }

    public void RotateLeft()
    {
        target = transform.rotation;
        target.y = transform.rotation.y - rotateAngle;
        transform.Rotate(0f,-rotateAngle,0f);
    }
}

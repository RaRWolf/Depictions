using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 direction;
    public bool moving;
    public bool lose;

    public List<Rotatable> rotatables = new List<Rotatable>();

    public AudioSource myAudioSource;
    public AudioClip winSound;
    public AudioClip stepSound;

    public Animator myAnimator;
    public bool touchingSomething;

    private Quaternion targetRot;
    public GameObject myModel;
    float smooth = 5.0f;
    public Fade faderScript;

    void Start()
    {
        moving = false;
        target = transform.position;
        myAudioSource = gameObject.GetComponent<AudioSource>();
        lose = false;
        faderScript = FindObjectOfType<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != target)
        {
            myAnimator.SetBool("isMoving", true);
            moving = true;
            transform.position = Vector3.Lerp(transform.position, target, 10f * Time.deltaTime);
            if(Vector3.Distance(transform.position, target) < 0.1f)
            {
                transform.position = target;
            }
            myAudioSource.loop = true;
            myAudioSource.clip = stepSound;
            if (!myAudioSource.isPlaying)
            {
                myAudioSource.Play();
            }
        }
        else
        {
            moving = false;
            myAnimator.SetBool("isMoving", false);
            myAudioSource.loop = false;
        }

        myModel.transform.rotation = Quaternion.Slerp(myModel.transform.rotation, targetRot, Time.deltaTime * smooth);

        if (lose)
        {
            myAnimator.SetBool("isLosing", true);
        }
    }

    public void Move(string dir)
    {
        if (!lose)
        {
            touchingSomething = false;

            foreach (Rotatable rotatable in rotatables)
            {
                rotatable.DeactivateRotate();
            }
            rotatables.Clear();

            if (dir == "Up")
            {
                direction = Vector3.forward;
                targetRot = Quaternion.Euler(0, 0, 0);
            }

            if (dir == "Right")
            {
                direction = Vector3.right;
                targetRot = Quaternion.Euler(0, 90f, 0);
            }

            if (dir == "Left")
            {
                direction = -Vector3.right;
                targetRot = Quaternion.Euler(0, 270f, 0);
            }

            if (dir == "Down")
            {
                direction = -Vector3.forward;
                targetRot = Quaternion.Euler(0, 180f, 0);
            }

            if (!moving)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit, 1.4f))
                {
                    if (hit.transform.gameObject.layer == 8)
                    {
                        hit.transform.gameObject.GetComponent<ObstacleMovement>().Move(direction);
                    }

                    if (hit.transform.gameObject.layer == 11)
                    {
                        hit.transform.gameObject.GetComponent<PaintingScript>().Toggle();
                        hit.transform.gameObject.SetActive(false);
                        touchingSomething = true;
                    }


                    if (hit.transform.gameObject.GetComponentInParent<Rotatable>() != null)
                    {
                        hit.transform.gameObject.GetComponentInParent<Rotatable>().ActivateRotate();
                        rotatables.Add(hit.transform.gameObject.GetComponentInParent<Rotatable>());
                        touchingSomething = true;
                    }

                    if (hit.transform.tag == "Exit")
                    {
                        myAudioSource.clip = winSound;
                        myAudioSource.loop = false;
                        myAudioSource.Play();
                        faderScript.StartCoroutine("Exit");
                    }
                }
                else
                {
                    target = transform.position + direction;
                }
                moving = true;

                if (touchingSomething)
                {
                    myAnimator.SetBool("isInteracting", true);
                }
                else
                {
                    myAnimator.SetBool("isInteracting", false);
                }
            }
        }
        
    }
}

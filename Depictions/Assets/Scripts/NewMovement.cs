using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 direction;
    public bool moving;


    void Start()
    {
        moving = false;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != target)
        {
            moving = true;
            transform.position = Vector3.Lerp(transform.position, target, 10f * Time.deltaTime);
            if(Vector3.Distance(transform.position, target) < 0.1f)
            {
                transform.position = target;
            }
        }
        else
        {
            moving = false;
        }



        if (Input.GetKeyDown("space"))
        {
            //Move(Vector3.forward);
        }

        if (Input.GetKeyDown("s"))
        {
            //Move(-Vector3.forward);
        }

        if (Input.GetKeyDown("d"))
        {
           // Move(Vector3.right);
        }

        if (Input.GetKeyDown("a"))
        {
           // Move(-Vector3.right);
        }


    }

    public void Move(string dir)
    {
        if (dir == "Up")
        {
            direction = Vector3.forward;
        }

        if (dir == "Right")
        {
            direction = Vector3.right;
        }

        if (dir == "Left")
        {
            direction = -Vector3.right;
        }

        if (dir == "Down")
        {
            direction = -Vector3.forward;
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

                //Don't do anything, there's an obstacle in the way!
            }
            else
            {
                target = transform.position + direction;
            }

        }
    }
}

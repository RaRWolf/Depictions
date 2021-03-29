using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 direction;
    public bool moving;

    public List<Rotatable> rotatables = new List<Rotatable>();


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


    }

    public void Move(string dir)
    {

        foreach (Rotatable rotatable in rotatables)
        {
            rotatable.DeactivateRotate();
        }
        rotatables.Clear();

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
            moving = true;
            StartCoroutine("WaitUntilStopped");
        }
    }

    public void CheckAllDirections()
    {
        Vector3 dir = Vector3.zero;
        RaycastHit rayHitDirection;

        for(int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                dir = Vector3.forward;
            }
            if (i == 1)
            {
                dir = Vector3.right;
            }
            if (i == 2)
            {
                dir = -Vector3.forward;
            }
            if (i == 3)
            {
                dir = -Vector3.right;
            }

            if (Physics.Raycast(transform.position, dir, out rayHitDirection, 1.4f))
            {
                if (rayHitDirection.transform.gameObject.GetComponentInParent<Rotatable>() != null)
                {
                    rayHitDirection.transform.gameObject.GetComponentInParent<Rotatable>().ActivateRotate();
                    rotatables.Add(rayHitDirection.transform.gameObject.GetComponentInParent<Rotatable>());
                }


                if (rayHitDirection.transform.gameObject.GetComponentInParent<PaintingScript>() != null)
                {
                    rayHitDirection.transform.gameObject.GetComponentInParent<PaintingScript>().Toggle();
                }

                if (rayHitDirection.transform.tag == "Exit")
                {
                    Debug.Log("You've successfully left the level!");
                }
            }
        }

    }

    IEnumerator WaitUntilStopped()
    {

        yield return new WaitUntil(() => !moving);

        CheckAllDirections();
    }
}

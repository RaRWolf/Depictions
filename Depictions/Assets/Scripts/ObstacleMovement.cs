using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    bool moving;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target)
        {
            moving = true;
            transform.position = Vector3.Lerp(transform.position, target, 10f * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                transform.position = target;
            }
        }
        else
        {
            moving = false;
        }
    }



        public void Move(Vector3 direction)
    {
        if (!moving)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, 1.4f))
            {
                //Don't do anything, there's an obstacle in the way!
            }
            else
            {
                target = transform.position + direction;
            }

        }
    }
}

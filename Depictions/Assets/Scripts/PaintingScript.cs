using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{

    //edited code to include a way for paintings to fire raycast in direction axis other then Z forward, in inspector set the X and Z to either 0, 1 or -1
    public bool on;
    public int X, Z;
    private Vector3 Direction;

    void Start()
    {
        Direction = new Vector3 (X,0,Z);
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Direction, out hit, Mathf.Infinity) && on)
        {
            Debug.DrawLine(transform.position + (transform.forward / 2), hit.transform.position, Color.yellow);
            if (hit.transform.gameObject.layer == 9)
            {
                hit.transform.gameObject.GetComponent<MirrorScript>().activated = true;

                if (!hit.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(transform.gameObject))
                {
                    hit.transform.gameObject.GetComponent<MirrorScript>().activators.Add(transform.gameObject);
                }
            }
        }
    }

    public void Toggle()
    {
        if (on)
        {
            on = false;
        }
    }
}

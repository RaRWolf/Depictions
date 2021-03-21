using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    public bool on;

    void Start()
    {
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity) && on)
        {
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
